// Decompiled with JetBrains decompiler
// Type: PYMN4.DeathCupDeathAction
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using System.Collections;

namespace PYMN4
{
  public class DeathCupDeathAction : CombatAction
  {
    public override IEnumerator Execute(CombatStats stats)
    {
      if (DeathCupWearable.Holders.Count == 1)
      {
        foreach (CharacterCombat chara in DeathCupWearable.Holders)
        {
          CombatManager.Instance.AddUIAction((CombatAction) new ShowItemInformationUIAction(chara.ID, "Death Cup", false, ResourceLoader.LoadSprite("DeathCup.png", 32)));
          chara.DirectDeath((IUnit) null, false);
        }
      }
      yield return (object) null;
    }
  }
}
