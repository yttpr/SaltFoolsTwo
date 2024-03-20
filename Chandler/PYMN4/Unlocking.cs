// Decompiled with JetBrains decompiler
// Type: PYMN4.Unlocking
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

namespace PYMN4
{
  public class Unlocking
  {
    public Unlocking(bool doQuest)
    {
      if (doQuest)
      {
        if (!SaveGame.Check("MoonAchieve") && BrutalAPI.BrutalAPI.moddedChars.Remove(LoadedAssetsHandler.GetCharcater("Moon_CH")))
          Debug.Log((object) "Moon Locked");
        if (!SaveGame.Check("MewAchieve") && BrutalAPI.BrutalAPI.moddedChars.Remove(LoadedAssetsHandler.GetCharcater("Bartholomew_CH")))
          Debug.Log((object) "Bartholomew Locked");
        if (!SaveGame.Check("SalineAchieve") && BrutalAPI.BrutalAPI.moddedChars.Remove(LoadedAssetsHandler.GetCharcater("Saline_CH")))
          Debug.Log((object) "Saline Locked");
        if (!SaveGame.Check("EstherAchieve") && BrutalAPI.BrutalAPI.moddedChars.Remove(LoadedAssetsHandler.GetCharcater("Esther_CH")))
          Debug.Log((object) "Esther Locked");
        if (!SaveGame.Check("BolaAchieve") && BrutalAPI.BrutalAPI.moddedChars.Remove(LoadedAssetsHandler.GetCharcater("Bola_CH")))
          Debug.Log((object) "Bola Locked");
        SaveGame.Set("MoonForceUnlocked", false);
        SaveGame.Set("MewForceUnlocked", false);
        SaveGame.Set("SalineForceUnlocked", false);
        SaveGame.Set("EstherForceUnlocked", false);
        SaveGame.Set("BolaForceUnlocked", false);
      }
      else
      {
        SaveGame.Set("MoonForceUnlocked", true);
        SaveGame.Set("MewForceUnlocked", true);
        SaveGame.Set("SalineForceUnlocked", true);
        SaveGame.Set("EstherForceUnlocked", true);
        SaveGame.Set("BolaForceUnlocked", true);
      }
    }

    public static bool DidCompleteQuest(
      Func<InGameDataSO, QuestIDs, bool> orig,
      InGameDataSO self,
      QuestIDs questName)
    {
      if (questName == (QuestIDs)327746)
        return SaveGame.Check("MoonAchieve") || SaveGame.Check("MoonForceUnlocked");
      if (questName == (QuestIDs)327747)
        return SaveGame.Check("MewAchieve") || SaveGame.Check("MewForceUnlocked");
      if (questName == (QuestIDs)327748)
        return SaveGame.Check("SalineAchieve") || SaveGame.Check("SalineForceUnlocked");
      if (questName == (QuestIDs)327749)
        return SaveGame.Check("EstherAchieve") || SaveGame.Check("EstherForceUnlocked");
      return questName == (QuestIDs)327750 ? SaveGame.Check("BolaAchieve") || SaveGame.Check("BolaForceUnlocked") : orig(self, questName);
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (InGameDataSO).GetMethod("DidCompleteQuest", ~BindingFlags.Default), typeof (Unlocking).GetMethod("DidCompleteQuest", ~BindingFlags.Default));
    }
  }
}
