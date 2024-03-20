// Decompiled with JetBrains decompiler
// Type: PYMN4.ArsonSelfHitEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using UnityEngine;

namespace PYMN4
{
  public class ArsonSelfHitEffect : EffectSO
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
      if (this._usePreviousExitValue)
        entryVariable *= this.PreviousExitValue;
      exitAmount = 0;
      if (!(caster is CharacterCombat))
        return false;
      int rank = (caster as CharacterCombat).Rank;
      if (rank <= 0)
      {
        DamageEffect instance = ScriptableObject.CreateInstance<DamageEffect>();
        instance._indirect = true;
        Effect effect = new Effect((EffectSO) instance, 2, new IntentType?(), Slots.Self);
        CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2]
        {
          effect,
          effect
        }), caster, 0));
        exitAmount += 2;
        return true;
      }
      if (rank == 1)
      {
        DamageRandomPlusOneEffect instance = ScriptableObject.CreateInstance<DamageRandomPlusOneEffect>();
        instance._indirect = true;
        Effect effect = new Effect((EffectSO) instance, 2, new IntentType?(), Slots.Self);
        CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[3]
        {
          effect,
          effect,
          effect
        }), caster, 0));
        exitAmount += 3;
        return true;
      }
      if (rank == 2)
      {
        DamageEffect instance = ScriptableObject.CreateInstance<DamageEffect>();
        instance._indirect = true;
        Effect effect = new Effect((EffectSO) instance, 1, new IntentType?(), Slots.Self);
        CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[6]
        {
          effect,
          effect,
          effect,
          effect,
          effect,
          effect
        }), caster, 0));
        exitAmount += 6;
        return true;
      }
      if (rank < 3)
        return false;
      DamageEffect instance1 = ScriptableObject.CreateInstance<DamageEffect>();
      instance1._indirect = true;
      Effect effect1 = new Effect((EffectSO) instance1, 1, new IntentType?(), Slots.Self);
      CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[7]
      {
        effect1,
        effect1,
        effect1,
        effect1,
        effect1,
        effect1,
        effect1
      }), caster, 0));
      exitAmount += 7;
      return true;
    }
  }
}
