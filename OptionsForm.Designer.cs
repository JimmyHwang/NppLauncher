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
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
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
      this.tabPage3.Controls.Add(this.textBox1);
      this.tabPage3.Controls.Add(this.label2);
      this.tabPage3.Controls.Add(this.label1);
      this.tabPage3.Controls.Add(this.comboBox1);
      this.tabPage3.Location = new System.Drawing.Point(4, 22);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Size = new System.Drawing.Size(549, 258);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "Automation";
      this.tabPage3.UseVisualStyleBackColor = true;
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(81, 34);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(406, 22);
      this.textBox1.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(5, 37);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(72, 12);
      this.label2.TabIndex = 3;
      this.label2.Text = "Script location";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(5, 11);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(70, 12);
      this.label1.TabIndex = 2;
      this.label1.Text = "Script interval";
      // 
      // comboBox1
      // 
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new System.Drawing.Point(81, 8);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(121, 20);
      this.comboBox1.TabIndex = 1;
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
      this.tabPage3.PerformLayout();
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
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox comboBox1;
  }
}