// Decompiled with JetBrains decompiler
// Type: PYMN4.Unlock
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;

namespace PYMN4
{
  public static class Unlock
  {
    public static bool cleared;
    public static UnlockablesManager unlockManager;
    public static InGameDataSO gameData;
    public static SaveDataHandler saveHandler;

    public static void Moon()
    {
      if (Unlock.gameData.TryUnlockCharacter("Moon_CH"))
      {
        Unlock.unlockManager._freshlyAcquiredCharacters.Add("Moon_CH");
        SaveManager.SaveFreshCharactersSaveData(Unlock.unlockManager._freshlyAcquiredCharacters);
      }
      FoolBossUnlockSystem.AchievementSystem.AchieveInfo Info;
      if (!FoolBossUnlockSystem.AchievementSystem.TryGetAchievement("Moon_CH", out Info))
        return;
      Info.SetValue(true);
    }

    public static void Bartholomew()
    {
      if (Unlock.gameData.TryUnlockCharacter("Bartholomew_CH"))
      {
        Unlock.unlockManager._freshlyAcquiredCharacters.Add("Bartholomew_CH");
        SaveManager.SaveFreshCharactersSaveData(Unlock.unlockManager._freshlyAcquiredCharacters);
      }
      FoolBossUnlockSystem.AchievementSystem.AchieveInfo Info;
      if (!FoolBossUnlockSystem.AchievementSystem.TryGetAchievement("Bartholomew_CH", out Info))
        return;
      Info.SetValue(true);
    }

    public static void Saline()
    {
      if (Unlock.gameData.TryUnlockCharacter("Saline_CH"))
      {
        Unlock.unlockManager._freshlyAcquiredCharacters.Add("Saline_CH");
        SaveManager.SaveFreshCharactersSaveData(Unlock.unlockManager._freshlyAcquiredCharacters);
      }
      FoolBossUnlockSystem.AchievementSystem.AchieveInfo Info;
      if (!FoolBossUnlockSystem.AchievementSystem.TryGetAchievement("Saline_CH", out Info))
        return;
      Info.SetValue(true);
    }

    public static void Esther()
    {
      if (Unlock.gameData.TryUnlockCharacter("Esther_CH"))
      {
        Unlock.unlockManager._freshlyAcquiredCharacters.Add("Esther_CH");
        SaveManager.SaveFreshCharactersSaveData(Unlock.unlockManager._freshlyAcquiredCharacters);
      }
      FoolBossUnlockSystem.AchievementSystem.AchieveInfo Info;
      if (!FoolBossUnlockSystem.AchievementSystem.TryGetAchievement("Esther_CH", out Info))
        return;
      Info.SetValue(true);
    }

    public static void Bola()
    {
      if (Unlock.gameData.TryUnlockCharacter("Bola_CH"))
      {
        Unlock.unlockManager._freshlyAcquiredCharacters.Add("Bola_CH");
        SaveManager.SaveFreshCharactersSaveData(Unlock.unlockManager._freshlyAcquiredCharacters);
      }
      FoolBossUnlockSystem.AchievementSystem.AchieveInfo Info;
      if (!FoolBossUnlockSystem.AchievementSystem.TryGetAchievement("Bola_CH", out Info))
        return;
      Info.SetValue(true);
    }

    public static void Initialization(
      Action<UnlockablesManager, InGameDataSO> orig,
      UnlockablesManager self,
      InGameDataSO game)
    {
      orig(self, game);
      Unlock.unlockManager = self;
      Unlock.gameData = game;
      if (Unlock.cleared)
        return;
      Unlock.cleared = true;
      Unlock.unlockManager._freshlyAcquiredCharacters.Clear();
      SaveManager.SaveFreshCharactersSaveData(Unlock.unlockManager._freshlyAcquiredCharacters);
    }

    public static void UnlockThings(Action<SaveDataHandler> orig, SaveDataHandler self)
    {
      orig(self);
      Unlock.saveHandler = self;
      if (SaveGame.Check("MoonAchieve"))
        self._game.TryUnlockCharacter("Moon_CH");
      else if (!SaveGame.Check("MoonForceUnlocked"))
        self._game.UnlockedCharacters.Remove("Moon_CH");
      if (SaveGame.Check("MewAchieve"))
        self._game.TryUnlockCharacter("Bartholomew_CH");
      else if (!SaveGame.Check("MewForceUnlocked"))
        self._game.UnlockedCharacters.Remove("Bartholomew_CH");
      if (SaveGame.Check("SalineAchieve"))
        self._game.TryUnlockCharacter("Saline_CH");
      else if (!SaveGame.Check("SalineForceUnlocked"))
        self._game.UnlockedCharacters.Remove("Saline_CH");
      if (SaveGame.Check("EstherAchieve"))
        self._game.TryUnlockCharacter("Esther_CH");
      else if (!SaveGame.Check("EstherForceUnlocked"))
        self._game.UnlockedCharacters.Remove("Esther_CH");
      if (SaveGame.Check("BolaAchieve"))
      {
        self._game.TryUnlockCharacter("Bola_CH");
      }
      else
      {
        if (SaveGame.Check("BolaForceUnlocked"))
          return;
        self._game.UnlockedCharacters.Remove("Bola_CH");
      }
    }

    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (SaveDataHandler).GetMethod("LoadSavedData", ~BindingFlags.Default), typeof (Unlock).GetMethod("UnlockThings", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (UnlockablesManager).GetMethod("Initialization", ~BindingFlags.Default), typeof (Unlock).GetMethod("Initialization", ~BindingFlags.Default));
      Unlock.Achievos();
    }

    public static void Achievos()
    {
      new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 327746, (AchievementUnlockType) 2, "The Arsonist", "Unlock Moon.", ResourceLoader.LoadSprite("FoolLobotomy.png", 32)).Prepare("Moon_CH").SetValue(SaveGame.Check("MoonAchieve"));
      new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 327747, (AchievementUnlockType) 2, "The Lingering", "Unlock Bartholomew.", ResourceLoader.LoadSprite("FoolStereosity.png", 32)).Prepare("Bartholomew_CH").SetValue(SaveGame.Check("MewAchieve"));
      new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 327748, (AchievementUnlockType) 2, "The Schizophrenic", "Unlock Saline.", ResourceLoader.LoadSprite("FoolAllergy.png", 32)).Prepare("Saline_CH").SetValue(SaveGame.Check("SalineAchieve"));
      new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 327749, (AchievementUnlockType) 2, "The Executioner", "Unlock Esther.", ResourceLoader.LoadSprite("FoolEllegy.png", 32)).Prepare("Esther_CH").SetValue(SaveGame.Check("EstherAchieve"));
      new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 327750, (AchievementUnlockType) 2, "The Trapper", "Unlock Bola.", ResourceLoader.LoadSprite("FoolPatiently.png", 32)).Prepare("Bola_CH").SetValue(SaveGame.Check("BolaAchieve"));
    }

    public static void AddToAPIBase()
    {
      if (SaveGame.Check("MoonAchieve") && !BrutalAPI.BrutalAPI.moddedChars.Contains(LoadedAssetsHandler.GetCharcater("Moon_CH")))
        BrutalAPI.BrutalAPI.moddedChars.Add(LoadedAssetsHandler.GetCharcater("Moon_CH"));
      if (SaveGame.Check("MewAchieve") && !BrutalAPI.BrutalAPI.moddedChars.Contains(LoadedAssetsHandler.GetCharcater("Bartholomew_CH")))
        BrutalAPI.BrutalAPI.moddedChars.Add(LoadedAssetsHandler.GetCharcater("Bartholomew_CH"));
      if (SaveGame.Check("SalineAchieve") && !BrutalAPI.BrutalAPI.moddedChars.Contains(LoadedAssetsHandler.GetCharcater("Saline_CH")))
        BrutalAPI.BrutalAPI.moddedChars.Add(LoadedAssetsHandler.GetCharcater("Saline_CH"));
      if (SaveGame.Check("EstherAchieve") && !BrutalAPI.BrutalAPI.moddedChars.Contains(LoadedAssetsHandler.GetCharcater("Esther_CH")))
        BrutalAPI.BrutalAPI.moddedChars.Add(LoadedAssetsHandler.GetCharcater("Esther_CH"));
      if (!SaveGame.Check("BolaAchieve") || BrutalAPI.BrutalAPI.moddedChars.Contains(LoadedAssetsHandler.GetCharcater("Bola_CH")))
        return;
      BrutalAPI.BrutalAPI.moddedChars.Add(LoadedAssetsHandler.GetCharcater("Bola_CH"));
    }
  }
}
