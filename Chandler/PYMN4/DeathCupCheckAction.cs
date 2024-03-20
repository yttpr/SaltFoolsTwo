// Decompiled with JetBrains decompiler
// Type: PYMN4.DeathCupCheckAction
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using System.Collections;

namespace PYMN4
{
  public class DeathCupCheckAction : CombatAction
  {
    public override IEnumerator Execute(CombatStats stats)
    {
      CombatManager.Instance.AddSubAction((CombatAction) new DeathCupDeathAction());
      yield return (object) null;
    }
  }
}
