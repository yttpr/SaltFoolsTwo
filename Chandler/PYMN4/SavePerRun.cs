// Decompiled with JetBrains decompiler
// Type: PYMN4.SavePerRun
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace PYMN4
{
  public static class SavePerRun
  {
    public const string ModID = "SaltMoon";
    public const string FileName = "RunData";
    public static Dictionary<string, bool> SaveConfigNames;
    public static int AllDeaths;

    private static string baseSave => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") + "\\ItsTheMaceo\\BrutalOrchestra\\";

    private static string pathPlus
    {
      get
      {
        if (!Directory.Exists(SavePerRun.baseSave + "Mods\\"))
          Directory.CreateDirectory(SavePerRun.baseSave + "Mods\\");
        return SavePerRun.baseSave + "Mods\\";
      }
    }

    public static string SavePath
    {
      get
      {
        if (!Directory.Exists(SavePerRun.pathPlus + "SaltMoon\\"))
          Directory.CreateDirectory(SavePerRun.pathPlus + "SaltMoon\\");
        return SavePerRun.pathPlus + "SaltMoon\\";
      }
    }

    public static string SaveName
    {
      get
      {
        if (!File.Exists(SavePerRun.SavePath + "RunData.config"))
          SavePerRun.WriteConfig(SavePerRun.SavePath + "RunData.config");
        return SavePerRun.SavePath + "RunData.config";
      }
    }

    public static void WriteConfig(string location)
    {
      StreamWriter text = File.CreateText(location);
      XmlDocument xmlDocument = new XmlDocument();
      string str = "<config" + " AllDeaths='" + SavePerRun.AllDeaths.ToString() + "'";
      foreach (string key in SavePerRun.SaveConfigNames.Keys)
      {
        str += " ";
        str += key;
        str += "='";
        str += SavePerRun.SaveConfigNames[key].ToString().ToLower();
        str += "'";
      }
      string xml = str + "> </config>";
      xmlDocument.LoadXml(xml);
      xmlDocument.Save((TextWriter) text);
      text.Close();
    }

    public static bool Check(string name)
    {
      if (SavePerRun.SaveConfigNames == null)
        SavePerRun.SaveConfigNames = new Dictionary<string, bool>();
      string saveName = SavePerRun.SaveName;
      bool flag = false;
      FileStream inStream = File.Open(SavePerRun.SaveName, FileMode.Open);
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load((Stream) inStream);
      if (xmlDocument.GetElementsByTagName("config").Count > 0)
      {
        if (xmlDocument.GetElementsByTagName("config")[0].Attributes[name] != null)
          flag = bool.Parse(xmlDocument.GetElementsByTagName("config")[0].Attributes[name].Value);
        if (!SavePerRun.SaveConfigNames.Keys.Contains<string>(name))
          SavePerRun.SaveConfigNames.Add(name, flag);
        else
          SavePerRun.SaveConfigNames[name] = flag;
      }
      inStream.Close();
      return flag;
    }

    public static void Set(string name, bool value)
    {
      if (SavePerRun.Check(name) == value)
        return;
      SavePerRun.SaveConfigNames[name] = value;
      SavePerRun.WriteConfig(SavePerRun.SaveName);
    }

    public static int DeathCount()
    {
      if (SavePerRun.SaveConfigNames == null)
        SavePerRun.SaveConfigNames = new Dictionary<string, bool>();
      string saveName = SavePerRun.SaveName;
      int num = 0;
      FileStream inStream = File.Open(SavePerRun.SaveName, FileMode.Open);
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load((Stream) inStream);
      if (xmlDocument.GetElementsByTagName("config").Count > 0 && xmlDocument.GetElementsByTagName("config")[0].Attributes["AllDeaths"] != null)
        num = int.Parse(xmlDocument.GetElementsByTagName("config")[0].Attributes["AllDeaths"].Value);
      inStream.Close();
      return num;
    }

    public static void IncreaseDeaths() => ++SavePerRun.AllDeaths;

    public static void OnEmbarkPressed(Action<MainMenuController> orig, MainMenuController self)
    {
      YarnMand.info = self._informationHolder;
      orig(self);
      List<string> stringList = new List<string>();
      foreach (string key in SavePerRun.SaveConfigNames.Keys)
        stringList.Add(key);
      foreach (string key in stringList)
        SavePerRun.SaveConfigNames[key] = false;
      SavePerRun.AllDeaths = 0;
      SavePerRun.WriteConfig(SavePerRun.SaveName);
    }

    public static void InitializeSelfNotifications(Action<CombatManager> orig, CombatManager self)
    {
      SavePerRun.WriteConfig(SavePerRun.SaveName);
      orig(self);
    }

    public static IEnumerator ProcessNormalCombatEnd(
      Func<CombatManager, IEnumerator> orig,
      CombatManager self)
    {
      IEnumerator enumerator = orig(self);
      SavePerRun.WriteConfig(SavePerRun.SaveName);
      return enumerator;
    }

    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (MainMenuController).GetMethod("OnEmbarkPressed", ~BindingFlags.Default), typeof (SavePerRun).GetMethod("OnEmbarkPressed", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (CombatManager).GetMethod("InitializeSelfNotifications", ~BindingFlags.Default), typeof (SavePerRun).GetMethod("InitializeSelfNotifications", ~BindingFlags.Default));
      IDetour idetour3 = (IDetour) new Hook((MethodBase) typeof (CombatManager).GetMethod("ProcessNormalCombatEnd", ~BindingFlags.Default), typeof (SavePerRun).GetMethod("ProcessNormalCombatEnd", ~BindingFlags.Default));
      SavePerRun.DeathCount();
    }
  }
}
