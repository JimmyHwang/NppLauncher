using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Dynamic;
using Microsoft.Win32;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using static DNA64.Library.Common;
using System.Collections;

namespace NppLauncher {
  public partial class Form1 : Form {

    private const int SW_HIDE = 0;        // ShowWindow
    private const int SW_NORMAL = 1;
    private const int SW_MAXIMIZE = 3;
    private const int SW_SHOWNOACTIVATE = 4;
    private const int SW_SHOW = 5;
    private const int SW_MINIMIZE = 6;
    private const int SW_RESTORE = 9;
    private const int SW_SHOWDEFAULT = 10;

    [DllImport ("user32.dll")]
    [return: MarshalAs (UnmanagedType.Bool)]
    static extern bool ShowWindow (IntPtr hWnd, int nCmdShow);
    [DllImport ("user32.dll")]
    static extern IntPtr GetForegroundWindow ();
    [DllImport ("user32.dll")]
    static extern int GetWindowText (IntPtr hWnd, StringBuilder text, int count);
    [DllImport ("user32.dll")]
    public static extern IntPtr GetWindowThreadProcessId (IntPtr hWnd, out uint ProcessId);

    bool NppFlag = false;
    string AppName;
    int Startup = 1;
    int DelayMinimize = 3;
    int Ticks = 0;
    uint NppPID = 0;
    Thread DeleteThread;
    static string DeleteFolder = "E:\\RemoveFolders";
    string ConfigFile;
    dynamic ConfigData;

    public Form1 () {
      AppName = System.Reflection.Assembly.GetExecutingAssembly ().GetName ().Name;
      InitializeComponent ();
    }

    void DeleteTimerEvent () {
      List<string> FolderList;
      string folder = "E:\\RemoveFolders";

      if (DeleteThread != null) {
        if (!DeleteThread.IsAlive) {
          DeleteThread = null;
        }
      }

      if (Directory.Exists (folder)) {
        FolderList = GetDirectories (folder, "*.*");
        if (FolderList.Count > 0) {
          if (DeleteThread == null) {
            DeleteThread = new Thread (DeleteThreadEntry);
            DeleteThread.Start ();
          }
        }
      }
    }

    private void timer1_Tick (object sender, EventArgs e) {
      bool exist;
      dynamic obj;
      bool refresh = false;

      try {
        //
        // Run Delete Timer Event()
        //
        if ((Ticks % 10) == 0) {
          DeleteTimerEvent ();
        }

        //
        // Force refresh Notepad++ for fix non-refresh area issue
        //
        if (ConfigData.RefreshNpp) {
          //
          // Identify Notepad++ be actived
          //
          obj = GetActiveWindow ();
          exist = obj.Title.IndexOf ("Notepad++") != -1;
          if (exist == true && NppPID != obj.PID) {
            refresh = true;
          }
          if (refresh) {
            ShowWindow (obj.Handle, SW_MINIMIZE);
            ShowWindow (obj.Handle, SW_RESTORE);
          }
          NppFlag = exist;
          NppPID = obj.PID;
        }
      } catch (Exception ex) {
        //Console.WriteLine("Error reading from {0}. Message = {1}", path, e.Message);
      }

      if (ConfigData.Minimize) {
        if (Startup == 1 && Ticks == DelayMinimize) {
          Startup = 0;
          HideApp ();
        }
      }

      Ticks++;
    }

    private bool GetStartupRegistry () {
      bool st = false;

      RegistryKey rk = Registry.CurrentUser.OpenSubKey ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
      string loc = (string)rk.GetValue (AppName);
      if (loc != null) {
        st = true;
      }

      return st;
    }

    private void SetStartupRegistry (bool sw) {
      RegistryKey rk = Registry.CurrentUser.OpenSubKey ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

      if (sw == true) {
        rk.SetValue (AppName, Application.ExecutablePath.ToString ());
      } else {
        rk.DeleteValue (AppName, false);
      }
    }

    void ExitApp () {
      SetStartupRegistry (checkBox_Startup.Checked);
      notifyIcon1.Icon = null;
      notifyIcon1.Dispose ();
      Application.DoEvents ();
      this.Close ();
      Application.Exit ();
    }

    void HideApp () {
      notifyIcon1.Text = AppName;
      notifyIcon1.BalloonTipTitle = "Minimize to Tray App";
      notifyIcon1.BalloonTipText = "You have successfully minimized your form.";
      notifyIcon1.Visible = true;
      notifyIcon1.ShowBalloonTip (500);
      this.Hide ();
    }

    void ShowApp () {
      this.Show ();
      this.WindowState = FormWindowState.Normal;
    }

    dynamic GetActiveWindow () {
      dynamic result = new ExpandoObject ();
      uint pid;

      const int nChars = 256;
      IntPtr handle;
      StringBuilder Buff = new StringBuilder (nChars);
      handle = GetForegroundWindow ();
      if (GetWindowText (handle, Buff, nChars) > 0) {
        GetWindowThreadProcessId (handle, out pid);
        //Process p = Process.GetProcessById((int)pid);
        //p.MainModule.FileName.Dump();
        result.Title = Buff.ToString ();
        result.Handle = handle;
        result.PID = pid;
      }
      return result;
    }

    private void button_Minimum_Click (object sender, EventArgs e) {
      HideApp ();
    }

    private void checkBox_Startup_CheckedChanged (object sender, EventArgs e) {
      SetStartupRegistry (checkBox_Startup.Checked);
    }

    void RefreshGroupToolStripMenu () {
      groupToolStripMenuItem.DropDownItems.Clear ();
      var glist = (IDictionary<string, object>)ConfigData.Group;
      var glist2 = new Dictionary<string, object> (glist); // WORKAROUND for glists.Keys.Contains() always return true even key removed
      foreach (KeyValuePair<string, object> kvp in glist) {
        groupToolStripMenuItem.DropDownItems.Add (kvp.Key, null, groupToolStripMenuItem_Click);
      }
    }

    void RefreshComboBoxGroup () {
      var current = comboBox_Group.Text;
      comboBox_Group.Items.Clear ();
      var glist = (IDictionary<string, object>)ConfigData.Group;
      var glist2 = new Dictionary<string, object> (glist); // WORKAROUND for glists.Keys.Contains() always return true even key removed
      foreach (KeyValuePair<string, object> kvp in glist) {
        comboBox_Group.Items.Add (kvp.Key);
      }
      if (current != "" && glist2.ContainsKey (current)) {
        comboBox_Group.Text = current;
      } else if (comboBox_Group.Items.Count > 0) {
        comboBox_Group.SelectedIndex = 0;
      } else {
        comboBox_Group.Text = "";
      }
    }

    void RefreshListviewApps () {
      object value;
      if (comboBox_Group.Text != "") {
        var glist = (IDictionary<string, object>)ConfigData.Group;
        var result = glist.TryGetValue (comboBox_Group.Text, out value);
        List<dynamic> apps = (List<dynamic>)value;
        listView_Apps.Items.Clear ();
        foreach (dynamic app in apps) {
          if (!isset (app, "Args")) {
            app.Args = "";
          }
          var item = new ListViewItem ();
          item.Text = app.Name;
          item.SubItems.Add (app.Target);
          item.SubItems.Add (app.Args);
          listView_Apps.Items.Add (item);
        }
      }
    }

    void Config2UI () {
      if (!isset (ConfigData, "Startup")) {
        ConfigData.Startup = false;
      }
      if (!isset (ConfigData, "Minimize")) {
        ConfigData.Minimize = false;
      }
      checkBox_Startup.Checked = ConfigData.Startup;
      checkBox_Minimize.Checked = ConfigData.Minimize;
      //
      // Set comboBox_Group
      //
      if (!isset (ConfigData, "Group")) {
        ConfigData.Group = new ExpandoObject () as IDictionary<string, object>;
      }
      RefreshComboBoxGroup ();
      RefreshGroupToolStripMenu ();
      if (isset (ConfigData, "DefaultGroup")) {
        var group_name = ConfigData.DefaultGroup;
        var gdict = (IDictionary<string, object>)ConfigData.Group;
        object value;
        bool st = gdict.TryGetValue (group_name, out value);
        if (st) {
          comboBox_Group.Text = group_name;
        }
      }
      RefreshListviewApps ();
    }

    void UI2Config () {
      ConfigData.Minimize = checkBox_Minimize.Checked;
      ConfigData.Startup = checkBox_Startup.Checked;
      ConfigData.DefaultGroup = comboBox_Group.Text;
    }

    private void Form1_Load (object sender, EventArgs e) {
      timer1.Enabled = true;
      checkBox_Startup.Checked = GetStartupRegistry ();
      //
      // Generate config file name
      //
      ConfigFile = System.Reflection.Assembly.GetEntryAssembly ().Location;
      ConfigFile = ConfigFile.Replace (".exe", ".cfg");
      //
      // Read Config File
      //
      if (File.Exists (ConfigFile)) {
        string json_data = File.ReadAllText (ConfigFile);
        ConfigData = json_decode (json_data);
      } else {
        ConfigData = new ExpandoObject ();
      }
      Config2UI ();
      //
      // Initialize config data in OptionsForm
      //
      var form = new OptionsForm ();
      ConfigData = form.InitConfigData (ConfigData);
    }

    void SaveAllConfig () {
      UI2Config ();
      //
      // Write setting to Config file
      //
      string json_data = json_encode (ConfigData);
      File.WriteAllText (@ConfigFile, json_data);
    }

    private void Form1_FormClosing (object sender, FormClosingEventArgs e) {
      SaveAllConfig ();
    }

    private void notifyIcon1_Click (object sender, EventArgs e) {
      contextMenuStrip1.Show (Cursor.Position);
    }

    private void showWindowToolStripMenuItem_Click (object sender, EventArgs e) {
      ShowApp ();
    }

    private void exitToolStripMenuItem_Click (object sender, EventArgs e) {
      ExitApp ();
    }

    static dynamic RunProgram (string folder, string cmds, string args) {
      dynamic result = new ExpandoObject ();

      Process process = new Process ();
      //Directory.SetCurrentDirectory (folder);
      process.StartInfo.WorkingDirectory = folder;
      process.StartInfo.FileName = cmds;
      process.StartInfo.Arguments = args;
      // Do you want to show a console window?
      process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
      process.StartInfo.CreateNoWindow = true;
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.RedirectStandardOutput = true;
      process.StartInfo.RedirectStandardError = true;
      process.Start ();
      //* Read the output (or the error)
      string output = process.StandardOutput.ReadToEnd ();
      result.Output = output;
      string err = process.StandardError.ReadToEnd ();
      result.Error = err;
      process.WaitForExit ();

      return result;
    }

    static void DeleteThreadEntry () {
      RunProgram (DeleteFolder, "python", "delall.py");
    }

    private void checkRemoveFoldersToolStripMenuItem_Click (object sender, EventArgs e) {
      if (!DeleteThread.IsAlive) {
        DeleteThread = new Thread (DeleteThreadEntry);
        DeleteThread.Start ();
      }
    }

    private List<string> GetDirectories (string path, string searchPattern) {
      string[] DirArray;
      List<string> myCollection = new List<string> ();

      try {
        DirArray = Directory.GetDirectories (path, searchPattern, SearchOption.TopDirectoryOnly);
        myCollection = new List<string> (DirArray);
      } catch (Exception e) {
        Console.WriteLine ("The process failed: {0}", e.ToString ());
      }

      return myCollection;
    }

    private void runDelallpyToolStripMenuItem_Click (object sender, EventArgs e) {
      dynamic result;

      result = RunProgram ("E:\\RemoveFolders", "python", "delall_.py");
      Console.WriteLine (result.Output);
    }

    private void listFoldersToolStripMenuItem_Click (object sender, EventArgs e) {
      List<string> FolderList;

      FolderList = GetDirectories ("E:\\RemoveFolders", "*.*");
      Console.WriteLine (String.Join (", ", FolderList.ToArray ()));
      Console.WriteLine (FolderList.Count);

    }

    private void button_AddGroup_Click (object sender, EventArgs e) {
      var Form = new GroupEditorForm ();
      Form.Data = "";
      var result = Form.ShowDialog ();
      if (result == DialogResult.OK) {
        string Data = Form.Data;
        if (comboBox_Group.Items.Contains (Data)) {
          MessageBox.Show ("Data already exists", "ERROR");
        } else {
          comboBox_Group.Items.Add (Data);
          var gdict = (IDictionary<string, object>)ConfigData.Group;
          var empty_array = new List<System.Object> { };
          gdict.Add (Data, empty_array);
        }
        RefreshGroupToolStripMenu ();
      }
    }

    private void comboBox_Group_SelectedValueChanged (object sender, EventArgs e) {
      RefreshListviewApps ();
    }

    private void button_DelGroup_Click (object sender, EventArgs e) {
      var Data = comboBox_Group.Text;

      var gdict = (IDictionary<string, object>)ConfigData.Group;
      if (gdict.Keys.Contains (Data)) {
        gdict.Remove (Data);
        RefreshComboBoxGroup ();
        RefreshGroupToolStripMenu ();
      }
    }

    void AppAdd () {
      dynamic app = null;
      var group_name = comboBox_Group.Text;
      if (listView_Apps.SelectedItems.Count > 0) {
        var item = listView_Apps.SelectedItems[0];
        var app_name = item.Text;
        app = GetAppObject (group_name, app_name);
        if (!isset (app, "Args")) {
          app.Args = "";
        }
      }

      var Form = new AppEditorForm ();
      if (app == null) {
        Form.Name_ = "";
        Form.Target = "";
        Form.Args = "";
      } else {
        Form.Name_ = app.Name;
        Form.Target = app.Target;
        Form.Args = app.Args;
      }
      var result = Form.ShowDialog ();
      if (result == DialogResult.OK) {
        string Name = Form.Name_;
        string Target = Form.Target;
        string Args = Form.Args;
        var match_item = listView_Apps.FindItemWithText (Name);
        if (match_item == null) { // Add if not found
          //
          // Add to UI
          //
          ListViewItem item = new ListViewItem (Name);
          item.SubItems.Add (Form.Target);
          item.SubItems.Add (Form.Args);
          listView_Apps.Items.Add (item);
          //
          // Add to Config
          //
          string gname = comboBox_Group.Text;
          object value;
          bool st;
          var gdict = (IDictionary<string, object>)ConfigData.Group;
          st = gdict.TryGetValue (gname, out value);
          List<dynamic> apps = (List<dynamic>)value;
          dynamic app_obj = new ExpandoObject ();
          app_obj.Name = Name;
          app_obj.Target = Target;
          apps.Add (app_obj);
        } else {
          MessageBox.Show ("Data already exists", "ERROR");
        }
      }
    }

    private void button_Add_Click (object sender, EventArgs e) {
      AppAdd ();
    }

    void AppRemove () {
      string gname = comboBox_Group.Text;
      if (listView_Apps.SelectedItems.Count > 0) {
        string aname = listView_Apps.SelectedItems[0].Text;
        //
        // Remove from UI
        //
        var match_item = listView_Apps.FindItemWithText (aname);
        listView_Apps.Items.Remove (match_item);
        //
        // Remove from Config
        //
        var gdict = (IDictionary<string, object>)ConfigData.Group;
        object value;
        if (gdict.TryGetValue (gname, out value)) {
          List<dynamic> apps = (List<dynamic>)value;
          foreach (dynamic app in apps) {
            if (app.Name == aname) {
              apps.Remove (app);
              break;
            }
          }
        }
      } else {
        MessageBox.Show ("No item be selected", "INFO");
      }
    }

    private void button_Remove_Click (object sender, EventArgs e) {
      AppRemove ();
    }

    private void button_EditGroup_Click (object sender, EventArgs e) {
      object value;
      var gname = comboBox_Group.Text;
      var form = new GroupEditorForm ();
      form.Data = gname;
      var result = form.ShowDialog ();
      if (result == DialogResult.OK) {
        string new_gname = form.Data;
        if (comboBox_Group.Items.Contains (gname)) {
          //
          // Update CnofigData
          //
          var gdict = (IDictionary<string, object>)ConfigData.Group;
          if (gdict.TryGetValue (gname, out value)) {
            gdict.Remove (gname);
            gdict[new_gname] = value;
          }
          //
          // Update UI
          //
          var index = comboBox_Group.Items.IndexOf (gname);
          comboBox_Group.Items[index] = new_gname;
        }
        RefreshGroupToolStripMenu ();
      }
    }

    void LaunchApplication (string app, string args) {
      ProcessStartInfo start = new ProcessStartInfo ();
      start.Arguments = args;
      start.FileName = app;
      start.WindowStyle = ProcessWindowStyle.Hidden;
      start.CreateNoWindow = true;
      Process proc = Process.Start (start);
      proc.WaitForInputIdle ();  // Waiting App initialize done for TextFX.dll twice issue
    }

    void LaunchGroup (string group_name) {
      object value;
      var gdict = (IDictionary<string, object>)ConfigData.Group;
      if (gdict.TryGetValue (group_name, out value)) {
        List<dynamic> apps = (List<dynamic>)value;
        foreach (dynamic app in apps) {
          LaunchApplication (app.Target, app.Args);
        }
      }
    }

    private void button_LanuchAll_Click (object sender, EventArgs e) {
      var group_name = comboBox_Group.Text;
      LaunchGroup (group_name);
    }

    void AppRun () {
      object value;
      var gname = comboBox_Group.Text;
      var item = listView_Apps.SelectedItems[0];
      var aname = item.Text;
      var gdict = (IDictionary<string, object>)ConfigData.Group;
      if (gdict.TryGetValue (gname, out value)) {
        List<dynamic> apps = (List<dynamic>)value;
        foreach (dynamic app in apps) {
          if (app.Name == aname) {
            LaunchApplication (app.Target, app.Args);
          }
        }
      }
    }

    private void listView_Apps_DoubleClick (object sender, EventArgs e) {
      AppRun ();
    }

    dynamic GetAppObject (string group_name, string app_name) {
      object value;
      var gdict = (IDictionary<string, object>)ConfigData.Group;
      bool st = gdict.TryGetValue (group_name, out value);
      List<dynamic> apps = (List<dynamic>)value;
      foreach (dynamic app in apps) {
        if (app.Name == app_name) {
          return app;
        }
      }
      return null;
    }

    void AppEdit () {
      var group_name = comboBox_Group.Text;
      var item = listView_Apps.SelectedItems[0];
      var app_name = item.Text;
      var app = GetAppObject (group_name, app_name);
      if (!isset (app, "Args")) {
        app.Args = "";
      }
      var Form = new AppEditorForm ();
      Form.Name_ = app.Name;
      Form.Target = app.Target;
      Form.Args = app.Args;
      var result = Form.ShowDialog ();
      if (result == DialogResult.OK) {
        app.Name = Form.Name_;
        app.Target = Form.Target;
        app.Args = Form.Args;
        //
        // Add to UI
        //
        item.SubItems[0].Text = app.Name;
        item.SubItems[1].Text = app.Target;
        item.SubItems[2].Text = app.Args;
      }
    }

    private void button_Edit_Click (object sender, EventArgs e) {
      AppEdit ();
    }

    private void exitToolStripMenuItem1_Click (object sender, EventArgs e) {
      Application.Exit ();
    }

    private void saveToolStripMenuItem_Click (object sender, EventArgs e) {
      SaveAllConfig ();
    }

    private void listView_Apps_MouseClick (object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Right) {
        if (listView_Apps.FocusedItem.Bounds.Contains (e.Location)) {
          contextMenuStrip_App.Show (Cursor.Position);
        }
      }
    }

    private void cloneToolStripMenuItem_Click (object sender, EventArgs e) {
      AppAdd ();
    }

    private void removeToolStripMenuItem_Click (object sender, EventArgs e) {
      AppRemove ();
    }

    private void editToolStripMenuItem1_Click (object sender, EventArgs e) {
      AppEdit ();
    }

    private void runToolStripMenuItem_Click (object sender, EventArgs e) {
      AppRun ();
    }

    private void groupToolStripMenuItem_Click (object sender, EventArgs e) {
      var clickedMenuItem = sender as ToolStripItem;
      var menuText = clickedMenuItem.Text;
      LaunchGroup (menuText);
    }

    private void optionsToolStripMenuItem_Click (object sender, EventArgs e) {
      var form = new OptionsForm ();
      form.ConfigData = ConfigData;
      var result = form.ShowDialog ();
      if (result == DialogResult.OK) {
        ConfigData = form.ConfigData;
      }
    }

  } // Form1
}
