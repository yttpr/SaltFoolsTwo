// Decompiled with JetBrains decompiler
// Type: PYMN4.DelayedAttackManager
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PYMN4
{
  public static class DelayedAttackManager
  {
    public static List<DelayedAttack> Attacks = new List<DelayedAttack>();

    public static AttackVisualsSO CrushAnim => LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;

    public static TargetSlotInfo[] Targets(bool playerTurn)
    {
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (DelayedAttack attack in DelayedAttackManager.Attacks)
      {
        if (!targetSlotInfoList.Contains(attack.Target) && (playerTurn == attack.caster.IsUnitCharacter || attack.caster == null))
          targetSlotInfoList.Add(attack.Target);
      }
      return targetSlotInfoList.ToArray();
    }

    public static IUnit[] Attackers
    {
      get
      {
        List<IUnit> iunitList = new List<IUnit>();
        foreach (DelayedAttack attack in DelayedAttackManager.Attacks)
        {
          if (attack.caster != null && !iunitList.Contains(attack.caster))
            iunitList.Add(attack.caster);
        }
        return iunitList.ToArray();
      }
    }

    public static TargetSlotInfo[] TargetsForUnit(IUnit unit)
    {
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (DelayedAttack attack in DelayedAttackManager.Attacks)
      {
        if (!targetSlotInfoList.Contains(attack.Target) && attack.caster != null && attack.caster == unit)
          targetSlotInfoList.Add(attack.Target);
      }
      return targetSlotInfoList.ToArray();
    }

    public static DelayedAttack[] AttacksForUnit(IUnit unit)
    {
      List<DelayedAttack> delayedAttackList = new List<DelayedAttack>();
      foreach (DelayedAttack attack in DelayedAttackManager.Attacks)
      {
        if (attack.caster != null && attack.caster == unit)
          delayedAttackList.Add(attack);
      }
      return delayedAttackList.ToArray();
    }

    public static void CleanList(bool playerTurn)
    {
      List<DelayedAttack> delayedAttackList = new List<DelayedAttack>();
      foreach (DelayedAttack attack in DelayedAttackManager.Attacks)
      {
        if (attack.caster != null && attack.caster.IsUnitCharacter != playerTurn)
          delayedAttackList.Add(attack);
      }
      DelayedAttackManager.Attacks = delayedAttackList;
    }

    public static void PlayerTurnStart(Action<CombatStats> orig, CombatStats self)
    {
      orig(self);
      CombatManager.Instance.AddRootAction((CombatAction) new PerformDelayedAttacksAction(true));
    }

    public static void PlayerTurnEnd(Action<CombatStats> orig, CombatStats self)
    {
      orig(self);
      CombatManager.Instance.AddSubAction((CombatAction) new PerformDelayedAttacksAction(false));
    }

    public static void FinalizeCombat(Action<CombatStats> orig, CombatStats self)
    {
      orig(self);
      DelayedAttackManager.Attacks.Clear();
    }

    public static void UIInitialization(Action<CombatStats> orig, CombatStats self)
    {
      orig(self);
      DelayedAttackManager.Attacks.Clear();
    }

    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CombatStats).GetMethod("FinalizeCombat", ~BindingFlags.Default), typeof (DelayedAttackManager).GetMethod("FinalizeCombat", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (CombatStats).GetMethod("UIInitialization", ~BindingFlags.Default), typeof (DelayedAttackManager).GetMethod("UIInitialization", ~BindingFlags.Default));
      IDetour idetour3 = (IDetour) new Hook((MethodBase) typeof (CombatStats).GetMethod("PlayerTurnStart", ~BindingFlags.Default), typeof (DelayedAttackManager).GetMethod("PlayerTurnStart", ~BindingFlags.Default));
      IDetour idetour4 = (IDetour) new Hook((MethodBase) typeof (CombatStats).GetMethod("PlayerTurnEnd", ~BindingFlags.Default), typeof (DelayedAttackManager).GetMethod("PlayerTurnEnd", ~BindingFlags.Default));
    }
  }
}
