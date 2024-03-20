// Decompiled with JetBrains decompiler
// Type: PYMN4.SalinePassiveAbility
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using System;
using UnityEngine;

namespace PYMN4
{
  public class SalinePassiveAbility : BasePassiveAbilitySO
  {
    public override bool IsPassiveImmediate => true;

    public override bool DoesPassiveTrigger => true;

    public override void TriggerPassive(object sender, object args)
    {
      IUnit unit = sender as IUnit;
      switch (args)
      {
        case DamageReceivedValueChangeException valueChangeException:
          valueChangeException.AddModifier((IntValueModifier) new InsanityHitMod(unit));
          break;
        case BooleanReference _:
          CombatManager.Instance.AddUIAction((CombatAction) new CharacterSetExtraSpriteUIAction(unit.ID, (ExtraSpriteType) 327748));
          break;
        default:
          CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
          {
            new Effect((EffectSO) ScriptableObject.CreateInstance<TriggerWitheringEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[9]
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
            }, true))
          }), unit, 0));
          int storedValue;
          for (storedValue = unit.GetStoredValue((UnitStoredValueNames) 327748); storedValue >= 100; storedValue -= 100)
            CombatManager.Instance.AddSubAction((CombatAction) new SpawnEnemyAction(LoadedAssetsHandler.GetEnemy("Delusion_EN"), -1, false, false, (SpawnType) 1));
          if (storedValue > UnityEngine.Random.Range(0, 100))
            CombatManager.Instance.AddSubAction((CombatAction) new SpawnEnemyAction(LoadedAssetsHandler.GetEnemy("Delusion_EN"), -1, false, false, (SpawnType) 1));
          if (unit.GetStoredValue((UnitStoredValueNames) 327758) < 1)
            unit.SetStoredValue((UnitStoredValueNames) 327748, Math.Min(unit.GetStoredValue((UnitStoredValueNames) 327748) * 2, 999));
          else
            unit.SetStoredValue((UnitStoredValueNames) 327758, 0);
          break;
      }
    }

    public override void OnPassiveConnected(IUnit unit)
    {
    }

    public override void OnPassiveDisconnected(IUnit unit)
    {
    }
  }
}
