// Decompiled with JetBrains decompiler
// Type: PYMN4.ResurrectSomeoneRandomEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using System.Collections.Generic;
using UnityEngine;

namespace PYMN4
{
  public class ResurrectSomeoneRandomEffect : EffectSO
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
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo target in targets)
      {
        if (!target.HasUnit)
          targetSlotInfoList.Add(target);
      }
      List<CharacterCombat> characterCombatList1 = stats.GetPossibleResurrectionCharacters();
      List<CharacterCombat> characterCombatList2 = new List<CharacterCombat>();
      if (targetSlotInfoList.Count <= 0)
        return false;
      TargetSlotInfo targetSlotInfo = targetSlotInfoList[Random.Range(0, targetSlotInfoList.Count)];
      if (characterCombatList1.Count <= 0)
        return false;
      foreach (CharacterCombat characterCombat in characterCombatList1)
      {
        if (!characterCombat.ContainsPassiveAbility((PassiveAbilityTypes) 327749))
          characterCombatList2.Add(characterCombat);
      }
      if (characterCombatList2.Count > 0)
        characterCombatList1 = characterCombatList2;
      if (!targetSlotInfo.HasUnit && targetSlotInfo.IsTargetCharacterSlot)
      {
        int index = Random.Range(0, characterCombatList1.Count);
        CharacterCombat characterCombat = characterCombatList1[index];
        characterCombatList1.RemoveAt(index);
        if (stats.ResurrectDeadCharacter(characterCombat, targetSlotInfo.SlotID, entryVariable))
          ++exitAmount;
      }
      return exitAmount > 0;
    }
  }
}
