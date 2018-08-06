using BizHawk.Emulation.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Python.Runtime;

namespace BizHawk.Client.EmuHawk
{
	public partial class PythonConsole : ToolFormBase, IToolFormAutoConfig
	{
		[RequiredService]
		private IEmulator Emulator { get; set; }

		[RequiredService]
		private IVideoProvider VideoProvider { get; set; }

		private dynamic pyBridge;

		private readonly List<string> _consoleCommandHistory = new List<string>();
		private int _consoleCommandHistoryIndex = -1;

		public PythonConsole()
		{
			InitializeComponent();

			PythonBridge.Emulator = Emulator;
			PythonBridge.VideoProvider = VideoProvider;
			PythonBridge.LogEvent += ConsoleLog;

			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string envPythonHome = baseDirectory + @"python-3.6.6-embed-amd64";
			Environment.SetEnvironmentVariable("PYTHONHOME", envPythonHome, EnvironmentVariableTarget.Process);
			Environment.SetEnvironmentVariable("PATH", envPythonHome, EnvironmentVariableTarget.Process);
			PythonEngine.Initialize();

			using (Py.GIL())
			{
				dynamic sys = Py.Import("sys");
				sys.path.append(new PyString(baseDirectory + @"tools\Python"));

				pyBridge = Py.Import("bizhawk.bridge");
				pyBridge.wire_console();
			}
		}

		public bool UpdateBefore => false;

		public bool AskSaveChanges()
		{
			return true;
		}

		public void FastUpdate()
		{
		}

		public void NewUpdate(ToolFormUpdateType type)
		{
		}

		public void Restart()
		{
		}

		public void UpdateValues()
		{
		}

		private void ConsoleLog(PyString message)
		{
			ConsoleLog(message.ToString());
		}

		private void ConsoleLog(string message)
		{
			OutputBox.Text += message + Environment.NewLine;
			OutputBox.SelectionStart = OutputBox.Text.Length;
			OutputBox.ScrollToCaret();
		}

		private void InputBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (string.IsNullOrWhiteSpace(InputBox.Text))
				{
					e.Handled = true;
					e.SuppressKeyPress = true;
					return;
				}

				using (Py.GIL())
				{
					try
					{
						PyObject result = pyBridge.eval_from_input(InputBox.Text);
						if (result != null) {
							ConsoleLog(result.ToString());
						}
					}
					catch (Exception ex)
					{
						ConsoleLog(ex.Message);
					}
				}

				_consoleCommandHistory.Insert(0, InputBox.Text);
				_consoleCommandHistoryIndex = -1;
				InputBox.Clear();
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
			else if (e.KeyCode == Keys.Up)
			{
				if (_consoleCommandHistoryIndex < _consoleCommandHistory.Count - 1)
				{
					_consoleCommandHistoryIndex++;
					InputBox.Text = _consoleCommandHistory[_consoleCommandHistoryIndex];
					InputBox.Select(InputBox.Text.Length, 0);
				}

				e.Handled = true;
			}
			else if (e.KeyCode == Keys.Down)
			{
				if (_consoleCommandHistoryIndex == 0)
				{
					_consoleCommandHistoryIndex--;
					InputBox.Text = "";
				}
				else if (_consoleCommandHistoryIndex > 0)
				{
					_consoleCommandHistoryIndex--;
					InputBox.Text = _consoleCommandHistory[_consoleCommandHistoryIndex];
					InputBox.Select(InputBox.Text.Length, 0);
				}

				e.Handled = true;
			}

		}
	}
}
