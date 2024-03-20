// Decompiled with JetBrains decompiler
// Type: PYMN4.RestrainingOrderWearable
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;

namespace PYMN4
{
  public class RestrainingOrderWearable : BaseWearableSO
  {
    public override bool DoesItemTrigger => false;

    public override bool IsItemImmediate => false;

    public static int WillApplyDamage(
      Func<CharacterCombat, int, IUnit, int> orig,
      CharacterCombat self,
      int amount,
      IUnit targetUnit)
    {
      if (!self.HasUsableItem || !(self.HeldItem is RestrainingOrderWearable))
        return orig(self, amount, targetUnit);
      float num1 = (float) amount;
      int size = targetUnit.Size;
      int slotId = targetUnit.SlotID;
      int num2 = 0;
      if (slotId + size > 4)
        ++num2;
      if (slotId == 0)
        ++num2;
      int[] slots = new int[2]{ -1, 1 };
      foreach (TargetSlotInfo target in Slots.SlotTarget(slots, true).GetTargets(CombatManager.Instance._stats.combatSlots, targetUnit.SlotID, targetUnit.IsUnitCharacter))
      {
        if (!target.HasUnit)
          ++num2;
      }
      if (num2 > 0)
        CombatManager.Instance.AddUIAction((CombatAction) new ShowItemInformationUIAction(self.ID, "Restraining Order", false, ResourceLoader.LoadSprite("RestrainingOrder.png", 32)));
      float num3 = 0.25f * (float) num2 + 1f;
      int num4 = (int) Math.Ceiling((double) (num1 * num3));
      return orig(self, num4, targetUnit);
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("WillApplyDamage", ~BindingFlags.Default), typeof (RestrainingOrderWearable).GetMethod("WillApplyDamage", ~BindingFlags.Default));
    }
  }
}
