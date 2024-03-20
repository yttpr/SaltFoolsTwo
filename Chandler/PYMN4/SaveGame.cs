// Decompiled with JetBrains decompiler
// Type: PYMN4.SaveGame
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace PYMN4
{
  public static class SaveGame
  {
    public const string ModID = "SaltMoon";
    public const string FileName = "GameData";
    public static Dictionary<string, bool> SaveConfigNames;

    private static string baseSave => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") + "\\ItsTheMaceo\\BrutalOrchestra\\";

    private static string pathPlus
    {
      get
      {
        if (!Directory.Exists(SaveGame.baseSave + "Mods\\"))
          Directory.CreateDirectory(SaveGame.baseSave + "Mods\\");
        return SaveGame.baseSave + "Mods\\";
      }
    }

    public static string SavePath
    {
      get
      {
        if (!Directory.Exists(SaveGame.pathPlus + "SaltMoon\\"))
          Directory.CreateDirectory(SaveGame.pathPlus + "SaltMoon\\");
        return SaveGame.pathPlus + "SaltMoon\\";
      }
    }

    public static string SaveName
    {
      get
      {
        if (!File.Exists(SaveGame.SavePath + "GameData.config"))
          SaveGame.WriteConfig(SaveGame.SavePath + "GameData.config");
        return SaveGame.SavePath + "GameData.config";
      }
    }

    public static void WriteConfig(string location)
    {
      StreamWriter text = File.CreateText(location);
      XmlDocument xmlDocument = new XmlDocument();
      string str = "<config";
      foreach (string key in SaveGame.SaveConfigNames.Keys)
      {
        str += " ";
        str += key;
        str += "='";
        str += SaveGame.SaveConfigNames[key].ToString().ToLower();
        str += "'";
      }
      string xml = str + "> </config>";
      xmlDocument.LoadXml(xml);
      xmlDocument.Save((TextWriter) text);
      text.Close();
    }

    public static bool Check(string name)
    {
      if (SaveGame.SaveConfigNames == null)
        SaveGame.SaveConfigNames = new Dictionary<string, bool>();
      string saveName = SaveGame.SaveName;
      bool flag = false;
      FileStream inStream = File.Open(SaveGame.SaveName, FileMode.Open);
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load((Stream) inStream);
      if (xmlDocument.GetElementsByTagName("config").Count > 0)
      {
        if (xmlDocument.GetElementsByTagName("config")[0].Attributes[name] != null)
          flag = bool.Parse(xmlDocument.GetElementsByTagName("config")[0].Attributes[name].Value);
        if (!SaveGame.SaveConfigNames.Keys.Contains<string>(name))
          SaveGame.SaveConfigNames.Add(name, flag);
        else
          SaveGame.SaveConfigNames[name] = flag;
      }
      inStream.Close();
      return flag;
    }

    public static void Set(string name, bool value)
    {
      if (SaveGame.Check(name) == value)
        return;
      SaveGame.SaveConfigNames[name] = value;
      SaveGame.WriteConfig(SaveGame.SaveName);
      if (value)
      {
        if (name == "MoonAchieve")
          Unlock.Moon();
        else if (name == "MewAchieve")
          Unlock.Bartholomew();
        else if (name == "SalineAchieve")
          Unlock.Saline();
        else if (name == "EstherAchieve")
          Unlock.Esther();
        else if (name == "BolaAchieve")
          Unlock.Bola();
      }
    }

    public static void Setup()
    {
      SaveGame.Check("MoonUnlocked");
      SaveGame.Check("MoonStarted");
      SaveGame.Check("MoonForceUnlocked");
      SaveGame.Check("MewUnlocked");
      SaveGame.Check("MewForceUnlocked");
      SaveGame.Check("SalineUnlocked");
      SaveGame.Check("SalineStarted");
      SaveGame.Check("SalineForceUnlocked");
      SaveGame.Check("EstherUnlocked");
      SaveGame.Check("EstherStarted");
      SaveGame.Check("EstherForceUnlocked");
      SaveGame.Check("BolaUnlocked");
      SaveGame.Check("BolaStarted");
      SaveGame.Check("BolaForceUnlocked");
      SaveGame.Check("MoonAchieve");
      SaveGame.Check("MewAchieve");
      SaveGame.Check("SalineAchieve");
      SaveGame.Check("EstherAchieve");
      SaveGame.Check("BolaAchieve");
    }
  }
}
