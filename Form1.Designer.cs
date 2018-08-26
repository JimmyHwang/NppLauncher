namespace NppBot
{
    partial class Form1
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.checkRemoveFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.runDelallpyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.listFoldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.button_Minimum = new System.Windows.Forms.Button();
      this.checkBox_Startup = new System.Windows.Forms.CheckBox();
      this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.showWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.comboBox_Group = new System.Windows.Forms.ComboBox();
      this.listView_Apps = new System.Windows.Forms.ListView();
      this.columnHeader_Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader_Target = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader_Args = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.button_Add = new System.Windows.Forms.Button();
      this.button_AddGroup = new System.Windows.Forms.Button();
      this.button_DelGroup = new System.Windows.Forms.Button();
      this.checkBox_Minimize = new System.Windows.Forms.CheckBox();
      this.button_Remove = new System.Windows.Forms.Button();
      this.button_EditGroup = new System.Windows.Forms.Button();
      this.button_LanuchAll = new System.Windows.Forms.Button();
      this.button_Edit = new System.Windows.Forms.Button();
      this.contextMenuStrip_App = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      this.contextMenuStrip1.SuspendLayout();
      this.contextMenuStrip_App.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(806, 24);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem1});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
      this.saveToolStripMenuItem.Text = "Save";
      this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(95, 6);
      // 
      // exitToolStripMenuItem1
      // 
      this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
      this.exitToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
      this.exitToolStripMenuItem1.Text = "Exit";
      this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
      // 
      // editToolStripMenuItem
      // 
      this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkRemoveFoldersToolStripMenuItem,
            this.runDelallpyToolStripMenuItem,
            this.listFoldersToolStripMenuItem});
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
      this.editToolStripMenuItem.Text = "Edit";
      // 
      // checkRemoveFoldersToolStripMenuItem
      // 
      this.checkRemoveFoldersToolStripMenuItem.Name = "checkRemoveFoldersToolStripMenuItem";
      this.checkRemoveFoldersToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
      this.checkRemoveFoldersToolStripMenuItem.Text = "Check RemoveFolders";
      this.checkRemoveFoldersToolStripMenuItem.Click += new System.EventHandler(this.checkRemoveFoldersToolStripMenuItem_Click);
      // 
      // runDelallpyToolStripMenuItem
      // 
      this.runDelallpyToolStripMenuItem.Name = "runDelallpyToolStripMenuItem";
      this.runDelallpyToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
      this.runDelallpyToolStripMenuItem.Text = "Run delall.py";
      this.runDelallpyToolStripMenuItem.Click += new System.EventHandler(this.runDelallpyToolStripMenuItem_Click);
      // 
      // listFoldersToolStripMenuItem
      // 
      this.listFoldersToolStripMenuItem.Name = "listFoldersToolStripMenuItem";
      this.listFoldersToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
      this.listFoldersToolStripMenuItem.Text = "List Folders";
      this.listFoldersToolStripMenuItem.Click += new System.EventHandler(this.listFoldersToolStripMenuItem_Click);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.helpToolStripMenuItem.Text = "Help";
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Interval = 1000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // button_Minimum
      // 
      this.button_Minimum.Location = new System.Drawing.Point(719, 247);
      this.button_Minimum.Name = "button_Minimum";
      this.button_Minimum.Size = new System.Drawing.Size(75, 23);
      this.button_Minimum.TabIndex = 2;
      this.button_Minimum.Text = "Minimum";
      this.button_Minimum.UseVisualStyleBackColor = true;
      this.button_Minimum.Click += new System.EventHandler(this.button_Minimum_Click);
      // 
      // checkBox_Startup
      // 
      this.checkBox_Startup.AutoSize = true;
      this.checkBox_Startup.Location = new System.Drawing.Point(12, 276);
      this.checkBox_Startup.Name = "checkBox_Startup";
      this.checkBox_Startup.Size = new System.Drawing.Size(91, 16);
      this.checkBox_Startup.TabIndex = 3;
      this.checkBox_Startup.Text = "Run at Startup";
      this.checkBox_Startup.UseVisualStyleBackColor = true;
      this.checkBox_Startup.CheckedChanged += new System.EventHandler(this.checkBox_Startup_CheckedChanged);
      // 
      // notifyIcon1
      // 
      this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
      this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
      this.notifyIcon1.Text = "notifyIcon1";
      this.notifyIcon1.Visible = true;
      this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showWindowToolStripMenuItem,
            this.groupToolStripMenuItem,
            this.exitToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(151, 70);
      // 
      // showWindowToolStripMenuItem
      // 
      this.showWindowToolStripMenuItem.Name = "showWindowToolStripMenuItem";
      this.showWindowToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.showWindowToolStripMenuItem.Text = "Show Window";
      this.showWindowToolStripMenuItem.Click += new System.EventHandler(this.showWindowToolStripMenuItem_Click);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
      this.exitToolStripMenuItem.Text = "Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // comboBox_Group
      // 
      this.comboBox_Group.FormattingEnabled = true;
      this.comboBox_Group.Location = new System.Drawing.Point(12, 27);
      this.comboBox_Group.Name = "comboBox_Group";
      this.comboBox_Group.Size = new System.Drawing.Size(672, 20);
      this.comboBox_Group.Sorted = true;
      this.comboBox_Group.TabIndex = 4;
      this.comboBox_Group.SelectedValueChanged += new System.EventHandler(this.comboBox_Group_SelectedValueChanged);
      // 
      // listView_Apps
      // 
      this.listView_Apps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Title,
            this.columnHeader_Target,
            this.columnHeader_Args});
      this.listView_Apps.FullRowSelect = true;
      this.listView_Apps.Location = new System.Drawing.Point(12, 53);
      this.listView_Apps.Name = "listView_Apps";
      this.listView_Apps.Size = new System.Drawing.Size(701, 217);
      this.listView_Apps.Sorting = System.Windows.Forms.SortOrder.Ascending;
      this.listView_Apps.TabIndex = 5;
      this.listView_Apps.UseCompatibleStateImageBehavior = false;
      this.listView_Apps.View = System.Windows.Forms.View.Details;
      this.listView_Apps.DoubleClick += new System.EventHandler(this.listView_Apps_DoubleClick);
      this.listView_Apps.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_Apps_MouseClick);
      // 
      // columnHeader_Title
      // 
      this.columnHeader_Title.Text = "Title";
      this.columnHeader_Title.Width = 89;
      // 
      // columnHeader_Target
      // 
      this.columnHeader_Target.Text = "Target";
      this.columnHeader_Target.Width = 280;
      // 
      // columnHeader_Args
      // 
      this.columnHeader_Args.Text = "Arguments";
      this.columnHeader_Args.Width = 326;
      // 
      // button_Add
      // 
      this.button_Add.Location = new System.Drawing.Point(719, 53);
      this.button_Add.Name = "button_Add";
      this.button_Add.Size = new System.Drawing.Size(75, 23);
      this.button_Add.TabIndex = 7;
      this.button_Add.Text = "Add";
      this.button_Add.UseVisualStyleBackColor = true;
      this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
      // 
      // button_AddGroup
      // 
      this.button_AddGroup.Location = new System.Drawing.Point(719, 27);
      this.button_AddGroup.Name = "button_AddGroup";
      this.button_AddGroup.Size = new System.Drawing.Size(34, 23);
      this.button_AddGroup.TabIndex = 8;
      this.button_AddGroup.Text = "+";
      this.button_AddGroup.UseVisualStyleBackColor = true;
      this.button_AddGroup.Click += new System.EventHandler(this.button_AddGroup_Click);
      // 
      // button_DelGroup
      // 
      this.button_DelGroup.Location = new System.Drawing.Point(759, 27);
      this.button_DelGroup.Name = "button_DelGroup";
      this.button_DelGroup.Size = new System.Drawing.Size(35, 23);
      this.button_DelGroup.TabIndex = 9;
      this.button_DelGroup.Text = "-";
      this.button_DelGroup.UseVisualStyleBackColor = true;
      this.button_DelGroup.Click += new System.EventHandler(this.button_DelGroup_Click);
      // 
      // checkBox_Minimize
      // 
      this.checkBox_Minimize.AutoSize = true;
      this.checkBox_Minimize.Location = new System.Drawing.Point(109, 276);
      this.checkBox_Minimize.Name = "checkBox_Minimize";
      this.checkBox_Minimize.Size = new System.Drawing.Size(115, 16);
      this.checkBox_Minimize.TabIndex = 10;
      this.checkBox_Minimize.Text = "Minimize at Startup";
      this.checkBox_Minimize.UseVisualStyleBackColor = true;
      // 
      // button_Remove
      // 
      this.button_Remove.Location = new System.Drawing.Point(719, 82);
      this.button_Remove.Name = "button_Remove";
      this.button_Remove.Size = new System.Drawing.Size(75, 23);
      this.button_Remove.TabIndex = 12;
      this.button_Remove.Text = "Remove";
      this.button_Remove.UseVisualStyleBackColor = true;
      this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
      // 
      // button_EditGroup
      // 
      this.button_EditGroup.Location = new System.Drawing.Point(690, 27);
      this.button_EditGroup.Name = "button_EditGroup";
      this.button_EditGroup.Size = new System.Drawing.Size(23, 23);
      this.button_EditGroup.TabIndex = 13;
      this.button_EditGroup.Text = "...";
      this.button_EditGroup.UseVisualStyleBackColor = true;
      this.button_EditGroup.Click += new System.EventHandler(this.button_EditGroup_Click);
      // 
      // button_LanuchAll
      // 
      this.button_LanuchAll.Location = new System.Drawing.Point(719, 218);
      this.button_LanuchAll.Name = "button_LanuchAll";
      this.button_LanuchAll.Size = new System.Drawing.Size(75, 23);
      this.button_LanuchAll.TabIndex = 14;
      this.button_LanuchAll.Text = "Launch All";
      this.button_LanuchAll.UseVisualStyleBackColor = true;
      this.button_LanuchAll.Click += new System.EventHandler(this.button_LanuchAll_Click);
      // 
      // button_Edit
      // 
      this.button_Edit.Location = new System.Drawing.Point(719, 111);
      this.button_Edit.Name = "button_Edit";
      this.button_Edit.Size = new System.Drawing.Size(75, 23);
      this.button_Edit.TabIndex = 15;
      this.button_Edit.Text = "Edit";
      this.button_Edit.UseVisualStyleBackColor = true;
      this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
      // 
      // contextMenuStrip_App
      // 
      this.contextMenuStrip_App.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.cloneToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.editToolStripMenuItem1});
      this.contextMenuStrip_App.Name = "contextMenuStrip_App";
      this.contextMenuStrip_App.Size = new System.Drawing.Size(118, 92);
      // 
      // runToolStripMenuItem
      // 
      this.runToolStripMenuItem.Name = "runToolStripMenuItem";
      this.runToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.runToolStripMenuItem.Text = "Run";
      this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
      // 
      // cloneToolStripMenuItem
      // 
      this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
      this.cloneToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.cloneToolStripMenuItem.Text = "Clone";
      this.cloneToolStripMenuItem.Click += new System.EventHandler(this.cloneToolStripMenuItem_Click);
      // 
      // removeToolStripMenuItem
      // 
      this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
      this.removeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.removeToolStripMenuItem.Text = "Remove";
      this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
      // 
      // editToolStripMenuItem1
      // 
      this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
      this.editToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
      this.editToolStripMenuItem1.Text = "Edit";
      this.editToolStripMenuItem1.Click += new System.EventHandler(this.editToolStripMenuItem1_Click);
      // 
      // groupToolStripMenuItem
      // 
      this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
      this.groupToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
      this.groupToolStripMenuItem.Text = "Launch Group";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(806, 304);
      this.Controls.Add(this.button_Edit);
      this.Controls.Add(this.button_LanuchAll);
      this.Controls.Add(this.button_EditGroup);
      this.Controls.Add(this.button_Remove);
      this.Controls.Add(this.checkBox_Minimize);
      this.Controls.Add(this.button_DelGroup);
      this.Controls.Add(this.button_AddGroup);
      this.Controls.Add(this.button_Add);
      this.Controls.Add(this.listView_Apps);
      this.Controls.Add(this.comboBox_Group);
      this.Controls.Add(this.checkBox_Startup);
      this.Controls.Add(this.button_Minimum);
      this.Controls.Add(this.menuStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "Form1";
      this.Text = "Form1";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.contextMenuStrip1.ResumeLayout(false);
      this.contextMenuStrip_App.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Button button_Minimum;
    private System.Windows.Forms.CheckBox checkBox_Startup;
    private System.Windows.Forms.NotifyIcon notifyIcon1;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem showWindowToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem checkRemoveFoldersToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem runDelallpyToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem listFoldersToolStripMenuItem;
    private System.Windows.Forms.ComboBox comboBox_Group;
    private System.Windows.Forms.ListView listView_Apps;
    private System.Windows.Forms.Button button_Add;
    private System.Windows.Forms.ColumnHeader columnHeader_Title;
    private System.Windows.Forms.ColumnHeader columnHeader_Target;
    private System.Windows.Forms.Button button_AddGroup;
    private System.Windows.Forms.Button button_DelGroup;
    private System.Windows.Forms.CheckBox checkBox_Minimize;
    private System.Windows.Forms.Button button_Remove;
    private System.Windows.Forms.Button button_EditGroup;
    private System.Windows.Forms.Button button_LanuchAll;
    private System.Windows.Forms.ColumnHeader columnHeader_Args;
    private System.Windows.Forms.Button button_Edit;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip_App;
    private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem groupToolStripMenuItem;
  }
}

