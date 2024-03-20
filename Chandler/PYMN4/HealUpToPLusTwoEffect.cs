// Decompiled with JetBrains decompiler
// Type: PYMN4.HealUpToPLusTwoEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using UnityEngine;

namespace PYMN4
{
  public class HealUpToPLusTwoEffect : EffectSO
  {
    public bool usePreviousExitValue;
    public bool entryAsPercentage;
    [SerializeField]
    public bool _directHeal = true;
    [SerializeField]
    public bool _onlyIfHasHealthOver0;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      if (this.usePreviousExitValue)
        entryVariable *= this.PreviousExitValue;
      exitAmount = 0;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit && (!this._onlyIfHasHealthOver0 || target.Unit.CurrentHealth > 0))
        {
          int num = entryVariable + Random.Range(0, 3);
          if (this.entryAsPercentage)
            num = target.Unit.CalculatePercentualAmount(num);
          exitAmount += target.Unit.Heal(num, (HealType) 1, this._directHeal);
        }
      }
      return exitAmount > 0;
    }
  }
}
