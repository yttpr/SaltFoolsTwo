// Decompiled with JetBrains decompiler
// Type: PYMN4.DeathCupItem
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using UnityEngine;

namespace PYMN4
{
  public class DeathCupItem : Item
  {
    public override BaseWearableSO Wearable()
    {
      DeathCupWearable instance = ScriptableObject.CreateInstance<DeathCupWearable>();
      instance.BaseWearable((Item) this);
      return (BaseWearableSO) instance;
    }
  }
}
