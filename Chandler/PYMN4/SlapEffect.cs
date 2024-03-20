// Decompiled with JetBrains decompiler
// Type: PYMN4.SlapEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using UnityEngine;

namespace PYMN4
{
  public class SlapEffect : EffectSO
  {
    [SerializeField]
    public bool _justOneTarget;
    [SerializeField]
    public bool _randomBetweenPrevious;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      if (entryVariable <= 0)
        return false;
      CombatManager.Instance.AddUIAction((CombatAction) new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, "Slap"));
      AnimationVisualsEffect instance = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
      instance._visuals = LoadedAssetsHandler.GetCharacterAbility("Slap_A").visuals;
      instance._animationTarget = Slots.Front;
      CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2]
      {
        new Effect((EffectSO) instance, 1, new IntentType?(), Slots.Front),
        new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 1, new IntentType?(), Slots.Front)
      }), caster, 0));
      ++exitAmount;
      return exitAmount > 0;
    }
  }
}
