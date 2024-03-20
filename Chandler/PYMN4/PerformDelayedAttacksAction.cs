// Decompiled with JetBrains decompiler
// Type: PYMN4.PerformDelayedAttacksAction
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using System.Collections;
using UnityEngine;

namespace PYMN4
{
  public class PerformDelayedAttacksAction : CombatAction
  {
    public bool PlayerTurn;

    public PerformDelayedAttacksAction(bool playerTurn) => this.PlayerTurn = playerTurn;

    public override IEnumerator Execute(CombatStats stats)
    {
      CombatManager.Instance.AddSubAction((CombatAction) new PlayAnimationAnywhereAction(DelayedAttackManager.CrushAnim, DelayedAttackManager.Targets(this.PlayerTurn)));
      IUnit[] iunitArray = DelayedAttackManager.Attackers;
      for (int index = 0; index < iunitArray.Length; ++index)
      {
        IUnit unit = iunitArray[index];
        if (this.PlayerTurn == unit.IsUnitCharacter)
        {
          ReturnMultiTargets targets = ScriptableObject.CreateInstance<ReturnMultiTargets>();
          targets.Targets = DelayedAttackManager.TargetsForUnit(unit);
          PerformDelayedAttackEffect attack = ScriptableObject.CreateInstance<PerformDelayedAttackEffect>();
          attack.Attacks = DelayedAttackManager.AttacksForUnit(unit);
          Effect effect = new Effect((EffectSO) attack, 0, new IntentType?(), (BaseCombatTargettingSO) targets);
          EffectInfo[] info = ExtensionMethods.ToEffectInfoArray(new Effect[1]
          {
            effect
          });
          CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(info, unit, 0));
          targets = (ReturnMultiTargets) null;
          attack = (PerformDelayedAttackEffect) null;
          effect = new Effect();
          info = (EffectInfo[]) null;
        }
        unit = (IUnit) null;
      }
      iunitArray = (IUnit[]) null;
      CombatManager.Instance.AddSubAction((CombatAction) new PerformCasterlessDelayedAttacksAction(DelayedAttackManager.Attacks.ToArray()));
      DelayedAttackManager.CleanList(this.PlayerTurn);
      yield return (object) null;
    }
  }
}
