﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using Newtonsoft.Json;
using System.Collections.Specialized;
using Newtonsoft.Json.Converters;

namespace DNA64.Library {
  public static class Common {
    public static dynamic json_decode(string data) {
      return JsonConvert.DeserializeObject<ExpandoObject>(data, new ExpandoObjectConverter());
    }

    public static string json_encode(dynamic data) {
      return JsonConvert.SerializeObject (data, Formatting.Indented);
    }

    public static bool isset(dynamic settings, string name) {
      if (settings is ExpandoObject) {
        return ((IDictionary<string, object>)settings).ContainsKey(name);
      }
      return settings.GetType().GetProperty(name) != null;
    }

    public static ExpandoObject DeepCopy (ExpandoObject original) {
      var clone = new ExpandoObject ();

      var _original = (IDictionary<string, object>)original;
      var _clone = (IDictionary<string, object>)clone;

      foreach (var kvp in _original)
        _clone.Add (kvp.Key, kvp.Value is ExpandoObject ? DeepCopy ((ExpandoObject)kvp.Value) : kvp.Value);

      return clone;
    }

    public static void DeleteAll(string folder) {
      System.IO.DirectoryInfo di = new DirectoryInfo (folder);

      foreach (FileInfo file in di.GetFiles ()) {
        file.Delete ();
      }
      foreach (DirectoryInfo dir in di.GetDirectories ()) {
        dir.Delete (true);
      }
    }

    public static void Empty (this System.IO.DirectoryInfo directory) {
      foreach (System.IO.FileInfo file in directory.GetFiles ()) file.Delete ();
      foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories ()) subDirectory.Delete (true);
    }
    //System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo (@"C:\...");
    //directory.Empty();
  }
}