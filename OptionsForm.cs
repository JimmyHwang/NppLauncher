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
  public partial class OptionsForm : Form {
    public dynamic ConfigData;

    public OptionsForm () {
      InitializeComponent ();
    }

    public dynamic InitConfigData(dynamic Data) {
      ConfigData = Data;
      if (!isset (ConfigData, "RefreshNpp")) {
        ConfigData.RefreshNpp = false;
      }
      return ConfigData;
    }

    void Config2UI () {
      checkBox_RefreshNpp.Checked = ConfigData.RefreshNpp;
    }

    void UI2Config () {
      ConfigData.RefreshNpp = checkBox_RefreshNpp.Checked;
    }

    private void button_OK_Click (object sender, EventArgs e) {
      UI2Config ();
      this.DialogResult = DialogResult.OK;
      this.Close ();
    }

    private void button_Cancel_Click (object sender, EventArgs e) {
      this.DialogResult = DialogResult.Cancel;
      this.Close ();
    }

    private void OptionsForm_Load (object sender, EventArgs e) {
      Config2UI ();
    }
  }
}
