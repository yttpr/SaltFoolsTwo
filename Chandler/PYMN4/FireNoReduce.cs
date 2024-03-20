// Decompiled with JetBrains decompiler
// Type: PYMN4.FireNoReduce
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;

namespace PYMN4
{
  public static class FireNoReduce
  {
    public static void Add()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (OnFire_SlotStatusEffect).GetMethod("ReduceDuration", ~BindingFlags.Default), typeof (FireNoReduce).GetMethod("ReduceDuration", ~BindingFlags.Default));
    }

    public static void ReduceDuration(
      Action<OnFire_SlotStatusEffect> orig,
      OnFire_SlotStatusEffect self)
    {
      if (self.Effector is CombatSlot effector && effector.HasUnit && effector.Unit.ContainsPassiveAbility((PassiveAbilityTypes) 327745))
        return;
      orig(self);
    }
  }
}
