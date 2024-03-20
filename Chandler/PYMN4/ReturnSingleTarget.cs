// Decompiled with JetBrains decompiler
// Type: PYMN4.ReturnSingleTarget
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

namespace PYMN4
{
  public class ReturnSingleTarget : BaseCombatTargettingSO
  {
    public TargetSlotInfo Target;

    public override bool AreTargetAllies => false;

    public override bool AreTargetSlots => true;

    public override TargetSlotInfo[] GetTargets(
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      return new TargetSlotInfo[1]{ this.Target };
    }
  }
}
