// Decompiled with JetBrains decompiler
// Type: PYMN4.MoodDefendedCondition
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using UnityEngine;

namespace PYMN4
{
  public class MoodDefendedCondition : EffectConditionSO
  {
    public bool wasSuccessful = true;
    [Range(1f, 20f)]
    public int previousAmount = 1;

    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex) => caster.GetStoredValue((UnitStoredValueNames) 327745) <= 0;
  }
}
