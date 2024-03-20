// Decompiled with JetBrains decompiler
// Type: PYMN4.TargetsDamageFrontEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using UnityEngine;

namespace PYMN4
{
  public class TargetsDamageFrontEffect : EffectSO
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
      DamageEffect instance = ScriptableObject.CreateInstance<DamageEffect>();
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
        {
          int num;
          ((EffectSO) instance).PerformEffect(stats, target.Unit, Slots.Front.GetTargets(stats.combatSlots, target.Unit.SlotID, target.Unit.IsUnitCharacter), Slots.Front.AreTargetSlots, entryVariable, out num);
          exitAmount += num;
        }
      }
      return exitAmount > 0;
    }
  }
}
