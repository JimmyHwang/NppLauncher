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
using Newtonsoft.Json.Linq;

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
    bool comboBox_Group_Event_Enable = true;

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
    string ConfigFile;
    string ConfigBackupFile;
    dynamic ConfigData;
    static string PythonExecutionFile = "python.exe";
    
    public Form1 () {
      AppName = System.Reflection.Assembly.GetExecutingAssembly ().GetName ().Name;
      InitializeComponent();
    }

    //--------------------------------------------------------------------------
    // Delete Thread
    //--------------------------------------------------------------------------
    static dynamic ThreadConfigData;

    static void DeleteThreadEntry () {
      string script;
      List<dynamic> folders = (List<dynamic>)ThreadConfigData.TrashFolders;
      foreach (dynamic fobj in folders) {
        if (Convert.ToInt32(fobj.Interval, 10) > 0) {
          if (Directory.Exists (fobj.Folder)) {
            script = Path.Combine (fobj.Folder, "delall.py");
            if (File.Exists (script)) {
              RunProgram (fobj.Folder, PythonExecutionFile, "delall.py");
            } else {
              DeleteAll (fobj.Folder);
            }
          }
        }
      }
    }

    void DeleteTimerEvent () {
      if (DeleteThread != null) {
        if (!DeleteThread.IsAlive) {
          DeleteThread = null;
        }
      }
          
      if (DeleteThread == null) {
        ThreadConfigData = DeepCopy (ConfigData);
        DeleteThread = new Thread (DeleteThreadEntry);
        DeleteThread.Start ();
      }
    }
    
    //--------------------------------------------------------------------------
    // Timer
    //--------------------------------------------------------------------------
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

      if ((bool)ConfigData.Minimize) {
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

    string LocatePythonExecuteFile() {
      string value = null;
      var folder = LocatePythonPath();
      if (folder != null) {
        var python_file = Path.Combine(folder, "python.exe");
        if (File.Exists(python_file)) {
          value = python_file;
        }
      }

      return value;
    }

    string GetPythonPath(string locate) {
      var targetVersion = "";
      RegistryKey key;
      string Value = null;

      key = Registry.LocalMachine.OpenSubKey(locate);
      if (key == null) {
        return null;        
      }

      foreach (var ver in key.GetSubKeyNames()) {
        targetVersion = ver;
      }

      if (targetVersion != "") {
        key = key.OpenSubKey(targetVersion + @"\InstallPath");
        if (key == null) {
          return null;
        }
        var InstallPath = key.GetValue("");
        if (InstallPath != null) {
          Value = InstallPath.ToString();
        }
      }

      return Value;
    }
    
    string LocatePythonPath() {      
      string Value = null;

      Value = GetPythonPath(@"SOFTWARE\Wow6432Node\Python\PythonCore");
      if (Value == null) {
        Value = GetPythonPath(@"SOFTWARE\Python\PythonCore");
      }

      return Value;
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
      var glist = ConfigData.Group;
      foreach (JProperty prop in glist.Properties()) {
        groupToolStripMenuItem.DropDownItems.Add (prop.Name, null, groupToolStripMenuItem_Click);
      }
    }

    void RefreshComboBoxGroup () {
      var current = comboBox_Group.Text;
      comboBox_Group.Items.Clear ();
      var glist = ConfigData.Group;
      foreach (JProperty prop in glist.Properties()) {
        comboBox_Group.Items.Add(prop.Name);
      }
      if (current != "" && glist.ContainsKey (current)) {
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
        var glist = ConfigData.Group;
        if (glist.ContainsKey(comboBox_Group.Text)) {
          var apps = glist[comboBox_Group.Text];          
          listView_Apps.Items.Clear();
          foreach (dynamic app in apps) {
            if (!app.ContainsKey("Args")) {
              app.Args = "";
            }
            var item = new ListViewItem();
            item.Text = app.Name;
            item.SubItems.Add((string)app.Target);
            item.SubItems.Add((string)app.Args);
            listView_Apps.Items.Add(item);
          }
        }        
      }
    }

    void Config2UI () {
      if (!ConfigData.ContainsKey("Startup")) {
        ConfigData.Startup = false;
      }
      if (!ConfigData.ContainsKey("Minimize")) {
        ConfigData.Minimize = false;
      }
      checkBox_Startup.Checked = ConfigData.Startup;
      checkBox_Minimize.Checked = ConfigData.Minimize;
      //
      // Set comboBox_Group
      //
      if (!ConfigData.ContainsKey("Group")) {
        ConfigData.Group = new JObject();
      }
      RefreshComboBoxGroup ();
      RefreshGroupToolStripMenu ();
      if (ConfigData.ContainsKey("DefaultGroup")) {
        string group_name = ConfigData.DefaultGroup;
        var glist = ConfigData.Group;
        object value;
        if (glist.ContainsKey(group_name)) {
          value = glist.group_name;
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
      //
      // Locate python path
      //
      var python = LocatePythonExecuteFile();
      if (python != null) {
        PythonExecutionFile = python;
      }
      //
      // Enable timer
      //
      timer1.Enabled = true;
      checkBox_Startup.Checked = GetStartupRegistry ();
      //
      // Generate config file name
      //
      ConfigFile = System.Reflection.Assembly.GetEntryAssembly ().Location;
      ConfigFile = ConfigFile.Replace (".exe", ".cfg");
      ConfigBackupFile = ConfigFile + "_backup";
      //
      // Read Config File
      //
      if (File.Exists (ConfigFile)) {
        string json_data = File.ReadAllText (ConfigFile);
        try {
          ConfigData = json_decode(json_data);          
          File.WriteAllText(ConfigBackupFile, json_data);
        } catch (Exception ex) {
          if (File.Exists(ConfigBackupFile)) {
            json_data = File.ReadAllText(ConfigBackupFile);
            ConfigData = json_decode(json_data);
          } else {
            ConfigData = new JObject {};
          }
        }        
      } else {
        ConfigData = new JObject();
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
          var glist = ConfigData.Group;
          glist[Data] = new JArray();
        }
        RefreshGroupToolStripMenu ();
      }
    }

    private void comboBox_Group_SelectedValueChanged (object sender, EventArgs e) {
      if (comboBox_Group_Event_Enable == true) {
        RefreshListviewApps();
      }      
    }

    private void button_DelGroup_Click (object sender, EventArgs e) {
      var gname = comboBox_Group.Text;

      var glist = ConfigData.Group;
      if (glist.ContainsKey(gname)) {
        glist.Remove(gname);
        RefreshComboBoxGroup ();
        RefreshGroupToolStripMenu ();
      }
    }

    void AppAdd () {
      dynamic app = new ExpandoObject();
      var group_name = comboBox_Group.Text;
      if (listView_Apps.SelectedItems.Count > 0) {
        var item = listView_Apps.SelectedItems[0];
        var app_name = item.Text;
        app = GetAppObject (group_name, app_name);
        app = DeepCopy (app);
      }

      var Form = new AppEditorForm ();
      Form.ConfigData = app;
      var result = Form.ShowDialog ();
      if (result == DialogResult.OK) {
        app = Form.ConfigData;
        var match_item = listView_Apps.FindItemWithText (app.Name);
        if (match_item == null) { // Add if not found
          //
          // Add to UI
          //
          ListViewItem item = new ListViewItem (app.Name);
          item.SubItems.Add (app.Target);
          item.SubItems.Add (app.Args);
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
          apps.Add (app);
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
        foreach(dynamic list_item in listView_Apps.SelectedItems) {
          string aname = list_item.Text;
          //
          // Remove from UI
          //
          var match_item = listView_Apps.FindItemWithText(aname);
          listView_Apps.Items.Remove(match_item);
          //
          // Remove from Config
          //
          var glist = ConfigData.Group;
          if (glist.ContainsKey(gname)) {
            var apps = glist[gname];
            foreach (dynamic app in apps) {
              if (app.Name == aname) {
                apps.Remove(app);
                break;
              }
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
            if (form.CloneFlag == false) {
              gdict.Remove(gname);
              gdict[new_gname] = value;
            } else {
              gdict[new_gname] = CloneObject(value);
            }            
          }
          //
          // Update UI
          //
          comboBox_Group_Event_Enable = false;
          var index = comboBox_Group.Items.IndexOf (gname);
          if (form.CloneFlag == false) {
            comboBox_Group.Items[index] = new_gname;
          } else {
            comboBox_Group.Items.Add(new_gname);
          }
          comboBox_Group_Event_Enable = true;
        }
        RefreshComboBoxGroup();
        RefreshGroupToolStripMenu ();
      }
    }

    void LaunchApplication (dynamic app) {
      //
      // Set default data for leak fields of ConfigData
      //
      var form = new AppEditorForm ();
      form.ConfigData = app;
      form.InitConfigData ();
      app = form.ConfigData;
      //
      // Pre-Exec commands
      //
      if (app.PreExec != "") {
        ProcessStartInfo pre_exec = new ProcessStartInfo();
        pre_exec.FileName = "cmd.exe";
        pre_exec.Arguments = "/C "+app.PreExec;
        pre_exec.CreateNoWindow = true;
        pre_exec.UseShellExecute = false;
        pre_exec.WindowStyle = ProcessWindowStyle.Hidden;
        pre_exec.CreateNoWindow = false;
        if (app.Folder != "") {
          pre_exec.WorkingDirectory = app.Folder;
        }
        Process proc = Process.Start(pre_exec);
        proc.WaitForExit();
      }
      //
      // Launch Application
      //
      ProcessStartInfo start = new ProcessStartInfo ();
      start.Arguments = app.Args;
      if (File.Exists((string)app.Target)) {
        start.FileName = app.Target;
        if (app.Folder != "") {
          start.WorkingDirectory = app.Folder;
        }
        switch (app.WindowMode) {
          case 0:
            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = false;
            break;
          case 1:
            start.WindowStyle = ProcessWindowStyle.Minimized;
            start.CreateNoWindow = false;
            break;
          case 2:
            start.WindowStyle = ProcessWindowStyle.Maximized;
            start.CreateNoWindow = false;
            break;
          default:
            start.WindowStyle = ProcessWindowStyle.Normal;
            start.CreateNoWindow = true;
            break;
        }

        Process proc = Process.Start (start);
        if (app.WaitMode == 0) {
          try {
            proc.WaitForInputIdle ();  // Waiting App initialize done for TextFX.dll twice issue
          } catch (Exception e) {
            MessageBox.Show ("Exception for WaitForInputIdle()\n Try use <don't wait>");
          }
        }
      } else {        
        MessageBox.Show ("Error: Target not exists ["+app.Target+"]", "ERROR");
      }
    }

    void LaunchGroup (string group_name) {
      var glist = ConfigData.Group;
      if (glist.ContainsKey(group_name)) {
        var apps = glist[group_name];
        foreach (dynamic app in apps) {
          LaunchApplication (app);
        }
      }
    }

    private void button_LanuchAll_Click (object sender, EventArgs e) {
      var group_name = comboBox_Group.Text;
      LaunchGroup (group_name);
    }

    void AppRun () {
      var gname = comboBox_Group.Text;
      var item = listView_Apps.SelectedItems[0];
      var aname = item.Text;
      var glist = ConfigData.Group;
      if (glist.ContainsKey(gname)) {
        var apps = glist[gname];
        foreach (dynamic app in apps) {
          if (app.Name == aname) {
            LaunchApplication (app);
          }
        }
      }
    }

    private void listView_Apps_DoubleClick (object sender, EventArgs e) {
      AppRun ();
    }

    dynamic GetAppObject (string group_name, string app_name) {      
      var glist = ConfigData.Group;
      if (glist.ContainsKey(group_name)) {
        var apps = glist[group_name];
        foreach (dynamic app in apps) {
          if (app.Name == app_name) {
            return app;
          }
        }
      }
      return null;
    }

    void AppEdit () {
      var group_name = comboBox_Group.Text;
      if (listView_Apps.SelectedItems.Count > 0) {
        var item = listView_Apps.SelectedItems[0];
        var app_name = item.Text;
        var app = GetAppObject(group_name, app_name);
        var Form = new AppEditorForm();
        Form.ConfigData = app;
        var result = Form.ShowDialog();
        if (result == DialogResult.OK) {
            app = Form.ConfigData;
            //
            // Add to UI
            //
            item.SubItems[0].Text = app.Name;
            item.SubItems[1].Text = app.Target;
            item.SubItems[2].Text = app.Args;
        }
      } else {
        MessageBox.Show("SelectedItems not found", "ERROR");
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

    List<string> GetAllHDD() {
      DriveInfo[] allDrives = DriveInfo.GetDrives();
      List<string> HDDs = new List<string>();

      foreach (DriveInfo d in allDrives) {
        /*
        Console.WriteLine("Drive {0}", d.Name);
        Console.WriteLine("  Drive type: {0}", d.DriveType);
        if (d.IsReady == true) {
          Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
          Console.WriteLine("  File system: {0}", d.DriveFormat);
          Console.WriteLine(
              "  Available space to current user:{0, 15} bytes",
              d.AvailableFreeSpace);

          Console.WriteLine(
              "  Total available space:          {0, 15} bytes",
              d.TotalFreeSpace);

          Console.WriteLine(
              "  Total size of drive:            {0, 15} bytes ",
              d.TotalSize);
        }
        */
        if (d.DriveType.ToString() == "Fixed") {
          HDDs.Add(d.Name);
        }
      }

      return HDDs;
    }

    string GetNewName(JArray apps, string app_name) {
      string new_name = app_name;
      int i;
      bool found;

      for (i = 0; i < 100; i++) {
        if (i == 0) {
          new_name = app_name;
        } else {
          new_name = app_name + "_" + i;
        }
        found = false;
        foreach (dynamic app in apps) {
          if (app.Name == new_name) {
            found = true;
          }
        }
        if (found == false) {
          break;
        }
      }

      return new_name;
    }

    private void listView_Apps_KeyDown(object sender, KeyEventArgs e) {
      string jstr;
      dynamic export_data;
      dynamic import_data;
      string gname = comboBox_Group.Text;
      var glist = ConfigData.Group;
      JArray gapps = new JArray();

      if (glist.ContainsKey(gname)) {
        gapps = glist[gname];
      }
      //
      // Create export object
      //
      export_data = new JObject {};
      export_data.NppLauncher = new JArray ();
      if (e.Control && e.KeyCode == Keys.C) {
        e.SuppressKeyPress = true;
        if (listView_Apps.SelectedItems.Count > 0) {
          foreach (dynamic list_item in listView_Apps.SelectedItems) {
            string aname = list_item.Text;
            foreach (dynamic app in gapps) {
              if (app.Name == aname) {
                jstr = json_encode(app);
                export_data.NppLauncher.Add(app);
                break;
              }
            }
          }
          jstr = json_encode(export_data);
          Clipboard.SetText(jstr);
        } else {
          MessageBox.Show("No item be selected", "INFO");
        }
      } else if (e.Control && e.KeyCode == Keys.V) {
        e.SuppressKeyPress = true;
        string new_name;
        jstr = Clipboard.GetText();
        try {
          import_data = json_decode(jstr);
          foreach (dynamic app in import_data.NppLauncher) {
            new_name = GetNewName(gapps, (string)app.Name);
            dynamic new_app = json_decode(json_encode(app));
            new_app.Name = new_name;
            //
            // Add to UI
            //
            ListViewItem item = new ListViewItem((string)new_app.Name);
            item.SubItems.Add((string)new_app.Target);
            item.SubItems.Add((string)new_app.Args);
            listView_Apps.Items.Add(item);
            //
            // Add to Config
            //
            gapps.Add(new_app);
          }
        } catch {
          MessageBox.Show("Invalid data format for NppLauncher", "ERROR");
        }
      } else if (e.Control && e.KeyCode == Keys.A) {
        e.SuppressKeyPress = true;
        foreach (dynamic list_item in listView_Apps.Items) {
          list_item.Selected = true;
        }
      } else if (e.KeyCode == Keys.Delete) {
        e.SuppressKeyPress = true;
        AppRemove();
      }
    }
  } // Form1
}
