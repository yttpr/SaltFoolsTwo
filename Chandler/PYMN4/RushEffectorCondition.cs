// Decompiled with JetBrains decompiler
// Type: PYMN4.RushEffectorCondition
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

namespace PYMN4
{
  public class RushEffectorCondition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (args is DamageDealtValueChangeException valueChangeException)
      {
        CombatManager.Instance.AddUIAction((CombatAction) new ShowItemInformationUIAction(effector.ID, "Artifical Adrenaline Rush", false, ResourceLoader.LoadSprite("AdrenalineRush", 32)));
        valueChangeException.AddModifier((IntValueModifier) new RushModifier());
      }
      else if (CombatManager.Instance._stats.TurnsPassed >= 5)
      {
        CombatManager.Instance.AddUIAction((CombatAction) new ShowItemInformationUIAction(effector.ID, "Artifical Adrenaline Rush", false, ResourceLoader.LoadSprite("AdrenalineRush", 32)));
        (effector as IUnit).DirectDeath((IUnit) null, false);
      }
      return true;
    }
  }
}
