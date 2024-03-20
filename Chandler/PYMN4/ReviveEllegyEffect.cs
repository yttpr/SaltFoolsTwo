// Decompiled with JetBrains decompiler
// Type: PYMN4.ReviveEllegyEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using System.Collections.Generic;
using UnityEngine;

namespace PYMN4
{
  public class ReviveEllegyEffect : EffectSO
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
      int num = 0;
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
          ++num;
        else
          targetSlotInfoList.Add(target);
      }
      if (num <= 0 || num >= 5 || targetSlotInfoList.Count <= 0)
        return false;
      List<CharacterCombat> resurrectionCharacters = stats.GetPossibleResurrectionCharacters();
      for (int index1 = 0; index1 < resurrectionCharacters.Count; ++index1)
      {
        if (resurrectionCharacters[index1].ContainsPassiveAbility((PassiveAbilityTypes) 327749))
        {
          CharacterCombat characterCombat = resurrectionCharacters[index1];
          resurrectionCharacters.RemoveAt(index1);
          int index2 = Random.Range(0, targetSlotInfoList.Count);
          if (stats.ResurrectDeadCharacter(characterCombat, targetSlotInfoList[index2].SlotID, entryVariable))
          {
            targetSlotInfoList.RemoveAt(index2);
            ++exitAmount;
            CombatManager.Instance.AddUIAction((CombatAction) new ShowPassiveInformationUIAction(characterCombat.ID, true, "Eternal", ResourceLoader.LoadSprite("eternity", 32)));
            CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
              new Effect((EffectSO) ScriptableObject.CreateInstance<ReviveEllegyEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[9]
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
            break;
          }
          break;
        }
      }
      return exitAmount > 0;
    }
  }
}
