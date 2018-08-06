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
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pythonToolStrip = new ToolStripEx();
            this.PythonModulesListView = new BizHawk.Client.EmuHawk.VirtualListView();
            this.ModuleName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ModulePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pythonConsoleMenu.SuspendLayout();
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
            this.scriptToolStripMenuItem.Name = "scriptToolStripMenuItem";
            this.scriptToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.scriptToolStripMenuItem.Text = "Script";
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
            this.pythonToolStrip.Location = new System.Drawing.Point(0, 33);
            this.pythonToolStrip.Name = "pythonToolStrip";
            this.pythonToolStrip.Size = new System.Drawing.Size(876, 28);
            this.pythonToolStrip.TabIndex = 1;
            this.pythonToolStrip.Text = "toolStripEx1";
            // 
            // PythonModulesListView
            // 
            this.PythonModulesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PythonModulesListView.BlazingFast = false;
            this.PythonModulesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ModuleName,
            this.ModulePath});
            this.PythonModulesListView.FullRowSelect = true;
            this.PythonModulesListView.GridLines = true;
            this.PythonModulesListView.ItemCount = 0;
            this.PythonModulesListView.Location = new System.Drawing.Point(3, 3);
            this.PythonModulesListView.Name = "PythonModulesListView";
            this.PythonModulesListView.SelectAllInProgress = false;
            this.PythonModulesListView.selectedItem = -1;
            this.PythonModulesListView.Size = new System.Drawing.Size(278, 455);
            this.PythonModulesListView.TabIndex = 2;
            this.PythonModulesListView.UseCompatibleStateImageBehavior = false;
            this.PythonModulesListView.UseCustomBackground = true;
            this.PythonModulesListView.View = System.Windows.Forms.View.Details;
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
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 455);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(6, 423);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(546, 26);
            this.textBox1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.Location = new System.Drawing.Point(6, 25);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(546, 392);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
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
            this.splitContainer1.Panel1.Controls.Add(this.PythonModulesListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(852, 461);
            this.splitContainer1.SplitterDistance = 284;
            this.splitContainer1.TabIndex = 4;
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
		private VirtualListView PythonModulesListView;
		private System.Windows.Forms.ColumnHeader ModuleName;
		private System.Windows.Forms.ColumnHeader ModulePath;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.SplitContainer splitContainer1;
	}
}