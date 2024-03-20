// Decompiled with JetBrains decompiler
// Type: PYMN4.ApplyPermanentGuttedEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

namespace PYMN4
{
  public class ApplyPermanentGuttedEffect : EffectSO
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
      StatusEffectInfoSO statusEffectInfoSo;
      stats.statusEffectDataBase.TryGetValue((StatusEffectType) 4, out statusEffectInfoSo);
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].HasUnit)
        {
          Gutted_StatusEffect guttedStatusEffect = new Gutted_StatusEffect(0, 1);
          guttedStatusEffect.SetEffectInformation(statusEffectInfoSo);
          if (targets[index].Unit.ApplyStatusEffect((IStatusEffect) guttedStatusEffect, 0))
            exitAmount += entryVariable;
        }
      }
      return exitAmount > 0;
    }
  }
}
