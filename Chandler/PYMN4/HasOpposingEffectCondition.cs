// Decompiled with JetBrains decompiler
// Type: PYMN4.HasOpposingEffectCondition
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;

namespace PYMN4
{
  public class HasOpposingEffectCondition : EffectConditionSO
  {
    public bool PassIfTrue = false;

    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      foreach (TargetSlotInfo target in Slots.Front.GetTargets(CombatManager.Instance._stats.combatSlots, caster.SlotID, caster.IsUnitCharacter))
      {
        if (target.HasUnit)
          return this.PassIfTrue;
      }
      return !this.PassIfTrue;
    }
  }
}
