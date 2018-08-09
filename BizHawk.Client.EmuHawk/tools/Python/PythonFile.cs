using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizHawk.Client.EmuHawk
{
	class PythonFile
	{
		public PythonFile(string path): this("", path)
		{
		}

		public PythonFile(string name, string path)
		{
			Name = name;
			Path = path;
			State = RunState.Running;
			FrameWaiting = false;

			// the current directory for the python task will start off wherever the python file is located
			CurrentDirectory = System.IO.Path.GetDirectoryName(path);
		}

		public string Name { get; set; }
		public string Path { get; }
		public bool Enabled => State != RunState.Disabled;
		public bool Paused => State == RunState.Paused;
		public bool FrameWaiting { get; set; }
		public string CurrentDirectory { get; set; }

		public enum RunState
		{
			Disabled, Running, Paused
		}

		public RunState State { get; set; }

		public void Stop()
		{
			State = RunState.Disabled;
		}

		public void Toggle()
		{
			if (State == RunState.Paused)
			{
				State = RunState.Running;
			}
			else if (State == RunState.Disabled)
			{
				State = RunState.Running;
				FrameWaiting = false;
			}
			else
			{
				State = RunState.Disabled;
			}
		}

		public void TogglePause()
		{
			if (State == RunState.Paused)
			{
				State = RunState.Running;
			}
			else if (State == RunState.Running)
			{
				State = RunState.Paused;
			}
		}
	}
}
