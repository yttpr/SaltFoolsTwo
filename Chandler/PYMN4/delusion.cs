// Decompiled with JetBrains decompiler
// Type: PYMN4.delusion
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using Hawthorne;
using UnityEngine;

namespace PYMN4
{
  public static class delusion
  {
    public static void Add()
    {
      Connection_PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<Connection_PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance1)._passiveName = "Torn Apart";
      ((BasePassiveAbilitySO) instance1).passiveIcon = ResourceLoader.LoadSprite("GuttedIcon", 32);
      ((BasePassiveAbilitySO) instance1).type = (PassiveAbilityTypes) 2233534;
      ((BasePassiveAbilitySO) instance1)._enemyDescription = "Permanently applies Gutted to this enemy.";
      ((BasePassiveAbilitySO) instance1)._characterDescription = "Permanently applies Gutted to this character.";
      ((BasePassiveAbilitySO) instance1).doesPassiveTriggerInformationPanel = false;
      instance1.connectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 1, new IntentType?(), Slots.Self)
      });
      instance1.disconnectionEffects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 1, new IntentType?(), Slots.Self)
      });
      ((BasePassiveAbilitySO) instance1)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 1000
      };
      Enemy enemy = new Enemy()
      {
        name = "Delusion",
        health = 1,
        size = 1,
        entityID = (EntityIDs) 327748,
        healthColor = Pigments.Gray,
        priority = 3,
        prefab = Edge.assets.LoadAsset<GameObject>("assets/KILLYOURSEL/Shadow_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
      };
      enemy.prefab.SetDefaultParams();
      enemy.combatSprite = ResourceLoader.LoadSprite("shadowIconB", 32);
      enemy.overworldAliveSprite = ResourceLoader.LoadSprite("ShadowOver", 32, new Vector2?(new Vector2(0.5f, 0.05f)));
      enemy.overworldDeadSprite = ResourceLoader.LoadSprite("ShadowOver", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
      enemy.hurtSound = LoadedAssetsHandler.GetEnemy("ShiveringHomunculus_EN").damageSound;
      enemy.deathSound = LoadedAssetsHandler.GetEnemy("ShiveringHomunculus_EN").deathSound;
      enemy.abilitySelector = (BaseAbilitySelectorSO) ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
      enemy.passives = new BasePassiveAbilitySO[3]
      {
        (BasePassiveAbilitySO) instance1,
        Passives.Skittish,
        Passives.Withering
      };
      enemy.enterEffects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ShadowEnterEffect>(), 1, new IntentType?(), Slots.Self)
      };
      ScriptableObject.CreateInstance<PreviousEffectCondition>().wasSuccessful = false;
      PreviousEffectCondition instance2 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance2.wasSuccessful = true;
      HealEffect instance3 = ScriptableObject.CreateInstance<HealEffect>();
      instance3.usePreviousExitValue = true;
      Ability ability1 = new Ability();
      ability1.name = "Drain";
      ability1.description = "Deal a Little bit damage to the Left, Right, and Opposing party members. Heal this enemy the amount of damage dealt.";
      ability1.rarity = 5;
      ability1.effects = new Effect[2];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 1, new IntentType?((IntentType) 0), Slots.FrontLeftRight);
      ability1.effects[1] = new Effect((EffectSO) instance3, 1, new IntentType?((IntentType) 20), Slots.Self, (EffectConditionSO) instance2);
      ability1.visuals = LoadedAssetsHandler.GetEnemyAbility("Siphon_A").visuals;
      ability1.animationTarget = Slots.FrontLeftRight;
      Targetting_ByUnit_Side instance4 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
      instance4.getAllUnitSlots = false;
      instance4.getAllies = true;
      Ability ability2 = new Ability();
      ability2.name = "Haunt";
      ability2.description = "Apply 2 Muted to the Opposing party member.";
      ability2.rarity = 5;
      ability2.effects = new Effect[1];
      ability2.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyMutedEffect>(), 2, new IntentType?((IntentType) 846750), Slots.Front);
      ability2.visuals = LoadedAssetsHandler.GetCharacterAbility("OfDeath_1_A").visuals;
      ability2.animationTarget = Slots.Front;
      Ability ability3 = new Ability();
      ability3.name = "Gnaw";
      ability3.description = "Deal a Painful amount of damage to the Left and Right party members.";
      ability3.rarity = 5;
      ability3.effects = new Effect[1];
      ability3.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 4, new IntentType?((IntentType) 1), Slots.LeftRight);
      ability3.visuals = LoadedAssetsHandler.GetEnemyAbility("Gnaw_A").visuals;
      ability3.animationTarget = Slots.LeftRight;
      Ability ability4 = new Ability();
      ability4.name = "Insight";
      ability4.description = "Apply Focused to this enemy. generate 4 Purple pigment.";
      ability4.rarity = 5;
      ability4.effects = new Effect[2];
      GenerateColorManaEffect instance5 = ScriptableObject.CreateInstance<GenerateColorManaEffect>();
      instance5.mana = Pigments.Purple;
      ability4.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFocusedEffect>(), 1, new IntentType?((IntentType) 156), Slots.Self);
      ability4.effects[1] = new Effect((EffectSO) instance5, 4, new IntentType?((IntentType) 60), Slots.Self);
      ability4.visuals = LoadedAssetsHandler.GetCharacterAbility("Wrath_1_A").visuals;
      ability4.animationTarget = Slots.Self;
      enemy.abilities = new Ability[4]
      {
        ability1,
        ability2,
        ability3,
        ability4
      };
      enemy.AddEnemy();
    }
  }
}
