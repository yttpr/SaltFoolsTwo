// Decompiled with JetBrains decompiler
// Type: PYMN4.TwoEffectCondition
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

namespace PYMN4
{
  public class TwoEffectCondition : EffectConditionSO
  {
    public EffectConditionSO first;
    public EffectConditionSO second;
    public bool Or;

    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      if (this.Or)
      {
        if (this.first.MeetCondition(caster, effects, currentIndex) || this.second.MeetCondition(caster, effects, currentIndex))
          return true;
      }
      else if (this.first.MeetCondition(caster, effects, currentIndex) && this.second.MeetCondition(caster, effects, currentIndex))
        return true;
      return false;
    }
  }
}
