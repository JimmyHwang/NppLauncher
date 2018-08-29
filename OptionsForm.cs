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
      if (!isset (ConfigData, "TrashFolders")) {
        ConfigData.TrashFolders = new List<System.Object> { };
      }

      return ConfigData;
    }

    void UpdateListViewTrashFolders () {
      List<dynamic> folders = (List<dynamic>)ConfigData.TrashFolders;
      listView_TrashFolders.Items.Clear ();
      int Index = 0;
      foreach (dynamic fitem in folders) {
        ListViewItem lvitem = new ListViewItem ();
        lvitem.Text = fitem.Folder;
        lvitem.SubItems.Add (fitem.Interval.ToString ());
        lvitem.SubItems.Add (fitem.Loading.ToString ());
        lvitem.Tag = Index;
        listView_TrashFolders.Items.Add (lvitem);
        Index++;
      }
    }

    void Config2UI () {
      checkBox_RefreshNpp.Checked = ConfigData.RefreshNpp;
      UpdateListViewTrashFolders ();
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

    private void button_AddFolder_Click (object sender, EventArgs e) {
      dynamic TrashFolder;
      var form = new AutoTrashForm ();
      form.InitConfigData ();
      var result = form.ShowDialog ();
      if (result == DialogResult.OK) {
        TrashFolder = form.ConfigData;
        ConfigData.TrashFolders.Add (TrashFolder);
        UpdateListViewTrashFolders ();
      }
    }

    dynamic GetFolderObject (int Index) {
      dynamic fobj = null;
      List<dynamic> folders = (List<dynamic>)ConfigData.TrashFolders;
      int Count = 0;
      foreach (dynamic folder in folders) {
        if (Count == Index) {
          fobj = folder;
        }
        Count++;
      }
      return fobj;
    }

    private void button_Edit_Click (object sender, EventArgs e) {
      int Index = -1;
      if (listView_TrashFolders.SelectedItems.Count > 0) {
        Index = (int)listView_TrashFolders.SelectedItems[0].Tag;
      }

      if (Index != -1) {
        dynamic fobj = GetFolderObject (Index);
        var form = new AutoTrashForm ();
        form.ConfigData = fobj;
        form.InitConfigData ();
        var result = form.ShowDialog ();
        if (result == DialogResult.OK) {
          fobj = form.ConfigData;
          UpdateListViewTrashFolders ();          
        }
      }
    }

    private void button_RemoveFolder_Click (object sender, EventArgs e) {
      int Index = -1;
      if (listView_TrashFolders.SelectedItems.Count > 0) {
        Index = (int)listView_TrashFolders.SelectedItems[0].Tag;
      }
      if (Index != -1 ) {
        //
        // Delete Item of UI
        //
        Index = (int)listView_TrashFolders.SelectedItems[0].Tag;
        listView_TrashFolders.Items.RemoveAt (Index);
        //
        // Delete Item of ConfigData
        //
        List<dynamic> folders = (List<dynamic>)ConfigData.TrashFolders;
        folders.RemoveAt (Index);
      }
    }
  }
}
