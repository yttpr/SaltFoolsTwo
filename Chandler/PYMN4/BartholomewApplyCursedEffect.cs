// Decompiled with JetBrains decompiler
// Type: PYMN4.BartholomewApplyCursedEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using UnityEngine;

namespace PYMN4
{
  public class BartholomewApplyCursedEffect : EffectSO
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
      if (caster.GetStoredValue((UnitStoredValueNames) 327757) < Random.Range(0, 100))
        return false;
      StatusEffectInfoSO statusEffectInfoSo;
      stats.statusEffectDataBase.TryGetValue((StatusEffectType) 3, out statusEffectInfoSo);
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].HasUnit)
        {
          Cursed_StatusEffect cursedStatusEffect = new Cursed_StatusEffect(0);
          cursedStatusEffect.SetEffectInformation(statusEffectInfoSo);
          if (targets[index].Unit.ApplyStatusEffect((IStatusEffect) cursedStatusEffect, 0))
            ++exitAmount;
        }
      }
      return exitAmount > 0;
    }
  }
}
