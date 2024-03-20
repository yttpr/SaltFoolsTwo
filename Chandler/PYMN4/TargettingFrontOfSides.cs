// Decompiled with JetBrains decompiler
// Type: PYMN4.TargettingFrontOfSides
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using System.Collections.Generic;

namespace PYMN4
{
  public class TargettingFrontOfSides : BaseCombatTargettingSO
  {
    public override bool AreTargetAllies => false;

    public override bool AreTargetSlots => Slots.Front.AreTargetSlots;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo target1 in Slots.Sides.GetTargets(slots, casterSlotID, isCasterCharacter))
      {
        if (target1.HasUnit)
        {
          foreach (TargetSlotInfo target2 in Slots.Front.GetTargets(slots, target1.Unit.SlotID, target1.Unit.IsUnitCharacter))
            targetSlotInfoList.Add(target2);
        }
      }
      return targetSlotInfoList.ToArray();
    }
  }
}
