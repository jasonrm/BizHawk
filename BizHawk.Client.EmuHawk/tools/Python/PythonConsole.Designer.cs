namespace BizHawk.Client.EmuHawk
{
	partial class PythonConsole
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.pythonConsoleMenu = new MenuStripEx();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveScriptMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pythonToolStrip = new ToolStripEx();
            this.PythonListView = new BizHawk.Client.EmuHawk.VirtualListView();
            this.ModuleName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ModulePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.OutputBox = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.pythonConsoleMenu.SuspendLayout();
            this.pythonToolStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pythonConsoleMenu
            // 
            this.pythonConsoleMenu.ClickThrough = true;
            this.pythonConsoleMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.pythonConsoleMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.scriptToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.pythonConsoleMenu.Location = new System.Drawing.Point(0, 0);
            this.pythonConsoleMenu.Name = "pythonConsoleMenu";
            this.pythonConsoleMenu.Size = new System.Drawing.Size(876, 33);
            this.pythonConsoleMenu.TabIndex = 0;
            this.pythonConsoleMenu.Text = "menuStripEx1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // scriptToolStripMenuItem
            // 
            this.scriptToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openScriptToolStripMenuItem,
            this.RemoveScriptMenuItem,
            this.refreshToolStripMenuItem});
            this.scriptToolStripMenuItem.Name = "scriptToolStripMenuItem";
            this.scriptToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.scriptToolStripMenuItem.Text = "Script";
            // 
            // openScriptToolStripMenuItem
            // 
            this.openScriptToolStripMenuItem.Image = global::BizHawk.Client.EmuHawk.Properties.Resources.OpenFile;
            this.openScriptToolStripMenuItem.Name = "openScriptToolStripMenuItem";
            this.openScriptToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openScriptToolStripMenuItem.Size = new System.Drawing.Size(255, 30);
            this.openScriptToolStripMenuItem.Text = "&Open Script";
            this.openScriptToolStripMenuItem.Click += new System.EventHandler(this.openScriptToolStripMenuItem_Click);
            // 
            // RemoveScriptMenuItem
            // 
            this.RemoveScriptMenuItem.Image = global::BizHawk.Client.EmuHawk.Properties.Resources.Delete;
            this.RemoveScriptMenuItem.Name = "RemoveScriptMenuItem";
            this.RemoveScriptMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.RemoveScriptMenuItem.Size = new System.Drawing.Size(255, 30);
            this.RemoveScriptMenuItem.Text = "&Remove Script";
            this.RemoveScriptMenuItem.Click += new System.EventHandler(this.RemoveScriptMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // pythonToolStrip
            // 
            this.pythonToolStrip.ClickThrough = true;
            this.pythonToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.pythonToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton4,
            this.toolStripButton3});
            this.pythonToolStrip.Location = new System.Drawing.Point(0, 33);
            this.pythonToolStrip.Name = "pythonToolStrip";
            this.pythonToolStrip.Size = new System.Drawing.Size(876, 31);
            this.pythonToolStrip.TabIndex = 1;
            this.pythonToolStrip.Text = "toolStripEx1";
            // 
            // PythonListView
            // 
            this.PythonListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PythonListView.BlazingFast = false;
            this.PythonListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ModuleName,
            this.ModulePath});
            this.PythonListView.FullRowSelect = true;
            this.PythonListView.GridLines = true;
            this.PythonListView.ItemCount = 0;
            this.PythonListView.Location = new System.Drawing.Point(3, 3);
            this.PythonListView.Name = "PythonListView";
            this.PythonListView.SelectAllInProgress = false;
            this.PythonListView.selectedItem = -1;
            this.PythonListView.Size = new System.Drawing.Size(278, 455);
            this.PythonListView.TabIndex = 2;
            this.PythonListView.UseCompatibleStateImageBehavior = false;
            this.PythonListView.UseCustomBackground = true;
            this.PythonListView.View = System.Windows.Forms.View.Details;
            // 
            // ModuleName
            // 
            this.ModuleName.Text = "Module";
            this.ModuleName.Width = 200;
            // 
            // ModulePath
            // 
            this.ModulePath.Text = "Path";
            this.ModulePath.Width = 190;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.InputBox);
            this.groupBox1.Controls.Add(this.OutputBox);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 455);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
            // 
            // InputBox
            // 
            this.InputBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputBox.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputBox.Location = new System.Drawing.Point(6, 424);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(546, 31);
            this.InputBox.TabIndex = 1;
            this.InputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputBox_KeyDown);
            // 
            // OutputBox
            // 
            this.OutputBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputBox.BackColor = System.Drawing.SystemColors.Control;
            this.OutputBox.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputBox.Location = new System.Drawing.Point(6, 25);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.Size = new System.Drawing.Size(546, 393);
            this.OutputBox.TabIndex = 0;
            this.OutputBox.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 61);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.PythonListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(852, 461);
            this.splitContainer1.SplitterDistance = 284;
            this.splitContainer1.TabIndex = 4;
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::BizHawk.Client.EmuHawk.Properties.Resources.Refresh1;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(255, 30);
            this.refreshToolStripMenuItem.Text = "Re&fresh";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::BizHawk.Client.EmuHawk.Properties.Resources.OpenFile;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.openScriptToolStripMenuItem_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::BizHawk.Client.EmuHawk.Properties.Resources.Refresh1;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.RefreshScriptMenuItem_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::BizHawk.Client.EmuHawk.Properties.Resources.Delete;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.RemoveScriptMenuItem_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::BizHawk.Client.EmuHawk.Properties.Resources.checkbox;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton4.Text = "toolStripButton4";
            this.toolStripButton4.Click += new System.EventHandler(this.ToggleScriptMenuItem_Click);
            // 
            // PythonConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 534);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pythonToolStrip);
            this.Controls.Add(this.pythonConsoleMenu);
            this.MainMenuStrip = this.pythonConsoleMenu;
            this.Name = "PythonConsole";
            this.Text = "Python Console";
            this.pythonConsoleMenu.ResumeLayout(false);
            this.pythonConsoleMenu.PerformLayout();
            this.pythonToolStrip.ResumeLayout(false);
            this.pythonToolStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private MenuStripEx pythonConsoleMenu;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem scriptToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private ToolStripEx pythonToolStrip;
		private VirtualListView PythonListView;
		private System.Windows.Forms.ColumnHeader ModuleName;
		private System.Windows.Forms.ColumnHeader ModulePath;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RichTextBox OutputBox;
		private System.Windows.Forms.TextBox InputBox;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripMenuItem openScriptToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem RemoveScriptMenuItem;
		private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.ToolStripButton toolStripButton3;
		private System.Windows.Forms.ToolStripButton toolStripButton4;
	}
}