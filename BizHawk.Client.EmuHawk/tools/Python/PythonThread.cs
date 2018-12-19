using Python.Runtime;
using System;
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
			thread = new Thread(() => Run(pythonCode))
			{
				IsBackground = true
			};
			thread.Start();
		}

		public void Run(string pythonCode)
		{
			_return = false;
			_aborted = false;

			try
			{
				using (Py.GIL())
				{
					PythonEngine.Exec(pythonCode);
				}
			}
			catch (Exception e)
			{
				PythonBridge.ConsoleLog(e.Message);
			} finally
			{
				lock (_return_locker)
				{
					_return = true;
					_aborted = true;
					Monitor.Pulse(_return_locker);
				}
			}
		}

		public bool IsManagedThreadId(int threadId) => thread.ManagedThreadId == threadId;

		public void Abort()
		{
			_aborted = true;
			thread.Abort();
		}

		public void Yield()
		{
			// Comming from python code

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

			// Returning to python code
		}

		public void Resume()
		{
			// Comming from ProgramRunLoop

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

			// Returning to ProgramRunLoop
		}
	}
}
