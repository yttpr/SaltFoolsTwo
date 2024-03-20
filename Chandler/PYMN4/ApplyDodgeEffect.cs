// Decompiled with JetBrains decompiler
// Type: PYMN4.ApplyDodgeEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using UnityEngine;

namespace PYMN4
{
  public class ApplyDodgeEffect : EffectSO
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
      StatusEffectInfoSO effectInfo;
      stats.statusEffectDataBase.TryGetValue(Dodge.Type, out effectInfo);
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].HasUnit)
        {
          int duration = this._randomBetweenPrevious ? Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
          Dodge_StatusEffect dodgeStatusEffect = new Dodge_StatusEffect(duration);
          dodgeStatusEffect.SetEffectInformation(effectInfo);
          if (targets[index].Unit.ApplyStatusEffect((IStatusEffect) dodgeStatusEffect, duration))
            exitAmount += duration;
        }
      }
      return exitAmount > 0;
    }
  }
}
