using BizHawk.Client.Common;
using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BizHawk.Client.EmuHawk
{
	class PythonThread
	{
		private Thread thread;

		readonly object _resume_locker = new object();
		readonly object _return_locker = new object();
		private bool _resume = false;
		private bool _return = false;
		private bool _aborted = false;

		public PythonThread(string pythonCode)
		{
			thread = new Thread(() => Run(pythonCode));
			thread.IsBackground = true;
			thread.Start();
		}

		public void Run(string pythonCode)
		{
			using (Py.GIL())
			{
				try
				{
					dynamic pyEmu = Py.Import("bizhawk.emu");
					// FIXME: This pretends there is only a single thread running at a time
					pyEmu.thread = this.ToPython();
					PythonEngine.Exec(pythonCode);
				}
				catch (ThreadAbortException e)
				{
					lock (_return_locker)
					{
						_return = true;
						_aborted = true;
						Monitor.Pulse(_return_locker);
					}
					// Hopefully we called abort as part of a remove
					PythonBridge.ConsoleLog(e.Message);
				}
				catch (Exception e)
				{
					PythonBridge.ConsoleLog(e.Message);
				}
			}
		}

		public void Abort()
		{
			thread.Abort();
		}

		public void Yield()
		{
			lock (_return_locker)
			{
				_return = true;
				Monitor.Pulse(_return_locker);
			}
			lock (_resume_locker)
			{
				_resume = false;
				while (!_resume)
				{
					Monitor.Wait(_resume_locker);
				}
			}
		}

		public void Resume()
		{
			if (_aborted)
			{
				return;
			}

			lock (_resume_locker)
			{
				_resume = true;
				_return = false;
				Monitor.Pulse(_resume_locker);
			}

			lock (_return_locker)
			{
				while (!_return && !_aborted)
				{
					Monitor.Wait(_return_locker);
				}
			}
		}
	}
}
