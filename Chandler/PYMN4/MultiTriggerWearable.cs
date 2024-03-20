// Decompiled with JetBrains decompiler
// Type: PYMN4.MultiTriggerWearable
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using System;

namespace PYMN4
{
  public class MultiTriggerWearable : PerformEffectWearable
  {
    public TriggerCalls[] triggers = new TriggerCalls[0];

    public override void CustomOnTriggerAttached(IWearableEffector caller)
    {
      foreach (int trigger in this.triggers)
      {
        TriggerCalls triggerCalls = (TriggerCalls) trigger;
        if (((BaseWearableSO) this).DoesItemTrigger && triggerCalls != (TriggerCalls)1000)
          CombatManager.Instance.AddObserver(new Action<object, object>(((BaseWearableSO) this).TryConsumeWearable), triggerCalls.ToString(), (object) caller);
      }
    }

    public override void CustomOnTriggerDettached(IWearableEffector caller)
    {
      foreach (int trigger in this.triggers)
      {
        TriggerCalls triggerCalls = (TriggerCalls) trigger;
        if (((BaseWearableSO) this).DoesItemTrigger && triggerCalls != (TriggerCalls)1000)
          CombatManager.Instance.RemoveObserver(new Action<object, object>(((BaseWearableSO) this).TryConsumeWearable), triggerCalls.ToString(), (object) caller);
      }
    }
  }
}
