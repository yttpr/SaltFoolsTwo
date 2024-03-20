// Decompiled with JetBrains decompiler
// Type: PYMN4.MultiTriggerEffectItem
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using UnityEngine;

namespace PYMN4
{
  public class MultiTriggerEffectItem : Item
  {
    public Effect[] effects = new Effect[0];
    public bool immediate = false;
    public bool addResultToEffect = false;
    public TriggerCalls[] triggers = new TriggerCalls[0];

    public override BaseWearableSO Wearable()
    {
      MultiTriggerWearable instance = ScriptableObject.CreateInstance<MultiTriggerWearable>();
      ((BaseWearableSO) instance).BaseWearable((Item) this);
      instance.triggers = this.triggers;
      instance.effects = ExtensionMethods.ToEffectInfoArray(this.effects);
      instance._immediateEffect = this.immediate;
      return (BaseWearableSO) instance;
    }
  }
}
