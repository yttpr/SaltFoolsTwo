// Decompiled with JetBrains decompiler
// Type: PYMN4.AmbushManager
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

namespace PYMN4
{
  public static class AmbushManager
  {
    public static int Patiently = 327750;

    public static void PostNotif(IUnit unit)
    {
      foreach (TargetSlotInfo target in Slots.Front.GetTargets(CombatManager.Instance._stats.combatSlots, unit.SlotID, unit.IsUnitCharacter))
      {
        if (target.HasUnit)
          CombatManager.Instance.PostNotification(((TriggerCalls) AmbushManager.Patiently).ToString(), (object) target.Unit, (object) null);
      }
    }

    public static void EnemySwap(Action<EnemyCombat, int> orig, EnemyCombat self, int slotID)
    {
      orig(self, slotID);
      AmbushManager.PostNotif((IUnit) self);
    }

    public static void CharacterSwap(
      Action<CharacterCombat, int> orig,
      CharacterCombat self,
      int slotID)
    {
      orig(self, slotID);
      AmbushManager.PostNotif((IUnit) self);
    }

    public static string AmbushValue(
      Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
      TooltipTextHandlerSO self,
      UnitStoredValueNames storedValue,
      int value)
    {
      Color magenta = Color.magenta;
      string str1;
      if (storedValue == (UnitStoredValueNames)AmbushManager.Patiently)
      {
        if (value <= 0)
        {
          str1 = "";
        }
        else
        {
          string str2 = "Ambush +" + string.Format("{0}", (object) value);
          string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._negativeSTColor) + ">";
          string str4 = "</color>";
          str1 = str3 + str2 + str4;
        }
      }
      else
        str1 = orig(self, storedValue, value);
      return str1;
    }

    public static void PlayerTurnStart(Action<CombatStats> orig, CombatStats self)
    {
      orig(self);
      CombatManager.Instance.AddRootAction((CombatAction) new PrepareCleanAmbushAction(true));
    }

    public static void PlayerTurnEnd(Action<CombatStats> orig, CombatStats self)
    {
      orig(self);
      CombatManager.Instance.AddSubAction((CombatAction) new PrepareCleanAmbushAction(false));
    }

    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof (AmbushManager).GetMethod("AmbushValue", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (CombatStats).GetMethod("PlayerTurnStart", ~BindingFlags.Default), typeof (AmbushManager).GetMethod("PlayerTurnStart", ~BindingFlags.Default));
      IDetour idetour3 = (IDetour) new Hook((MethodBase) typeof (CombatStats).GetMethod("PlayerTurnEnd", ~BindingFlags.Default), typeof (AmbushManager).GetMethod("PlayerTurnEnd", ~BindingFlags.Default));
      IDetour idetour4 = (IDetour) new Hook((MethodBase) typeof (EnemyCombat).GetMethod("SwapTo", ~BindingFlags.Default), typeof (AmbushManager).GetMethod("EnemySwap", ~BindingFlags.Default));
      IDetour idetour5 = (IDetour) new Hook((MethodBase) typeof (EnemyCombat).GetMethod("SwappedTo", ~BindingFlags.Default), typeof (AmbushManager).GetMethod("EnemySwap", ~BindingFlags.Default));
      IDetour idetour6 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("SwapTo", ~BindingFlags.Default), typeof (AmbushManager).GetMethod("CharacterSwap", ~BindingFlags.Default));
      IDetour idetour7 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("SwappedTo", ~BindingFlags.Default), typeof (AmbushManager).GetMethod("CharacterSwap", ~BindingFlags.Default));
    }
  }
}
