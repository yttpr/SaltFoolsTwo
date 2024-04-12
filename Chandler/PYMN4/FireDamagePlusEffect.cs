// Decompiled with JetBrains decompiler
// Type: PYMN4.FireDamagePlusEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using UnityEngine;

namespace PYMN4
{
  public class FireDamagePlusEffect : EffectSO
  {
    [SerializeField]
    public DeathType _deathType = (DeathType) 1;
    [SerializeField]
    public bool _usePreviousExitValue;
    [SerializeField]
    public bool _ignoreShield;
    [SerializeField]
    public bool _indirect;
    [SerializeField]
    public bool _returnKillAsSuccess;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      if (stats.combatSlots.SlotContainsSlotStatusEffect(caster.SlotID, caster.IsUnitCharacter, (SlotStatusEffectType) 2))
      {
        if (caster.IsUnitCharacter)
        {
          foreach (CombatSlot characterSlot in stats.combatSlots.CharacterSlots)
          {
            if (characterSlot.SlotID == caster.SlotID)
            {
              foreach (ISlotStatusEffect statusEffect in characterSlot.StatusEffects)
              {
                if (statusEffect is OnFire_SlotStatusEffect slotStatusEffect)
                  entryVariable += slotStatusEffect.Duration;
              }
            }
          }
        }
        else
        {
          foreach (CombatSlot enemySlot in stats.combatSlots.EnemySlots)
          {
            if (enemySlot.SlotID == caster.SlotID)
            {
              foreach (ISlotStatusEffect statusEffect in enemySlot.StatusEffects)
              {
                if (statusEffect is OnFire_SlotStatusEffect slotStatusEffect)
                  entryVariable += slotStatusEffect.Duration;
              }
            }
          }
        }
      }
      exitAmount = 0;
      bool flag = false;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
        {
          int num1 = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
          int num2 = entryVariable;
                    
                    DamageInfo damageInfo;
          if (this._indirect)
          {
                        if (target.Unit.ContainsStatusEffect((StatusEffectType)9, 0))
                        {
                            num2 *= 3;
                            target.Unit.TryRemoveStatusEffect(StatusEffectType.OilSlicked);
                        }
                        damageInfo = target.Unit.Damage(num2, (IUnit) null, (DeathType) 53, num1, false, false, true, (DamageType) 6);
          }
          else
          {
            int num3 = caster.WillApplyDamage(num2, target.Unit);
                        if (target.Unit.ContainsStatusEffect((StatusEffectType)9, 0))
                        {
                            num3 *= 3;
                            target.Unit.TryRemoveStatusEffect(StatusEffectType.OilSlicked);
                        }
                        damageInfo = target.Unit.Damage(num3, caster, (DeathType) 53, num1, true, true, this._ignoreShield, (DamageType) 6);
          }
          flag |= damageInfo.beenKilled;
          exitAmount += damageInfo.damageAmount;
        }
      }
      if (!this._indirect && exitAmount > 0)
        caster.DidApplyDamage(exitAmount);
      return !this._returnKillAsSuccess ? exitAmount > 0 : flag;
    }
  }
}
