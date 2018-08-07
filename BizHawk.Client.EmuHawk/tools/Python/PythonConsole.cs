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
using System.IO;
using BizHawk.Client.Common;
using BizHawk.Client.EmuHawk.WinFormExtensions;

namespace BizHawk.Client.EmuHawk
{
	public partial class PythonConsole : ToolFormBase, IToolFormAutoConfig
	{
		[RequiredService]
		private IEmulator Emulator { get; set; }

		[RequiredService]
		private IVideoProvider VideoProvider { get; set; }

		private PythonFiles pythonFiles = new PythonFiles();

		private dynamic pyBridge;

		private dynamic pyEvents;

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
				// Location of bizhawk.* python modules
				sys.path.append(new PyString(baseDirectory + @"tools\Python"));

				// Location of any user-created python modules
				sys.path.append(new PyString(PathManager.GetPythonPath()));

				pyBridge = Py.Import("bizhawk.bridge");
				pyBridge.wire_console();

				pyEvents = Py.Import("bizhawk.events");
			}

			PythonListView.QueryItemText += PythonListView_QueryItemText;
			//PythonListView.QueryItemBkColor += PythonListView_QueryItemBkColor;
			//PythonListView.QueryItemImage += PythonListView_QueryItemImage;
			//PythonListView.QueryItemIndent += PythonListView_QueryItemIndent;
			PythonListView.VirtualMode = true;

		}

		private void PythonListView_QueryItemText(int index, int column, out string text)
		{
			text = "";
			if (column == 0)
			{
				text = Path.GetFileNameWithoutExtension(pythonFiles[index].Path); // TODO: how about allow the user to name scripts?
			}
			else if (column == 1)
			{
				text = DressUpRelative(pythonFiles[index].Path);
			}
		}
		private string DressUpRelative(string path)
		{
			if (path.StartsWith(".\\"))
			{
				return path.Replace(".\\", "");
			}

			return path;
		}

		public bool UpdateBefore => false;

		public bool AskSaveChanges()
		{
			return true;
		}

		public void FastUpdate()
		{
			pyEvents.on_fast_update.fire();
		}

		public void NewUpdate(ToolFormUpdateType type)
		{
			pyEvents.on_update.fire(type);
		}

		public void Restart()
		{
			pyEvents.on_restart.fire();
		}

		public void UpdateValues()
		{
			pyEvents.on_update_values.fire();
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

		private static FileInfo GetFileFromUser(string filter)
		{
			var ofd = new OpenFileDialog
			{
				InitialDirectory = PathManager.GetPythonPath(),
				Filter = filter,
				RestoreDirectory = true
			};

			if (!Directory.Exists(ofd.InitialDirectory))
			{
				Directory.CreateDirectory(ofd.InitialDirectory);
			}

			var result = ofd.ShowHawkDialog();
			return result == DialogResult.OK ? new FileInfo(ofd.FileName) : null;
		}

		private bool PythonAlreadyInSession(string path)
		{
			return pythonFiles.Any(t => path == t.Path);
		}

		public void LoadPythonFile(string path)
		{
			var processedPath = PathManager.TryMakeRelative(path);
			string pathToLoad = ProcessPath(processedPath);

			if (PythonAlreadyInSession(processedPath))
			{
				return;
			}

			var pythonFile = new PythonFile("", processedPath);

			pythonFiles.Add(pythonFile);
			PythonListView.ItemCount = pythonFiles.Count;
			PythonListView.Refresh();
			Global.Config.RecentLua.Add(processedPath);

			pythonFile.State = PythonFile.RunState.Running;
			EnablePythonFile(pythonFile);
		}


		private void EnablePythonFile(PythonFile item)
		{
			try
			{
				//LuaSandbox.Sandbox(null, () =>
				//{
				//	string pathToLoad = Path.IsPathRooted(item.Path)
				//	? item.Path
				//	: PathManager.MakeProgramRelativePath(item.Path);

				//	item.Thread = LuaImp.SpawnCoroutine(pathToLoad);
				//	LuaSandbox.CreateSandbox(item.Thread, Path.GetDirectoryName(pathToLoad));
				//}, () =>
				//{
				//	item.State = LuaFile.RunState.Disabled;
				//});

				//// Shenanigans
				//// We want any gui.text messages from a script to immediately update even when paused
				//GlobalWin.OSD.ClearGUIText();
				//GlobalWin.Tools.UpdateToolsAfter();
				//LuaImp.EndLuaDrawing();
				//LuaImp.StartLuaDrawing();
			}
			catch (IOException)
			{
				ConsoleLog("Unable to access file " + item.Path);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private string ProcessPath(string path)
		{
			return Path.IsPathRooted(path)
				? path
				: PathManager.MakeProgramRelativePath(path);
		}

		private void openScriptToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var file = GetFileFromUser("Python Scripts (*.py)|*.py");
			if (file != null)
			{
				LoadPythonFile(file.FullName);
				//UpdateDialog();
			}
		}
	}
}
