// Decompiled with JetBrains decompiler
// Type: PYMN4.ReviveFriendEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using UnityEngine;

namespace PYMN4
{
  public class ReviveFriendEffect : EffectSO
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ResurrectSomeoneRandomEffect>(), entryVariable, new IntentType?(), Slots.SlotTarget(new int[9]
        {
          -4,
          -3,
          -2,
          -1,
          0,
          1,
          2,
          3,
          4
        }, caster.IsUnitCharacter))
      }), caster, 0));
      return true;
    }
  }
}
