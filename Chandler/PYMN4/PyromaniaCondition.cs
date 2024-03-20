// Decompiled with JetBrains decompiler
// Type: PYMN4.PyromaniaCondition
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using UnityEngine;

namespace PYMN4
{
  public class PyromaniaCondition : EffectorConditionSO
  {
    [SerializeField]
    public bool _passIfTrue = false;

    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if ((effector as IUnit).GetStoredValue((UnitStoredValueNames) 327746) < 12)
        return false;
      (effector as IUnit).SetStoredValue((UnitStoredValueNames) 327746, 0);
      return true;
    }
  }
}
