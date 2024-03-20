// Decompiled with JetBrains decompiler
// Type: PYMN4.PerformDelayedAttackEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

namespace PYMN4
{
  public class PerformDelayedAttackEffect : EffectSO
  {
    public DelayedAttack[] Attacks;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      foreach (DelayedAttack attack in this.Attacks)
        exitAmount += attack.Perform();
      if (exitAmount > 0)
        caster.DidApplyDamage(exitAmount);
      return exitAmount > 0;
    }
  }
}
