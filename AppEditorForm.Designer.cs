namespace NppLauncher {
  partial class AppEditorForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.label1 = new System.Windows.Forms.Label();
      this.textBox_Name = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.textBox_Target = new System.Windows.Forms.TextBox();
      this.button_OK = new System.Windows.Forms.Button();
      this.button_Cancel = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.textBox_Args = new System.Windows.Forms.TextBox();
      this.comboBox_WindowMode = new System.Windows.Forms.ComboBox();
      this.comboBox_WaitMode = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.textBox_Folder = new System.Windows.Forms.TextBox();
      this.button_Folder = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(10, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Name";
      // 
      // textBox_Name
      // 
      this.textBox_Name.Location = new System.Drawing.Point(12, 31);
      this.textBox_Name.Name = "textBox_Name";
      this.textBox_Name.Size = new System.Drawing.Size(137, 20);
      this.textBox_Name.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(10, 59);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(38, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Target";
      // 
      // textBox_Target
      // 
      this.textBox_Target.Location = new System.Drawing.Point(12, 75);
      this.textBox_Target.Name = "textBox_Target";
      this.textBox_Target.Size = new System.Drawing.Size(687, 20);
      this.textBox_Target.TabIndex = 3;
      // 
      // button_OK
      // 
      this.button_OK.Location = new System.Drawing.Point(625, 184);
      this.button_OK.Name = "button_OK";
      this.button_OK.Size = new System.Drawing.Size(75, 25);
      this.button_OK.TabIndex = 4;
      this.button_OK.Text = "OK";
      this.button_OK.UseVisualStyleBackColor = true;
      this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
      // 
      // button_Cancel
      // 
      this.button_Cancel.Location = new System.Drawing.Point(544, 184);
      this.button_Cancel.Name = "button_Cancel";
      this.button_Cancel.Size = new System.Drawing.Size(75, 25);
      this.button_Cancel.TabIndex = 5;
      this.button_Cancel.Text = "Cancel";
      this.button_Cancel.UseVisualStyleBackColor = true;
      this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 102);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(57, 13);
      this.label3.TabIndex = 6;
      this.label3.Text = "Arguments";
      // 
      // textBox_Args
      // 
      this.textBox_Args.Location = new System.Drawing.Point(12, 118);
      this.textBox_Args.Name = "textBox_Args";
      this.textBox_Args.Size = new System.Drawing.Size(687, 20);
      this.textBox_Args.TabIndex = 7;
      // 
      // comboBox_WindowMode
      // 
      this.comboBox_WindowMode.FormattingEnabled = true;
      this.comboBox_WindowMode.Items.AddRange(new object[] {
            "Hidden",
            "Minimized",
            "Maximized",
            "Normal"});
      this.comboBox_WindowMode.Location = new System.Drawing.Point(579, 31);
      this.comboBox_WindowMode.Name = "comboBox_WindowMode";
      this.comboBox_WindowMode.Size = new System.Drawing.Size(121, 21);
      this.comboBox_WindowMode.TabIndex = 10;
      // 
      // comboBox_WaitMode
      // 
      this.comboBox_WaitMode.FormattingEnabled = true;
      this.comboBox_WaitMode.Items.AddRange(new object[] {
            "Wait",
            "Don\'t Wait"});
      this.comboBox_WaitMode.Location = new System.Drawing.Point(452, 31);
      this.comboBox_WaitMode.Name = "comboBox_WaitMode";
      this.comboBox_WaitMode.Size = new System.Drawing.Size(121, 21);
      this.comboBox_WaitMode.TabIndex = 11;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(9, 141);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(92, 13);
      this.label4.TabIndex = 12;
      this.label4.Text = "Working Directory";
      // 
      // textBox_Folder
      // 
      this.textBox_Folder.Location = new System.Drawing.Point(12, 157);
      this.textBox_Folder.Name = "textBox_Folder";
      this.textBox_Folder.Size = new System.Drawing.Size(656, 20);
      this.textBox_Folder.TabIndex = 13;
      // 
      // button_Folder
      // 
      this.button_Folder.Location = new System.Drawing.Point(674, 155);
      this.button_Folder.Name = "button_Folder";
      this.button_Folder.Size = new System.Drawing.Size(26, 23);
      this.button_Folder.TabIndex = 14;
      this.button_Folder.Text = "...";
      this.button_Folder.UseVisualStyleBackColor = true;
      this.button_Folder.Click += new System.EventHandler(this.button_Folder_Click);
      // 
      // AppEditorForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(712, 216);
      this.Controls.Add(this.button_Folder);
      this.Controls.Add(this.textBox_Folder);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.comboBox_WaitMode);
      this.Controls.Add(this.comboBox_WindowMode);
      this.Controls.Add(this.textBox_Args);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.button_Cancel);
      this.Controls.Add(this.button_OK);
      this.Controls.Add(this.textBox_Target);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.textBox_Name);
      this.Controls.Add(this.label1);
      this.Name = "AppEditorForm";
      this.Text = "App Editor";
      this.Load += new System.EventHandler(this.AppEditorForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox_Name;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBox_Target;
    private System.Windows.Forms.Button button_OK;
    private System.Windows.Forms.Button button_Cancel;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBox_Args;
    private System.Windows.Forms.ComboBox comboBox_WindowMode;
    private System.Windows.Forms.ComboBox comboBox_WaitMode;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox textBox_Folder;
    private System.Windows.Forms.Button button_Folder;
  }
}