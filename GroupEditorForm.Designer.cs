﻿namespace NppLauncher {
  partial class GroupEditorForm {
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
      this.button_OK = new System.Windows.Forms.Button();
      this.button_Cancel = new System.Windows.Forms.Button();
      this.checkBox_Clone = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(65, 12);
      this.label1.TabIndex = 0;
      this.label1.Text = "Group Name";
      // 
      // textBox_Name
      // 
      this.textBox_Name.Location = new System.Drawing.Point(12, 28);
      this.textBox_Name.Name = "textBox_Name";
      this.textBox_Name.Size = new System.Drawing.Size(245, 22);
      this.textBox_Name.TabIndex = 1;
      // 
      // button_OK
      // 
      this.button_OK.Location = new System.Drawing.Point(182, 118);
      this.button_OK.Name = "button_OK";
      this.button_OK.Size = new System.Drawing.Size(75, 23);
      this.button_OK.TabIndex = 2;
      this.button_OK.Text = "OK";
      this.button_OK.UseVisualStyleBackColor = true;
      this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
      // 
      // button_Cancel
      // 
      this.button_Cancel.Location = new System.Drawing.Point(101, 118);
      this.button_Cancel.Name = "button_Cancel";
      this.button_Cancel.Size = new System.Drawing.Size(75, 23);
      this.button_Cancel.TabIndex = 3;
      this.button_Cancel.Text = "Cancel";
      this.button_Cancel.UseVisualStyleBackColor = true;
      this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
      // 
      // checkBox_Clone
      // 
      this.checkBox_Clone.AutoSize = true;
      this.checkBox_Clone.Location = new System.Drawing.Point(15, 56);
      this.checkBox_Clone.Name = "checkBox_Clone";
      this.checkBox_Clone.Size = new System.Drawing.Size(52, 16);
      this.checkBox_Clone.TabIndex = 4;
      this.checkBox_Clone.Text = "Clone";
      this.checkBox_Clone.UseVisualStyleBackColor = true;
      // 
      // GroupEditorForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(269, 153);
      this.Controls.Add(this.checkBox_Clone);
      this.Controls.Add(this.button_Cancel);
      this.Controls.Add(this.button_OK);
      this.Controls.Add(this.textBox_Name);
      this.Controls.Add(this.label1);
      this.Name = "GroupEditorForm";
      this.Text = "Group Editor";
      this.Load += new System.EventHandler(this.NewGroupDialog_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox_Name;
    private System.Windows.Forms.Button button_OK;
    private System.Windows.Forms.Button button_Cancel;
    private System.Windows.Forms.CheckBox checkBox_Clone;
  }
}