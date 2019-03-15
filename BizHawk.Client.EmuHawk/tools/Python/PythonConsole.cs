using BizHawk.Emulation.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Python.Runtime;
using System.IO;
using BizHawk.Client.Common;
using BizHawk.Client.EmuHawk.WinFormExtensions;
using Microsoft.Win32;

namespace BizHawk.Client.EmuHawk
{
	public partial class PythonConsole : ToolFormBase, IToolFormAutoConfig
	{
		[RequiredService]
		private IEmulator Emulator { get; set; }

		[RequiredService]
		private IVideoProvider VideoProvider { get; set; }

		private PythonFiles pythonFiles = new PythonFiles();

		private readonly Dictionary<PythonFile, PythonThread> runningThreads = new Dictionary<PythonFile, PythonThread>();

		internal void YieldThread(int threadId)
		{
			// FIXME: This is ugly
			foreach (var thread in runningThreads)
			{
				if (thread.Value.IsManagedThreadId(threadId))
				{
					thread.Value.Yield();
					return;
				}
			}
		}

		private dynamic pyBridge;

		private dynamic pyEvents;

		private readonly List<string> _consoleCommandHistory = new List<string>();
		private int _consoleCommandHistoryIndex = -1;

		public PythonConsole()
		{
			InitializeComponent();

			PythonBridge.LogEvent += ConsoleLog;

			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			string envPythonHome = GetPythonExecutablePath();
			Environment.SetEnvironmentVariable("PYTHONHOME", envPythonHome, EnvironmentVariableTarget.Process);
			Environment.SetEnvironmentVariable("PATH", envPythonHome, EnvironmentVariableTarget.Process);
			PythonEngine.Initialize();
			PythonEngine.BeginAllowThreads();

			Closing += (o, e) =>
			{
				ClosePython();
			};

			using (Py.GIL())
			{
				dynamic sys = Py.Import("sys");
				// Location of bizhawk.* python modules
				sys.path.append(new PyString(baseDirectory + @"tools\\Python"));

				// Location of included packages
				sys.path.append(new PyString(baseDirectory + @"site-packages"));

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

		public void ClosePython()
		{
			foreach (var thread in runningThreads)
			{
				thread.Value.Abort();
			}
			PythonEngine.AcquireLock();
			PythonEngine.Shutdown();
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
			//pyEvents.on_fast_update.fire();
		}

		public void NewUpdate(ToolFormUpdateType type)
		{
			//pyEvents.on_update.fire(type);
		}

		public void Restart()
		{
			//pyEvents.on_restart.fire();
		}

		public void UpdateValues()
		{
			//pyEvents.on_update_values.fire();
		}

		public void ResumeScripts()
		{
			foreach (var thread in runningThreads)
			{
				thread.Value.Resume();
			}
		}

		private void ConsoleLog(PyString message)
		{
			ConsoleLog(message.ToString());
		}

		private void ConsoleLog(string message)
		{
			if (OutputBox.IsHandleCreated) {
				OutputBox.BeginInvoke((Action)delegate
				{
					OutputBox.Text += message;
					OutputBox.SelectionStart = OutputBox.Text.Length;
					OutputBox.ScrollToCaret();
				});
			}
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
							ConsoleLog(result.ToString().TrimEnd(Environment.NewLine.ToCharArray()) + "\n");
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
			UpdateViews();
			Global.Config.RecentLua.Add(processedPath);

			pythonFile.State = PythonFile.RunState.Running;
			EnablePythonFile(pythonFile);
		}

		private void UpdateViews()
		{
			PythonListView.ItemCount = pythonFiles.Count;
			PythonListView.Refresh();
		}

		private void EnablePythonFile(PythonFile item)
		{
			PythonBridge.Emulator = Emulator;
			PythonBridge.VideoProvider = VideoProvider;

			try
			{
				string pythonCode = File.ReadAllText(item.Path);
				var newThread = new PythonThread(item.Path, pythonCode);
				runningThreads[item] = newThread;
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

		private IEnumerable<PythonFile> SelectedItems
		{
			get { return PythonListView.SelectedIndices().Select(index => pythonFiles[index]); }
		}

		private IEnumerable<PythonFile> SelectedFiles
		{
			get { return SelectedItems; }
		}

		private readonly List<FileSystemWatcher> _watches = new List<FileSystemWatcher>();

		private void AddFileWatches()
		{
			_watches.Clear();
			foreach (var item in pythonFiles)
			{
				var processedPath = PathManager.TryMakeRelative(item.Path);
				string pathToLoad = ProcessPath(processedPath);

				CreateFileWatcher(pathToLoad);
			}
		}

		private void CreateFileWatcher(string path)
		{
			var watcher = new FileSystemWatcher
			{
				Path = Path.GetDirectoryName(path),
				Filter = Path.GetFileName(path),
				NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
							 | NotifyFilters.FileName | NotifyFilters.DirectoryName,
				EnableRaisingEvents = true,
			};

			// TODO, Deleted and Renamed events
			watcher.Changed += OnChanged;

			_watches.Add(watcher);
		}

		private void OnChanged(object source, FileSystemEventArgs e)
		{
			string message = "File: " + e.FullPath + " " + e.ChangeType;
			Invoke(new MethodInvoker(delegate
			{
				RefreshScriptMenuItem_Click(null, null);
			}));
		}

		private void RefreshScriptMenuItem_Click(object sender, EventArgs e)
		{
			ToggleScriptMenuItem_Click(sender, e);
			ToggleScriptMenuItem_Click(sender, e);
		}

		private void ToggleScriptMenuItem_Click(object sender, EventArgs e)
		{
			var files = !SelectedFiles.Any() && Global.Config.ToggleAllIfNoneSelected ? pythonFiles : SelectedFiles;
			foreach (var file in files)
			{
				file.Toggle();

				if (file.Enabled)
				{
					EnablePythonFile(file);
				}

				else if (!file.Enabled)
				{
					file.Stop();
					var thread = runningThreads[file];
					thread.Abort();

					runningThreads.Remove(file);
				}
			}

			UpdateViews();
		}

		private void RemoveScriptMenuItem_Click(object sender, EventArgs e)
		{
			var items = SelectedItems.ToList();
			if (items.Any())
			{
				foreach (var item in items)
				{
					if (runningThreads.ContainsKey(item))
					{
						var thread = runningThreads[item];
						thread.Abort();
					}
					runningThreads.Remove(item);
					pythonFiles.Remove(item);
				}
			}

			UpdateViews();
		}

		// via: https://stackoverflow.com/a/43229470
		static string GetPythonExecutablePath(int major = 3)
		{
			RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Python\\PythonCore\\3.6\\InstallPath");
			return (string) key.GetValue(null);
		}
	}
}
