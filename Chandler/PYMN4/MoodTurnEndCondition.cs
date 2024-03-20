// Decompiled with JetBrains decompiler
// Type: PYMN4.MoodTurnEndCondition
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using UnityEngine;

namespace PYMN4
{
  public class MoodTurnEndCondition : EffectorConditionSO
  {
    [SerializeField]
    public bool _passIfTrue = false;

    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if ((effector as IUnit).GetStoredValue((UnitStoredValueNames) 327745) > 0)
      {
        (effector as IUnit).SetStoredValue((UnitStoredValueNames) 327745, 0);
        return false;
      }
      string str = "Mood: -" + (effector as IUnit).GetStoredValue((UnitStoredValueNames) 327746).ToString();
      return true;
    }
  }
}
