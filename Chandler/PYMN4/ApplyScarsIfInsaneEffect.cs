// Decompiled with JetBrains decompiler
// Type: PYMN4.ApplyScarsIfInsaneEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using System.Collections.Generic;
using UnityEngine;

namespace PYMN4
{
  public class ApplyScarsIfInsaneEffect : EffectSO
  {
    [SerializeField]
    public bool _justOneTarget;
    [SerializeField]
    public bool _randomBetweenPrevious;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      if (Random.Range(0, 100) > caster.GetStoredValue((UnitStoredValueNames) 327748) || entryVariable <= 0)
        return false;
      StatusEffectInfoSO statusEffectInfoSo;
      stats.statusEffectDataBase.TryGetValue((StatusEffectType) 11, out statusEffectInfoSo);
      if (this._justOneTarget)
      {
        List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>((IEnumerable<TargetSlotInfo>) targets);
        for (int index = targetSlotInfoList.Count - 1; index >= 0; --index)
        {
          if (!targetSlotInfoList[index].HasUnit)
            targetSlotInfoList.RemoveAt(index);
        }
        if (targetSlotInfoList.Count > 0)
        {
          int index = Random.Range(0, targetSlotInfoList.Count);
          int num = this._randomBetweenPrevious ? Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
          Scars_StatusEffect scarsStatusEffect = new Scars_StatusEffect(num, 0);
          scarsStatusEffect.SetEffectInformation(statusEffectInfoSo);
          if (targetSlotInfoList[index].Unit.ApplyStatusEffect((IStatusEffect) scarsStatusEffect, num))
            exitAmount += num;
        }
      }
      else
      {
        for (int index = 0; index < targets.Length; ++index)
        {
          if (targets[index].HasUnit)
          {
            int num = this._randomBetweenPrevious ? Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
            Scars_StatusEffect scarsStatusEffect = new Scars_StatusEffect(num, 0);
            scarsStatusEffect.SetEffectInformation(statusEffectInfoSo);
            if (targets[index].Unit.ApplyStatusEffect((IStatusEffect) scarsStatusEffect, num))
              ++exitAmount;
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
