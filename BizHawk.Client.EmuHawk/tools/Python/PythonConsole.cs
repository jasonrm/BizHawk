using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public partial class PythonConsole : ToolFormBase, IToolFormAutoConfig
	{
		public PythonConsole()
		{
			InitializeComponent();
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
	}
}
