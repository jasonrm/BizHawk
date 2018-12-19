using BizHawk.Emulation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BizHawk.Client.EmuHawk
{
	public static class PythonBridge
	{
		public static IEmulator Emulator { get; set; }

		public static IVideoProvider VideoProvider { get; set; }

		public delegate void LogEventHandler(string message);

		public static event LogEventHandler LogEvent;

		public static void ConsoleLog(string message)
		{
			LogEvent?.Invoke(message);
		}

		public static void YieldCurrentThread()
		{
			int threadId = Thread.CurrentThread.ManagedThreadId;
			GlobalWin.Tools.PythonConsole.YieldThread(threadId);
		}
	}
}
