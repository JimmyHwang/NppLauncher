using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DNA64.Library.Common;

namespace NppLauncher {
  public partial class AppEditorForm : Form {
    public dynamic ConfigData;

    public AppEditorForm() {
      InitializeComponent();
    }

    public void InitConfigData() {
      if (!isset (ConfigData, "Name")) {
        ConfigData.Name = "";
      }
      if (!isset (ConfigData, "Target")) {
        ConfigData.Target = "";
      }
      if (!isset (ConfigData, "Args")) {
        ConfigData.Args = "";
      }
      if (!isset (ConfigData, "WindowMode")) {
        ConfigData.WindowMode = 0;
      } 
      if (!isset (ConfigData, "WaitMode")) {
        ConfigData.WaitMode = 0;
      }
    }

    void Config2UI() {
      InitConfigData ();
      comboBox_WindowMode.SelectedIndex = (int)ConfigData.WindowMode;
      comboBox_WaitMode.SelectedIndex = (int)ConfigData.WaitMode;
      textBox_Name.Text = ConfigData.Name;
      textBox_Target.Text = ConfigData.Target;
      textBox_Args.Text = ConfigData.Args;
    }

    void UI2Config() {
      ConfigData.WindowMode = comboBox_WindowMode.SelectedIndex;
      ConfigData.WaitMode = comboBox_WaitMode.SelectedIndex;
      ConfigData.Name = textBox_Name.Text;
      ConfigData.Target = textBox_Target.Text;
      ConfigData.Args = textBox_Args.Text;
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

    private void AppEditorForm_Load(object sender, EventArgs e) {
      Config2UI();
    }
  }
}
