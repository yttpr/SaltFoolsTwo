// Decompiled with JetBrains decompiler
// Type: PYMN4.ApplyFirePlusUpToOneSlotEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using UnityEngine;

namespace PYMN4
{
  public class ApplyFirePlusUpToOneSlotEffect : EffectSO
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      SlotStatusEffectInfoSO statusEffectInfoSo;
      stats.slotStatusEffectDataBase.TryGetValue((SlotStatusEffectType) 2, out statusEffectInfoSo);
      for (int index = 0; index < targets.Length; ++index)
      {
        int num = entryVariable + Random.Range(0, 2);
        if (num > 0)
        {
          OnFire_SlotStatusEffect slotStatusEffect = new OnFire_SlotStatusEffect(targets[index].SlotID, num, 0);
          slotStatusEffect.SetEffectInformation(statusEffectInfoSo);
          if (stats.combatSlots.ApplySlotStatusEffect(targets[index].SlotID, targets[index].IsTargetCharacterSlot, num, (ISlotStatusEffect) slotStatusEffect, 1))
            exitAmount += num;
        }
      }
      return exitAmount > 0;
    }
  }
}
