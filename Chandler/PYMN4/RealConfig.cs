// Decompiled with JetBrains decompiler
// Type: PYMN4.RealConfig
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BepInEx;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace PYMN4
{
  public static class RealConfig
  {
    public const bool QuestsDefault = true;
    public const string ModID = "SaltMoon";
    public const string FileName = "SaltFools2Config";
    public static Dictionary<string, bool> SaveConfigNames;

    private static string baseSave => Paths.BepInExRootPath + "\\plugins\\";

    private static string pathPlus
    {
      get
      {
        if (!Directory.Exists(RealConfig.baseSave + "SaltFools2\\"))
          Directory.CreateDirectory(RealConfig.baseSave + "SaltFools2\\");
        return RealConfig.baseSave + "SaltFools2\\";
      }
    }

    public static string SavePath => RealConfig.pathPlus;

    public static string SaveName
    {
      get
      {
        if (!File.Exists(RealConfig.SavePath + "SaltFools2Config.config"))
          RealConfig.WriteConfig(RealConfig.SavePath + "SaltFools2Config.config");
        return RealConfig.SavePath + "SaltFools2Config.config";
      }
    }

    public static void WriteConfig(string location)
    {
      StreamWriter text = File.CreateText(location);
      XmlDocument xmlDocument = new XmlDocument();
      string str = "<config";
      foreach (string key in RealConfig.SaveConfigNames.Keys)
      {
        str += " ";
        str += key;
        str += "='";
        str += RealConfig.SaveConfigNames[key].ToString().ToLower();
        str += "'";
      }
      string xml = str + "> </config>";
      xmlDocument.LoadXml(xml);
      xmlDocument.Save((TextWriter) text);
      text.Close();
    }

    public static bool Check(string name)
    {
      if (RealConfig.SaveConfigNames == null)
        RealConfig.SaveConfigNames = new Dictionary<string, bool>();
      string saveName = RealConfig.SaveName;
      bool flag = true;
      FileStream inStream = File.Open(RealConfig.SaveName, FileMode.Open);
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load((Stream) inStream);
      if (xmlDocument.GetElementsByTagName("config").Count > 0)
      {
        if (xmlDocument.GetElementsByTagName("config")[0].Attributes[name] != null)
          flag = bool.Parse(xmlDocument.GetElementsByTagName("config")[0].Attributes[name].Value);
        if (!RealConfig.SaveConfigNames.Keys.Contains<string>(name))
          RealConfig.SaveConfigNames.Add(name, flag);
        else
          RealConfig.SaveConfigNames[name] = flag;
      }
      inStream.Close();
      return flag;
    }

    public static void Set(string name, bool value)
    {
      if (RealConfig.Check(name) == value)
        return;
      RealConfig.SaveConfigNames[name] = value;
      RealConfig.WriteConfig(RealConfig.SaveName);
    }

    public static void Setup()
    {
      RealConfig.Check("DoQuests");
      RealConfig.WriteConfig(RealConfig.SaveName);
    }
  }
}
