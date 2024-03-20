// Decompiled with JetBrains decompiler
// Type: PYMN4.Acid_StatusEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using System;
using UnityEngine;

namespace PYMN4
{
  public class Acid_StatusEffect : IStatusEffect, ITriggerEffect<IStatusEffector>
  {
    public const int _acidDamage = 3;

    public int StatusContent => this.Duration;

    public int Restrictor { get; set; }

    public bool CanBeRemoved => this.Restrictor <= 0;

    public bool IsPositive => false;

    public string DisplayText
    {
      get
      {
        string displayText = "";
        if (this.Duration > 0)
          displayText += this.Duration.ToString();
        if (this.Restrictor > 0)
          displayText = displayText + "(" + this.Restrictor.ToString() + ")";
        return displayText;
      }
    }

    public int Duration { get; set; }

    public StatusEffectType EffectType => (StatusEffectType) Acid.acid;

    public StatusEffectInfoSO EffectInfo { get; set; }

    public bool CanReduceDuration
    {
      get
      {
        BooleanReference booleanReference = new BooleanReference(true);
        CombatManager.Instance.ProcessImmediateAction((IImmediateAction) new CheckHasStatusFieldReductionBlockIAction(booleanReference), false);
        return !booleanReference.value;
      }
    }

    public void SetEffectInformation(StatusEffectInfoSO effectInfo) => this.EffectInfo = effectInfo;

    public Acid_StatusEffect(int duration, int restrictors = 0)
    {
      this.Duration = duration;
      this.Restrictor = restrictors;
    }

    public bool AddContent(IStatusEffect content)
    {
      this.Duration += content.StatusContent;
      this.Restrictor += content.Restrictor;
      return true;
    }

    public bool TryAddContent(int amount)
    {
      if (this.Duration <= 0)
        return false;
      this.Duration += amount;
      return true;
    }

    public int JustRemoveAllContent()
    {
      int duration = this.Duration;
      this.Duration = 0;
      return duration;
    }

    public void OnTriggerAttached(IStatusEffector caller)
    {
      CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTriggered), ((TriggerCalls) 14).ToString(), (object) caller);
      CombatManager.Instance.AddObserver(new Action<object, object>(this.OnStatusTick), ((TriggerCalls) 7).ToString(), (object) caller);
    }

    public void OnTriggerDettached(IStatusEffector caller)
    {
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTriggered), ((TriggerCalls) 14).ToString(), (object) caller);
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.OnStatusTick), ((TriggerCalls) 7).ToString(), (object) caller);
    }

    public void OnSubActionTrigger(object sender, object args, bool stateCheck) => (sender as IUnit).Damage(3, (IUnit) null, (DeathType) 0, -1, false, false, true, (DamageType) Acid.acid);

    public void OnStatusTriggered(object sender, object args) => CombatManager.Instance.AddSubAction((CombatAction) new PerformStatusEffectAction((IStatusEffect) this, sender, args, false));

    public void OnStatusTick(object sender, object args) => this.ReduceDuration(sender as IStatusEffector);

    public void ReduceDuration(IStatusEffector effector)
    {
      if (!this.CanReduceDuration)
        return;
      int duration = this.Duration;
      this.Duration = Mathf.Max(0, this.Duration - 1);
      if (!this.TryRemoveStatusEffect(effector) && duration != this.Duration)
        effector.StatusEffectValuesChanged(this.EffectType, this.Duration - duration);
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
      if (this.Duration > 0 || !this.CanBeRemoved)
        return false;
      effector.RemoveStatusEffect(this.EffectType);
      return true;
    }
  }
}
