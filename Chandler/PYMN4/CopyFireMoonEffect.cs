// Decompiled with JetBrains decompiler
// Type: PYMN4.CopyFireMoonEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

namespace PYMN4
{
  public class CopyFireMoonEffect : ApplyFireSlotEffect
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
      int num1 = 0;
      foreach (CombatSlot characterSlot in stats.combatSlots.CharacterSlots)
      {
        if (characterSlot.Unit == caster && characterSlot is ISlotStatusEffector islotStatusEffector)
        {
          foreach (ISlotStatusEffect statusEffect in islotStatusEffector.StatusEffects)
          {
            if (statusEffect is OnFire_SlotStatusEffect slotStatusEffect)
              num1 += slotStatusEffect.Duration;
          }
        }
      }
      return num1 > 0 && base.PerformEffect(stats, caster, targets, areTargetSlots, num1, out exitAmount);
    }
  }
}
