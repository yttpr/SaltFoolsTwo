// Decompiled with JetBrains decompiler
// Type: PYMN4.BartholomewPassiveAbility
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using System;
using UnityEngine;

namespace PYMN4
{
  public class BartholomewPassiveAbility : BasePassiveAbilitySO
  {
    [Header("Passive Effects")]
    public EffectInfo[] effects;
    [Header("Passive Secondary data")]
    [SerializeField]
    public TriggerCalls[] _secondTriggerOn;
    [SerializeField]
    public EffectorConditionSO[] _secondPerformConditions;
    [SerializeField]
    public bool _secondDoesPerformPopUp = true;
    [SerializeField]
    public EffectInfo[] _secondEffects;

    public override bool IsPassiveImmediate => true;

    public override bool DoesPassiveTrigger => true;

    public override void TriggerPassive(object sender, object args)
    {
      IUnit iunit = sender as IUnit;
      if (iunit.GetStoredValue((UnitStoredValueNames) 327747) >= 4)
        return;
      CombatManager.Instance.AddUIAction((CombatAction) new CharacterSetExtraSpriteUIAction(iunit.ID, (ExtraSpriteType) 327747));
      iunit.SetStoredValue((UnitStoredValueNames) 327747, iunit.GetStoredValue((UnitStoredValueNames) 327747) + 1);
    }

    public override void OnPassiveConnected(IUnit unit)
    {
      CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPermanentGuttedEffect>(), 1, new IntentType?(), Slots.Self)
      }), unit, 0));
      unit.SetStoredValue((UnitStoredValueNames) 327747, 1);
      CombatManager.Instance.AddUIAction((CombatAction) new CharacterSetExtraSpriteUIAction(unit.ID, (ExtraSpriteType) 327747));
    }

    public override void OnPassiveDisconnected(IUnit unit)
    {
    }

    public override void CustomOnTriggerAttached(IPassiveEffector caller)
    {
      foreach (int num in this._secondTriggerOn)
      {
        TriggerCalls triggerCalls = (TriggerCalls) num;
        if (triggerCalls != (TriggerCalls)1000)
          CombatManager.Instance.AddObserver(new Action<object, object>(this.CustomTryTriggerPassive), triggerCalls.ToString(), (object) caller);
      }
    }

    public override void CustomOnTriggerDettached(IPassiveEffector caller)
    {
      foreach (int num in this._secondTriggerOn)
      {
        TriggerCalls triggerCalls = (TriggerCalls) num;
        if (triggerCalls != (TriggerCalls)1000)
          CombatManager.Instance.RemoveObserver(new Action<object, object>(this.CustomTryTriggerPassive), triggerCalls.ToString(), (object) caller);
      }
    }

    public override void FinalizeCustomTriggerPassive(object sender, object args, int triggerID)
    {
      if (!(sender is IPassiveEffector ipassiveEffector) || ((object) ipassiveEffector).Equals((object) null))
        return;
      if (this._secondDoesPerformPopUp)
        CombatManager.Instance.AddUIAction((CombatAction) new ShowPassiveInformationUIAction(((IEffectorChecks) ipassiveEffector).ID, ((IEffectorChecks) ipassiveEffector).IsUnitCharacter, this.GetPassiveLocData().text, this.passiveIcon));
      CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(this._secondEffects, sender as IUnit, 0));
    }

    public void CustomTryTriggerPassive(object sender, object args)
    {
      IUnit iunit = sender as IUnit;
      if (iunit.GetStoredValue((UnitStoredValueNames) 327747) <= 1)
        return;
      CombatManager.Instance.AddUIAction((CombatAction) new CharacterSetExtraSpriteUIAction(iunit.ID, (ExtraSpriteType) 327747));
      CombatManager.Instance.AddUIAction((CombatAction) new CharacterSetExtraSpriteUIAction(iunit.ID, (ExtraSpriteType) 327747));
      CombatManager.Instance.AddUIAction((CombatAction) new CharacterSetExtraSpriteUIAction(iunit.ID, (ExtraSpriteType) 327747));
      iunit.SetStoredValue((UnitStoredValueNames) 327747, iunit.GetStoredValue((UnitStoredValueNames) 327747) - 1);
    }
  }
}
