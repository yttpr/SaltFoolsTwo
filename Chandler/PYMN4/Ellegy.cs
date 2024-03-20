// Decompiled with JetBrains decompiler
// Type: PYMN4.Ellegy
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using Hawthorne;
using UnityEngine;

namespace PYMN4
{
  public static class Ellegy
  {
    public static void Add()
    {
      AutoReviveHook.Add();
      PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance1)._passiveName = "Eternal";
      ((BasePassiveAbilitySO) instance1).passiveIcon = ResourceLoader.LoadSprite("eternity", 32);
      ((BasePassiveAbilitySO) instance1).type = (PassiveAbilityTypes) 327749;
      ((BasePassiveAbilitySO) instance1)._enemyDescription = "uhh probably wont work";
      ((BasePassiveAbilitySO) instance1)._characterDescription = "On combat end, if this character is dead attempt to resurrect this character at 5 health. \nThis effect does not trigger if all other party members are dead or if there are no open spots left in the field.";
      ((BasePassiveAbilitySO) instance1).doesPassiveTriggerInformationPanel = false;
      instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ExitValueSetterEffect>(), 1, new IntentType?(), Slots.Self)
      });
      ((BasePassiveAbilitySO) instance1)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 1000
      };
      Character character = new Character();
      character.name = "Esther";
      character.healthColor = Pigments.Purple;
      character.entityID = (EntityIDs) 327749;
      character.overworldSprite = ResourceLoader.LoadSprite("EstherOver", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
      character.frontSprite = ResourceLoader.LoadSprite("FrontEsther1", 32);
      character.backSprite = ResourceLoader.LoadSprite("BackEsther1", 32);
      character.lockedSprite = ResourceLoader.LoadSprite("EstherLock", 32);
      character.unlockedSprite = ResourceLoader.LoadSprite("EstherMenu", 32);
      character.menuChar = true;
      character.isSupport = false;
      character.walksInOverworld = true;
      character.hurtSound = LoadedAssetsHandler.GetCharcater("Rags_CH").damageSound;
      character.deathSound = "";
      character.dialogueSound = LoadedAssetsHandler.GetCharcater("Rags_CH").damageSound;
      character.passives = new BasePassiveAbilitySO[1]
      {
        (BasePassiveAbilitySO) instance1
      };
      character.levels = new CharacterRankedData[4];
      AnimationVisualsEffect instance2 = ScriptableObject.CreateInstance<AnimationVisualsEffect>();
      instance2._visuals = LoadedAssetsHandler.GetEnemy("TriggerFingers_BOSS").abilities[3].ability.visuals;
      instance2._animationTarget = Slots.Self;
      PreviousEffectCondition instance3 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance3.wasSuccessful = true;
      Ability ability1 = new Ability();
      ability1.name = "First Bullet";
      ability1.description = "Deal 10 damage to the Opposing enemy and apply 15 Pale to self. 1/6 chance to instantly kill this character.";
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Red
      };
      ability1.sprite = ResourceLoader.LoadSprite("bullet");
      ability1.effects = new Effect[4];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 10, new IntentType?((IntentType) 2), Slots.Front);
      ability1.effects[1] = new Effect((EffectSO) instance2, 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(17));
      ability1.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, new IntentType?((IntentType) 6), Slots.Self, (EffectConditionSO) instance3);
      ability1.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPaleEffect>(), 15, new IntentType?((IntentType) 666888), Slots.Self);
      ability1.visuals = LoadedAssetsHandler.GetEnemyAbility("Crush_A").visuals;
      ability1.animationTarget = Slots.Front;
      Ability ability2 = ability1.Duplicate();
      ability2.name = "Intermediate Bullet";
      ability2.description = "Deal 12 damage to the Opposing enemy and apply 15 Pale to self. 1/6 chance to instantly kill this character.";
      ability2.effects[0]._intent = new IntentType?((IntentType) 3);
      ability2.effects[0]._entryVariable = 12;
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Penultimate Bullet";
      ability3.description = "Deal 14 damage to the Opposing enemy and apply 15 Pale to self. 1/6 chance to instantly kill this character.";
      ability3.effects[0]._entryVariable = 14;
      Ability ability4 = ability3.Duplicate();
      ability4.name = "Final Bullet";
      ability4.description = "Deal 17 damage to the Opposing enemy and apply 15 Pale to self. 1/6 chance to instantly kill this character.";
      ability4.effects[0]._intent = new IntentType?((IntentType) 4);
      ability4.effects[0]._entryVariable = 17;
      Ability ability5 = new Ability();
      ability5.name = "Judicial Execution";
      ability5.description = "Instantly kill this character. Attempt to revive another random character at 1 health.";
      ability5.cost = new ManaColorSO[3]
      {
        Pigments.Purple,
        Pigments.Purple,
        Pigments.Purple
      };
      ability5.sprite = ResourceLoader.LoadSprite("execution");
      ability5.effects = new Effect[2];
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, new IntentType?((IntentType) 6), Slots.Self);
      ability5.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ReviveFriendEffect>(), 1, new IntentType?((IntentType) 80), Slots.Self);
      ability5.visuals = LoadedAssetsHandler.GetEnemy("TriggerFingers_BOSS").abilities[3].ability.visuals;
      ability5.animationTarget = Slots.Self;
      Ability ability6 = ability5.Duplicate();
      ability6.name = "Local Execution";
      ability6.description = "Instantly kill this character. Attempt to revive another random character at 5 health.";
      ability6.effects[1]._entryVariable = 5;
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Familial Execution";
      ability7.description = "Instantly kill this character. Attempt to revive another random character at 8 health.";
      ability7.effects[1]._entryVariable = 8;
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Self Execution";
      ability8.description = "Instantly kill this character. Attempt to revive another random character at 12 health.";
      ability8.effects[1]._entryVariable = 12;
      ScriptableObject.CreateInstance<ChangeMaxHealthEffect>()._increase = false;
      Ability ability9 = new Ability();
      ability9.name = "Last Words";
      ability9.description = "Make the Left and Right allies deal 7 damage to their Opposing enemies. Apply 15 Pale to self. 1/6 chance to instantly kill this character.";
      ability9.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Blue
      };
      ability9.sprite = ResourceLoader.LoadSprite("words");
      ability9.effects = new Effect[5];
      ability9.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<TargetsDamageFrontEffect>(), 7, new IntentType?((IntentType) 100), Slots.Sides);
      ability9.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, new IntentType?((IntentType) 2), (BaseCombatTargettingSO) ScriptableObject.CreateInstance<TargettingFrontOfSides>());
      ability9.effects[2] = new Effect((EffectSO) instance2, 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(17));
      ability9.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<DirectDeathEffect>(), 1, new IntentType?((IntentType) 6), Slots.Self, (EffectConditionSO) instance3);
      ability9.effects[4] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPaleEffect>(), 15, new IntentType?((IntentType) 666888), Slots.Self);
      ability9.visuals = LoadedAssetsHandler.GetCharacterAbility("Expire_1_A").visuals;
      ability9.animationTarget = Slots.Self;
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Last Conversations";
      ability10.description = "Make the Left and Right allies deal 10 damage to their Opposing enemies. Apply 15 Pale to self. 1/6 chance to instantly kill this character.";
      ability10.effects[0]._entryVariable = 10;
      Ability ability11 = ability10.Duplicate();
      ability11.name = "Last Memories";
      ability11.description = "Make the Left and Right allies deal 12 damage to their Opposing enemies. Apply 15 Pale to self. 1/6 chance to instantly kill this character.";
      ability11.effects[0]._entryVariable = 12;
      ability11.effects[0]._intent = new IntentType?((IntentType) 3);
      Ability ability12 = ability11.Duplicate();
      ability12.name = "Last Life";
      ability12.description = "Make the Left and Right allies deal 14 damage to their Opposing enemies. Apply 15 Pale to self. 1/6 chance to instantly kill this character.";
      ability12.effects[0]._entryVariable = 14;
      character.AddLevel(7, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(8, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(10, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      character.AddLevel(13, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.AddCharacter();
    }

    public static void Items(bool unlockedDefault)
    {
      EffectItem heavenUnlock = new EffectItem();
      heavenUnlock.name = "Beheading";
      heavenUnlock.flavorText = "\"Oh, woe is me!\"";
      heavenUnlock.description = "Decrease this party member's maximum health by 4. \nThis patry member's health cannot be reduced below one unless they are already at 1 health.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("Guillotine.png", 32);
      heavenUnlock.trigger = (TriggerCalls) 6;
      heavenUnlock.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<BeheadEffectorCondition>()
      };
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.unlockableID = (UnlockableID) 328749;
      heavenUnlock.namePopup = false;
      heavenUnlock.itemPools = ItemPools.Treasure;
      heavenUnlock.shopPrice = 9;
      MaxHealthChange_Wearable_SMS instance = ScriptableObject.CreateInstance<MaxHealthChange_Wearable_SMS>();
      instance.maxHealthChange = -4;
      heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[1]
      {
        (WearableStaticModifierSetterSO) instance
      };
      MultiTriggerEffectItem osmanUnlock = new MultiTriggerEffectItem();
      osmanUnlock.name = "Artificial Adrenaline Rush";
      osmanUnlock.flavorText = "\"Life only has value because of death.\"";
      osmanUnlock.description = "Increase damage dealt by this party member by 50%. This party member instantly dies on the start of the 6th turn.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("AdrenalineRush", 32);
      osmanUnlock.trigger = (TriggerCalls) 1000;
      osmanUnlock.triggers = new TriggerCalls[2]
      {
        (TriggerCalls) 16,
        (TriggerCalls) 21
      };
      osmanUnlock.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<RushEffectorCondition>()
      };
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.namePopup = false;
      osmanUnlock.unlockableID = (UnlockableID) 327849;
      osmanUnlock.itemPools = ItemPools.Treasure;
      osmanUnlock.shopPrice = 12;
      if (unlockedDefault)
      {
        heavenUnlock.AddItem();
        osmanUnlock.AddItem();
      }
      else
      {
        new FoolBossUnlockSystem.FoolItemPairs(LoadedAssetsHandler.GetCharcater("Esther_CH"), (Item) heavenUnlock, (Item) osmanUnlock).Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 328749, (AchievementUnlockType) 5, "Beheading", "Unlocked a new item.", ResourceLoader.LoadSprite("DivineEllegy.png", 32)).Prepare(Edge.GetID("Esther_CH"), (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 327849, (AchievementUnlockType) 4, "Artificial Adrenaline Rush", "Unlocked a new item.", ResourceLoader.LoadSprite("WitnessEllegy", 32)).Prepare(Edge.GetID("Esther_CH"), (BossType) 9);
      }
    }
  }
}
