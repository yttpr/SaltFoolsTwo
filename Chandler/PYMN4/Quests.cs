// Decompiled with JetBrains decompiler
// Type: PYMN4.Quests
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;

namespace PYMN4
{
  public static class Quests
  {
    public static void CharacterDeath(
      Quests.OutFourth<CharacterCombat, DeathReference, DeathType, bool> orig,
      CharacterCombat self,
      DeathReference reference,
      DeathType type,
      out bool CanBeRemoved)
    {
      orig(self, reference, type, out CanBeRemoved);
      if (type == (DeathType)53 && !SaveGame.Check("MoonUnlocked"))
        SaveGame.Set("MoonUnlocked", true);
      SavePerRun.IncreaseDeaths();
    }

    public static void EnemyDeath(
      Action<EnemyCombat, DeathReference, DeathType> orig,
      EnemyCombat self,
      DeathReference deathReference,
      DeathType deathType)
    {
      orig(self, deathReference, deathType);
      SavePerRun.IncreaseDeaths();
    }

    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("CharacterDeath", ~BindingFlags.Default), typeof (Quests).GetMethod("CharacterDeath", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (EnemyCombat).GetMethod("EnemyDeath", ~BindingFlags.Default), typeof (Quests).GetMethod("EnemyDeath", ~BindingFlags.Default));
    }

    public delegate void OutFourth<T1, T2, T3, T4>(T1 a, T2 b, T3 c, out T4 d);
  }
}
