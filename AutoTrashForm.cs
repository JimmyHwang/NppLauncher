using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DNA64.Library.Common;

namespace NppLauncher {
  public partial class AutoTrashForm : Form {
    public dynamic ConfigData = new ExpandoObject ();
    
    public AutoTrashForm () {
      InitializeComponent ();
    }

    public void InitConfigData () {
      if (!isset (ConfigData, "Folder")) {
        ConfigData.Folder = "";
      }
      if (!isset (ConfigData, "Interval")) {
        ConfigData.Interval = "0";
      }
      if (!isset (ConfigData, "Loading")) {
        ConfigData.Loading = "0";
      }
    }

    void Config2UI () {
      InitConfigData ();
      textBox_Folder.Text = ConfigData.Folder;
      comboBox_Interval.Text = ConfigData.Interval;
      comboBox_Loading.Text = ConfigData.Loading;
    }

    void UI2Config () {
      ConfigData.Folder = textBox_Folder.Text;
      ConfigData.Interval = comboBox_Interval.Text;
      ConfigData.Loading = comboBox_Loading.Text;
    }

    private void button_Cancel_Click (object sender, EventArgs e) {
      this.DialogResult = DialogResult.Cancel;
      this.Close ();
    }

    private void AutoTrashForm_Load (object sender, EventArgs e) {
      Config2UI ();
    }

    private void button_OK_Click (object sender, EventArgs e) {
      UI2Config ();
      this.DialogResult = DialogResult.OK;
      this.Close ();
    }

    private void button_Folder_Click (object sender, EventArgs e) {      
      FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog ();
      if (folderBrowserDialog1.ShowDialog () == DialogResult.OK) {
        ConfigData.Folder = folderBrowserDialog1.SelectedPath;
        textBox_Folder.Text = ConfigData.Folder;
      }
    }
  }
}
