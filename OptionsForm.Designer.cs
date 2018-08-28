namespace NppLauncher {
  partial class OptionsForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose (bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose ();
      }
      base.Dispose (disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent () {
      this.button_OK = new System.Windows.Forms.Button();
      this.button_Cancel = new System.Windows.Forms.Button();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.checkBox_RefreshNpp = new System.Windows.Forms.CheckBox();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.button_RemoveFolder = new System.Windows.Forms.Button();
      this.button_AddFolder = new System.Windows.Forms.Button();
      this.listView_TrashFolders = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.button_Edit = new System.Windows.Forms.Button();
      this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.tabControl1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.tabPage3.SuspendLayout();
      this.SuspendLayout();
      // 
      // button_OK
      // 
      this.button_OK.Location = new System.Drawing.Point(494, 298);
      this.button_OK.Name = "button_OK";
      this.button_OK.Size = new System.Drawing.Size(75, 23);
      this.button_OK.TabIndex = 0;
      this.button_OK.Text = "OK";
      this.button_OK.UseVisualStyleBackColor = true;
      this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
      // 
      // button_Cancel
      // 
      this.button_Cancel.Location = new System.Drawing.Point(413, 298);
      this.button_Cancel.Name = "button_Cancel";
      this.button_Cancel.Size = new System.Drawing.Size(75, 23);
      this.button_Cancel.TabIndex = 1;
      this.button_Cancel.Text = "Cancel";
      this.button_Cancel.UseVisualStyleBackColor = true;
      this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Controls.Add(this.tabPage3);
      this.tabControl1.Location = new System.Drawing.Point(12, 12);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(557, 284);
      this.tabControl1.TabIndex = 2;
      // 
      // tabPage1
      // 
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(549, 258);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "General";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.checkBox_RefreshNpp);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(549, 258);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Workaround";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // checkBox_RefreshNpp
      // 
      this.checkBox_RefreshNpp.AutoSize = true;
      this.checkBox_RefreshNpp.Location = new System.Drawing.Point(6, 6);
      this.checkBox_RefreshNpp.Name = "checkBox_RefreshNpp";
      this.checkBox_RefreshNpp.Size = new System.Drawing.Size(282, 16);
      this.checkBox_RefreshNpp.TabIndex = 0;
      this.checkBox_RefreshNpp.Text = "Refresh Npp for white block issue when switch window";
      this.checkBox_RefreshNpp.UseVisualStyleBackColor = true;
      // 
      // tabPage3
      // 
      this.tabPage3.Controls.Add(this.button_Edit);
      this.tabPage3.Controls.Add(this.button_RemoveFolder);
      this.tabPage3.Controls.Add(this.button_AddFolder);
      this.tabPage3.Controls.Add(this.listView_TrashFolders);
      this.tabPage3.Location = new System.Drawing.Point(4, 22);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Size = new System.Drawing.Size(549, 258);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "Auto Trash";
      this.tabPage3.UseVisualStyleBackColor = true;
      // 
      // button_RemoveFolder
      // 
      this.button_RemoveFolder.Location = new System.Drawing.Point(471, 32);
      this.button_RemoveFolder.Name = "button_RemoveFolder";
      this.button_RemoveFolder.Size = new System.Drawing.Size(75, 23);
      this.button_RemoveFolder.TabIndex = 11;
      this.button_RemoveFolder.Text = "Remove";
      this.button_RemoveFolder.UseVisualStyleBackColor = true;
      // 
      // button_AddFolder
      // 
      this.button_AddFolder.Location = new System.Drawing.Point(471, 3);
      this.button_AddFolder.Name = "button_AddFolder";
      this.button_AddFolder.Size = new System.Drawing.Size(75, 23);
      this.button_AddFolder.TabIndex = 10;
      this.button_AddFolder.Text = "Add";
      this.button_AddFolder.UseVisualStyleBackColor = true;
      this.button_AddFolder.Click += new System.EventHandler(this.button_AddFolder_Click);
      // 
      // listView_TrashFolders
      // 
      this.listView_TrashFolders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
      this.listView_TrashFolders.FullRowSelect = true;
      this.listView_TrashFolders.Location = new System.Drawing.Point(7, 3);
      this.listView_TrashFolders.Name = "listView_TrashFolders";
      this.listView_TrashFolders.Size = new System.Drawing.Size(458, 252);
      this.listView_TrashFolders.TabIndex = 9;
      this.listView_TrashFolders.UseCompatibleStateImageBehavior = false;
      this.listView_TrashFolders.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Folder Path";
      this.columnHeader1.Width = 320;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Interval";
      this.columnHeader2.Width = 74;
      // 
      // button_Edit
      // 
      this.button_Edit.Location = new System.Drawing.Point(471, 61);
      this.button_Edit.Name = "button_Edit";
      this.button_Edit.Size = new System.Drawing.Size(75, 23);
      this.button_Edit.TabIndex = 12;
      this.button_Edit.Text = "Edit";
      this.button_Edit.UseVisualStyleBackColor = true;
      this.button_Edit.Click += new System.EventHandler(this.button_Edit_Click);
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "Loading";
      // 
      // OptionsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(577, 328);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.button_Cancel);
      this.Controls.Add(this.button_OK);
      this.Name = "OptionsForm";
      this.Text = "OptionsForm";
      this.Load += new System.EventHandler(this.OptionsForm_Load);
      this.tabControl1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      this.tabPage3.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button button_OK;
    private System.Windows.Forms.Button button_Cancel;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.CheckBox checkBox_RefreshNpp;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.Button button_RemoveFolder;
    private System.Windows.Forms.Button button_AddFolder;
    private System.Windows.Forms.ListView listView_TrashFolders;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.Button button_Edit;
    private System.Windows.Forms.ColumnHeader columnHeader3;
  }
}