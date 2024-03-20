// Decompiled with JetBrains decompiler
// Type: PYMN4.IfInFireEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using UnityEngine;

namespace PYMN4
{
  public class IfInFireEffect : EffectSO
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
      if (!stats.combatSlots.SlotContainsSlotStatusEffect(caster.SlotID, true, (SlotStatusEffectType) 2))
        return false;
      DamageEffect instance = ScriptableObject.CreateInstance<DamageEffect>();
      instance._indirect = true;
      CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2]
      {
        new Effect((EffectSO) instance, entryVariable, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?(), Slots.Self)
      }), caster, 0));
      exitAmount += entryVariable;
      return true;
    }
  }
}
