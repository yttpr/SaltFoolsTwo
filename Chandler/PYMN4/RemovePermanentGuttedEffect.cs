// Decompiled with JetBrains decompiler
// Type: PYMN4.RemovePermanentGuttedEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

namespace PYMN4
{
  public class RemovePermanentGuttedEffect : EffectSO
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
      if (entryVariable <= 0)
        return false;
      stats.statusEffectDataBase.TryGetValue((StatusEffectType) 4, out StatusEffectInfoSO _);
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].HasUnit && targets[index].Unit is IStatusEffector unit && unit.DettachStatusRestrictor((StatusEffectType) 4))
          ++exitAmount;
      }
      return exitAmount > 0;
    }
  }
}
