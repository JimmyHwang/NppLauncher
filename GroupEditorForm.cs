﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DNA64.Library.Common;

namespace NppBot {
  public partial class GroupEditorForm : Form {
    public string Data = "";

    public GroupEditorForm() {
      InitializeComponent();
    }

    void ConfigSetDefaultString(dynamic obj, string var, string data) {
      if (!isset(obj, var)) {
        //
        // Add default value into ExpandoObject
        //
        var dictionary = (IDictionary<string, object>)obj;
        dictionary.Add(var, data);
      }
    }

    void Config2UI() {      
      textBox_Name.Text = Data;
    }

    void UI2Config() {
      Data = textBox_Name.Text;
    }

    private void button_OK_Click(object sender, EventArgs e) {
      UI2Config();
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void button_Cancel_Click(object sender, EventArgs e) {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void NewGroupDialog_Load(object sender, EventArgs e) {
      //Data = "";
      Config2UI();
    }
  }
}
