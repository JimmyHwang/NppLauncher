namespace NppLauncher {
  partial class AutoTrashForm {
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
      this.button_Cancel = new System.Windows.Forms.Button();
      this.textBox_Folder = new System.Windows.Forms.TextBox();
      this.button_Folder = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.comboBox_Interval = new System.Windows.Forms.ComboBox();
      this.comboBox_Loading = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.button_OK = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // button_Cancel
      // 
      this.button_Cancel.Location = new System.Drawing.Point(440, 103);
      this.button_Cancel.Name = "button_Cancel";
      this.button_Cancel.Size = new System.Drawing.Size(75, 23);
      this.button_Cancel.TabIndex = 1;
      this.button_Cancel.Text = "Cancel";
      this.button_Cancel.UseVisualStyleBackColor = true;
      this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
      // 
      // textBox_Folder
      // 
      this.textBox_Folder.Location = new System.Drawing.Point(90, 12);
      this.textBox_Folder.Name = "textBox_Folder";
      this.textBox_Folder.Size = new System.Drawing.Size(476, 22);
      this.textBox_Folder.TabIndex = 2;
      // 
      // button_Folder
      // 
      this.button_Folder.Location = new System.Drawing.Point(572, 12);
      this.button_Folder.Name = "button_Folder";
      this.button_Folder.Size = new System.Drawing.Size(26, 23);
      this.button_Folder.TabIndex = 3;
      this.button_Folder.Text = "...";
      this.button_Folder.UseVisualStyleBackColor = true;
      this.button_Folder.Click += new System.EventHandler(this.button_Folder_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 17);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 12);
      this.label1.TabIndex = 4;
      this.label1.Text = "Folder";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 5;
      this.label2.Text = "Interval";
      // 
      // comboBox_Interval
      // 
      this.comboBox_Interval.FormattingEnabled = true;
      this.comboBox_Interval.Items.AddRange(new object[] {
            "0",
            "10",
            "15",
            "30",
            "60",
            "120"});
      this.comboBox_Interval.Location = new System.Drawing.Point(90, 41);
      this.comboBox_Interval.Name = "comboBox_Interval";
      this.comboBox_Interval.Size = new System.Drawing.Size(121, 20);
      this.comboBox_Interval.TabIndex = 6;
      // 
      // comboBox_Loading
      // 
      this.comboBox_Loading.FormattingEnabled = true;
      this.comboBox_Loading.Items.AddRange(new object[] {
            "0",
            "10",
            "25",
            "50",
            "75",
            "100"});
      this.comboBox_Loading.Location = new System.Drawing.Point(90, 67);
      this.comboBox_Loading.Name = "comboBox_Loading";
      this.comboBox_Loading.Size = new System.Drawing.Size(121, 20);
      this.comboBox_Loading.TabIndex = 7;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 70);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(69, 12);
      this.label3.TabIndex = 8;
      this.label3.Text = "CPU Loading";
      // 
      // button_OK
      // 
      this.button_OK.Location = new System.Drawing.Point(523, 103);
      this.button_OK.Name = "button_OK";
      this.button_OK.Size = new System.Drawing.Size(75, 23);
      this.button_OK.TabIndex = 9;
      this.button_OK.Text = "OK";
      this.button_OK.UseVisualStyleBackColor = true;
      this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
      // 
      // AutoTrashForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(608, 138);
      this.Controls.Add(this.button_OK);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.comboBox_Loading);
      this.Controls.Add(this.comboBox_Interval);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button_Folder);
      this.Controls.Add(this.textBox_Folder);
      this.Controls.Add(this.button_Cancel);
      this.Name = "AutoTrashForm";
      this.Text = "AutoTrashForm";
      this.Load += new System.EventHandler(this.AutoTrashForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button_Cancel;
    private System.Windows.Forms.TextBox textBox_Folder;
    private System.Windows.Forms.Button button_Folder;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox comboBox_Interval;
    private System.Windows.Forms.ComboBox comboBox_Loading;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button button_OK;
  }
}