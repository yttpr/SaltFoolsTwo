// Decompiled with JetBrains decompiler
// Type: Hawthorne.ApplyMutedEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using System;
using System.Reflection;
using UnityEngine;

namespace Hawthorne
{
  public class ApplyMutedEffect : EffectSO
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
      if (entryVariable <= 0)
        return false;
      StatusEffectInfoSO statusEffectInfoSo;
      stats.statusEffectDataBase.TryGetValue((StatusEffectType) 846750, out statusEffectInfoSo);
      for (int index1 = 0; index1 < targets.Length; ++index1)
      {
        if (targets[index1].HasUnit)
        {
          int amount = this._randomBetweenPrevious ? UnityEngine.Random.Range(this.PreviousExitValue, entryVariable + 1) : entryVariable;
          IStatusEffect istatusEffect = (IStatusEffect) new Muted_StatusEffect(amount);
          istatusEffect.SetEffectInformation(statusEffectInfoSo);
          IStatusEffector unit = targets[index1].Unit as IStatusEffector;
          bool flag = false;
          int index2 = 999;
          for (int index3 = 0; index3 < unit.StatusEffects.Count; ++index3)
          {
            if (unit.StatusEffects[index3].EffectType == istatusEffect.EffectType)
            {
              index2 = index3;
              flag = true;
            }
          }
          if (flag)
          {
            foreach (MethodBase constructor in ((object) unit.StatusEffects[index2]).GetType().GetConstructors())
            {
              if (constructor.GetParameters().Length == 2)
                istatusEffect = (IStatusEffect) Activator.CreateInstance(((object) unit.StatusEffects[index2]).GetType(), (object) amount, (object) 0);
            }
          }
          istatusEffect.SetEffectInformation(statusEffectInfoSo);
          if (targets[index1].Unit.ApplyStatusEffect(istatusEffect, amount))
            ++exitAmount;
        }
      }
      return exitAmount > 0;
    }
  }
}
