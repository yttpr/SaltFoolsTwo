// Decompiled with JetBrains decompiler
// Type: PYMN4.AutoReviveHook
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace PYMN4
{
  public static class AutoReviveHook
  {
    public static void CombatEndTriggered(Action<CombatStats> orig, CombatStats self)
    {
      if (self.CharactersAlive)
        CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
        {
          new Effect((EffectSO) ScriptableObject.CreateInstance<ReviveEllegyEffect>(), 5, new IntentType?(), Slots.SlotTarget(new int[9]
          {
            -4,
            -3,
            -2,
            -1,
            0,
            1,
            2,
            3,
            4
          }, true))
        }), (IUnit) ((IEnumerable<KeyValuePair<int, CharacterCombat>>) CombatManager.Instance._stats.CharactersOnField).First<KeyValuePair<int, CharacterCombat>>().Value, 0));
      orig(self);
    }

    public static void Add()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (CombatStats).GetMethod("CombatEndTriggered", ~BindingFlags.Default), typeof (AutoReviveHook).GetMethod("CombatEndTriggered", ~BindingFlags.Default));
    }
  }
}
