// Decompiled with JetBrains decompiler
// Type: PYMN4.OddEvenEffectorCondition
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

namespace PYMN4
{
  public class OddEvenEffectorCondition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (args is IntegerReference integerReference)
      {
        CombatStats stats = CombatManager.Instance._stats;
        ManaColorSO luckyManaColorOption = stats.LuckyManaColorOptions[stats.SelectedLuckyColor];
        if (integerReference.value % 2 == 0)
        {
          if (!stats.MainManaBar.IsManaBarFull)
            CombatManager.Instance.ProcessImmediateAction((IImmediateAction) new AddManaToManaBarAction(luckyManaColorOption, 1, effector.IsUnitCharacter, effector.ID), false);
        }
        else
        {
          JumpAnimationInformation unitJumpInformation = stats.GenerateUnitJumpInformation(effector.ID, effector.IsUnitCharacter);
          string manaConsumedSound = stats.audioController.manaConsumedSound;
          stats.MainManaBar.ConsumeAmountMana(luckyManaColorOption, 1, unitJumpInformation, manaConsumedSound);
        }
      }
      return true;
    }
  }
}
