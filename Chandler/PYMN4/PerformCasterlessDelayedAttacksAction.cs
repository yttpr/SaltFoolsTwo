// Decompiled with JetBrains decompiler
// Type: PYMN4.PerformCasterlessDelayedAttacksAction
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using System.Collections;
using System.Collections.Generic;

namespace PYMN4
{
  public class PerformCasterlessDelayedAttacksAction : CombatAction
  {
    public DelayedAttack[] Attacks;

    public PerformCasterlessDelayedAttacksAction(DelayedAttack[] attacks)
    {
      List<DelayedAttack> delayedAttackList = new List<DelayedAttack>();
      foreach (DelayedAttack attack in attacks)
      {
        if (attack.caster == null)
          delayedAttackList.Add(attack);
      }
      this.Attacks = delayedAttackList.ToArray();
    }

    public override IEnumerator Execute(CombatStats stats)
    {
      DelayedAttack[] delayedAttackArray = this.Attacks;
      for (int index = 0; index < delayedAttackArray.Length; ++index)
      {
        DelayedAttack hit = delayedAttackArray[index];
        hit.Perform();
        hit = (DelayedAttack) null;
      }
      delayedAttackArray = (DelayedAttack[]) null;
      yield return (object) null;
    }
  }
}
