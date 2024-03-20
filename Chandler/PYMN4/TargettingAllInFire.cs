// Decompiled with JetBrains decompiler
// Type: PYMN4.TargettingAllInFire
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using System.Collections.Generic;

namespace PYMN4
{
  public class TargettingAllInFire : Targetting_ByUnit_Side
  {
    public static bool InFire(CombatStats stats, IUnit unit)
    {
      bool flag = false;
      for (int slotId = unit.SlotID; slotId < unit.SlotID + unit.Size; ++slotId)
      {
        if (stats.combatSlots.SlotContainsSlotStatusEffect(slotId, unit.IsUnitCharacter, (SlotStatusEffectType) 2))
          flag = true;
      }
      return flag;
    }

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      TargetSlotInfo[] targets = base.GetTargets(slots, casterSlotID, isCasterCharacter);
      List<TargetSlotInfo> targetSlotInfoList = new List<TargetSlotInfo>();
      foreach (TargetSlotInfo targetSlotInfo in targets)
      {
        if (targetSlotInfo.HasUnit && TargettingAllInFire.InFire(CombatManager.Instance._stats, targetSlotInfo.Unit))
          targetSlotInfoList.Add(targetSlotInfo);
      }
      return targetSlotInfoList.ToArray();
    }
  }
}
