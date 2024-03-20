// Decompiled with JetBrains decompiler
// Type: PYMN4.BeheadEffectorCondition
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

namespace PYMN4
{
  public class BeheadEffectorCondition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if ((effector as IUnit).CurrentHealth <= 1 || !(args is DamageReceivedValueChangeException valueChangeException))
        return true;
      valueChangeException.AddModifier((IntValueModifier) new BeheadModifier(effector as IUnit));
      return true;
    }
  }
}
