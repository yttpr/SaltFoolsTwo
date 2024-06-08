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

            CombatManager.Instance.AddUIAction(new ShowAttackInformationUIAction(caster.ID, caster.IsUnitCharacter, "Slap"));
            AnimationVisualsEffect slapAnim = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
            slapAnim._visuals = LoadedAssetsHandler.GetCharacterAbility("Slap_A").visuals;
            slapAnim._animationTarget = Slots.Front;
            Effect anim = new Effect(slapAnim, 1, null, Slots.Front);
            Effect slap = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 1, null, Slots.Front);
            CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2] { anim, slap }), caster));
            CombatManager.Instance.AddRootAction(new EndAbilityAction(caster.ID, caster.IsUnitCharacter));
            exitAmount++;
            return exitAmount > 0;
        }
    }
}
