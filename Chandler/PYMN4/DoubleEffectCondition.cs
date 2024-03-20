// Decompiled with JetBrains decompiler
// Type: PYMN4.DoubleEffectCondition
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

namespace PYMN4
{
  public class DoubleEffectCondition : EffectConditionSO
  {
    public EffectConditionSO first;
    public EffectConditionSO second;
    public bool And;

    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex) => this.And ? this.first.MeetCondition(caster, effects, currentIndex) && this.second.MeetCondition(caster, effects, currentIndex) : this.first.MeetCondition(caster, effects, currentIndex) || this.second.MeetCondition(caster, effects, currentIndex);
  }
}
