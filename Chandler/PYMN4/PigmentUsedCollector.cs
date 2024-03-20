// Decompiled with JetBrains decompiler
// Type: PYMN4.PigmentUsedCollector
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PYMN4
{
  public static class PigmentUsedCollector
  {
    public static List<ManaColorSO> lastUsed;
    public static int ID;

    public static void UseAbility(
      Action<CharacterCombat, int, FilledManaCost[]> orig,
      CharacterCombat self,
      int abilityID,
      FilledManaCost[] filledCost)
    {
      if (PigmentUsedCollector.lastUsed == null)
        PigmentUsedCollector.lastUsed = new List<ManaColorSO>();
      PigmentUsedCollector.lastUsed.Clear();
      PigmentUsedCollector.ID = self.ID;
      foreach (FilledManaCost filledManaCost in filledCost)
        PigmentUsedCollector.lastUsed.Add(filledManaCost.Mana);
      orig(self, abilityID, filledCost);
    }

    public static void FinalizeAbilityActions(Action<CharacterCombat> orig, CharacterCombat self)
    {
      orig(self);
      PigmentUsedCollector.ID = -1;
      PigmentUsedCollector.lastUsed.Clear();
    }

    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("UseAbility", ~BindingFlags.Default), typeof (PigmentUsedCollector).GetMethod("UseAbility", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("FinalizeAbilityActions", ~BindingFlags.Default), typeof (PigmentUsedCollector).GetMethod("FinalizeAbilityActions", ~BindingFlags.Default));
    }
  }
}
