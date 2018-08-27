using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NppLauncher {
  public partial class AppEditorForm : Form {
    public string Name_;
    public string Target;
    public string Args;

    public AppEditorForm() {
      InitializeComponent();
    }
    void Config2UI() {
      textBox_Name.Text = Name_;
      textBox_Target.Text = Target;
      textBox_Args.Text = Args;
    }

    void UI2Config() {
      Name_ = textBox_Name.Text;
      Target = textBox_Target.Text;
      Args = textBox_Args.Text;
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
