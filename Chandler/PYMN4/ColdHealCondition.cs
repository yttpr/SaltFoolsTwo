// Decompiled with JetBrains decompiler
// Type: PYMN4.ColdHealCondition
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using UnityEngine;

namespace PYMN4
{
  public class ColdHealCondition : EffectorConditionSO
  {
    [SerializeField]
    public bool _passIfTrue = false;

    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (!(args is DamageReceivedValueChangeException valueChangeException) || valueChangeException.damageType != (DamageType)6)
        return false;
      valueChangeException.AddModifier((IntValueModifier) new ColdFireHealMod(effector as IUnit));
      return true;
    }
  }
}
