// Decompiled with JetBrains decompiler
// Type: Hawthorne.Pale_StatusEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using System;
using UnityEngine;

namespace Hawthorne
{
  public class Pale_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
  {
    public int StatusContent => this.Amount;

    public int Restrictor { get; set; }

    public bool CanBeRemoved => this.Restrictor <= 0;

    public bool IsPositive => false;

    public string DisplayText
    {
      get
      {
        string displayText = "";
        if (this.Amount > 0)
          displayText += this.Amount.ToString();
        if (this.Restrictor > 0)
          displayText = displayText + "(" + this.Restrictor.ToString() + ")";
        return displayText;
      }
    }

    public int Amount { get; set; }

    public StatusEffectType EffectType => (StatusEffectType) 888666;

    public StatusEffectInfoSO EffectInfo { get; set; }

    public void SetEffectInformation(StatusEffectInfoSO effectInfo) => this.EffectInfo = effectInfo;

    public bool CanReduceDuration
    {
      get
      {
        BooleanReference booleanReference = new BooleanReference(true);
        CombatManager.Instance.ProcessImmediateAction((IImmediateAction) new CheckHasStatusFieldReductionBlockIAction(booleanReference), false);
        return !booleanReference.value;
      }
    }

    public Pale_StatusEffect(int amount, int restrictors = 0)
    {
      this.Amount = amount;
      this.Restrictor = restrictors;
    }

    public bool AddContent(IStatusEffect content)
    {
      this.Amount += content.StatusContent;
      this.Restrictor += content.Restrictor;
      return true;
    }

    public bool TryAddContent(int amount)
    {
      if (this.Amount <= 0)
        return false;
      this.Amount += amount;
      return true;
    }

    public int JustRemoveAllContent()
    {
      int amount = this.Amount;
      this.Amount = 0;
      return amount;
    }

    public void OnTriggerAttached(IStatusEffector caller) => CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), ((TriggerCalls) 6).ToString(), (object) caller);

    public void OnTriggerDettached(IStatusEffector caller) => CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), ((TriggerCalls) 6).ToString(), (object) caller);

    public void OnSubActionTrigger(object sender, object args, bool stateCheck)
    {
    }

    public void OnStatusTriggered(object sender, object args)
    {
      if (!(args is DamageReceivedValueChangeException valueChangeException) || valueChangeException.directDamage || !(sender is IUnit iunit))
        return;
      if (valueChangeException.damageType == (DamageType)888666)
      {
        valueChangeException.AddModifier((IntValueModifier) new ImmZeroMod());
        valueChangeException.AddModifier((IntValueModifier) new RemainSameTrigger(valueChangeException.amount));
        RemoveStatusEffectEffect instance = ScriptableObject.CreateInstance<RemoveStatusEffectEffect>();
        instance._statusToRemove = (StatusEffectType) 888666;
        CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
        {
          new Effect((EffectSO) instance, 1, new IntentType?(), Slots.Self)
        }), iunit, 0));
      }
      else
      {
        int maximumHealth = iunit.MaximumHealth;
        int newHP = iunit.CurrentHealth - (int) Math.Ceiling((Decimal) maximumHealth * (Decimal) this.Amount / 100M);
        IStatusEffector effector = sender as IStatusEffector;
        if (iunit is CharacterCombat)
          valueChangeException.AddModifier((IntValueModifier) new PaleTrigger(newHP, this, effector, this.Amount));
        else
          CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
          {
            new Effect((EffectSO) ScriptableObject.CreateInstance<PaleHarmEffect>(), this.Amount, new IntentType?(), Slots.Self)
          }), iunit, 0));
      }
    }

    public void OnTurnEnd(object sender, object args) => this.ReduceDuration(sender as IStatusEffector);

    public void ReduceDuration(IStatusEffector effector)
    {
      if (!this.CanReduceDuration || UnityEngine.Random.Range(0, 100) > 50)
        return;
      int amount = this.Amount;
      this.Amount = Mathf.Max(0, this.Amount - 1);
      if (this.TryRemoveStatusEffect(effector) || amount == this.Amount)
        return;
      effector.StatusEffectValuesChanged(this.EffectType, this.Amount - amount);
      this.ReduceDurationAgain(effector);
    }

    public void ReduceDurationAgain(IStatusEffector effector)
    {
      if (!this.CanReduceDuration || UnityEngine.Random.Range(0, 100) > 33)
        return;
      int amount = this.Amount;
      this.Amount = Mathf.Max(0, this.Amount - 1);
      if (this.TryRemoveStatusEffect(effector) || amount == this.Amount)
        return;
      effector.StatusEffectValuesChanged(this.EffectType, this.Amount - amount);
      this.ReduceDurationAgain(effector);
    }

    public void IncreaseDuration(IStatusEffector effector, int amount)
    {
    }

    public void DettachRestrictor(IStatusEffector effector)
    {
      --this.Restrictor;
      if (this.TryRemoveStatusEffect(effector))
        return;
      effector.StatusEffectValuesChanged(this.EffectType, 0);
    }

    public bool TryRemoveStatusEffect(IStatusEffector effector)
    {
      if (this.Amount > 0 || !this.CanBeRemoved)
        return false;
      effector.RemoveStatusEffect(this.EffectType);
      return true;
    }
  }
}
