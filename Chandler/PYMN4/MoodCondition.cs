// Decompiled with JetBrains decompiler
// Type: PYMN4.MoodCondition
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using UnityEngine;

namespace PYMN4
{
  public class MoodCondition : EffectorConditionSO
  {
    [SerializeField]
    public bool _passIfTrue = false;

    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      switch (args)
      {
        case DamageDealtValueChangeException valueChangeException:
          string str = "Mood: -" + (effector as IUnit).GetStoredValue((UnitStoredValueNames) 327746).ToString();
          CombatManager.Instance.AddUIAction((CombatAction) new ShowPassiveInformationUIAction(effector.ID, effector.IsUnitCharacter, str, ResourceLoader.LoadSprite("mood", 32)));
          valueChangeException.AddModifier((IntValueModifier) new MoodValueModifier((effector as IUnit).GetStoredValue((UnitStoredValueNames) 327746)));
          return false;
        case DamageReceivedValueChangeException _:
          return (effector as IUnit).GetStoredValue((UnitStoredValueNames) 327745) <= 0;
        default:
          return true;
      }
    }
  }
}
