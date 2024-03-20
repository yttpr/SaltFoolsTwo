// Decompiled with JetBrains decompiler
// Type: PYMN4.Patiently
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using UnityEngine;

namespace PYMN4
{
  public static class Patiently
  {
    public static void Add()
    {
      DamageByStoredValueEffect instance1 = ScriptableObject.CreateInstance<DamageByStoredValueEffect>();
      instance1._valueName = (UnitStoredValueNames) AmbushManager.Patiently;
      PerformEffectPassiveAbility instance2 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance2)._passiveName = "Ambush (4)";
      ((BasePassiveAbilitySO) instance2).passiveIcon = ResourceLoader.LoadSprite("Ambush", 32);
      ((BasePassiveAbilitySO) instance2).type = (PassiveAbilityTypes) 327750;
      ((BasePassiveAbilitySO) instance2)._enemyDescription = "When a party member moves in front of this enemy, deal a specificed amount of damage to them.";
      ((BasePassiveAbilitySO) instance2)._characterDescription = "When an enemy moves in front of this party member, deal a specified amount of damage to them.";
      ((BasePassiveAbilitySO) instance2).doesPassiveTriggerInformationPanel = true;
      instance2.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) instance1, 4, new IntentType?(), Slots.Front)
      });
      ((BasePassiveAbilitySO) instance2)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) AmbushManager.Patiently
      };
      ((BasePassiveAbilitySO) instance2).specialStoredValue = (UnitStoredValueNames) AmbushManager.Patiently;
      Character character = new Character();
      character.name = "Bola";
      character.healthColor = Pigments.Red;
      character.entityID = (EntityIDs) 327750;
      character.overworldSprite = ResourceLoader.LoadSprite("BolaOver", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
      character.frontSprite = ResourceLoader.LoadSprite("BolaFront", 32);
      character.backSprite = ResourceLoader.LoadSprite("BolaBack", 32);
      character.lockedSprite = ResourceLoader.LoadSprite("BolaLock", 32);
      character.unlockedSprite = ResourceLoader.LoadSprite("BolaMenu", 32);
      character.menuChar = true;
      character.isSupport = false;
      character.walksInOverworld = true;
      character.hurtSound = "";
      character.deathSound = LoadedAssetsHandler.GetCharcater("Rags_CH").damageSound;
      character.dialogueSound = "";
      character.passives = new BasePassiveAbilitySO[1]
      {
        (BasePassiveAbilitySO) instance2
      };
      character.levels = new CharacterRankedData[4];
      Ability ability1 = new Ability();
      ability1.name = "Home-Made Tripwires";
      ability1.description = "Apply 1 Dodge to this party member. \nAt the start of the next turn, deal 7 damage to the Far Far Left and Far Far Right current enemy positions.";
      ability1.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
      };
      ability1.sprite = ResourceLoader.LoadSprite("Tripwires");
      ability1.effects = new Effect[4];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyDodgeEffect>(), 1, new IntentType?((IntentType) Dodge.dodge), Slots.Self);
      ability1.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyDodgeEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(0));
      ability1.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[2]
      {
        -3,
        3
      }), (EffectConditionSO) Conditions.Chance(0));
      ability1.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<AddDelayedAttackEffect>(), 7, new IntentType?((IntentType) 2), Slots.SlotTarget(new int[2]
      {
        -3,
        3
      }));
      ability1.visuals = LoadedAssetsHandler.GetEnemyAbility("Wriggle_A").visuals;
      ability1.animationTarget = Slots.SlotTarget(new int[2]
      {
        -3,
        3
      });
      Ability ability2 = ability1.Duplicate();
      ability2.name = "Pre-Prepared Tripwires";
      ability2.description = "Apply 1 Dodge to this party member. \nAt the start of the next turn, deal 9 damage to the Far Far Left and Far Far Right current enemy positions.";
      ability2.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue)
      };
      ability2.effects[3]._entryVariable = 9;
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Preservative Tripwires";
      ability3.description = "Apply 1-2 Dodge to this party member. \nAt the start of the next turn, deal 11 damage to the Far Far Left and Far Far Right current enemy positions.";
      ability3.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue),
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue)
      };
      ability3.effects[1]._condition = (EffectConditionSO) null;
      ability3.effects[3]._entryVariable = 11;
      ability3.effects[3]._intent = new IntentType?((IntentType) 3);
      Ability ability4 = ability3.Duplicate();
      ability4.name = "Industrially Canned Tripwires";
      ability4.description = "Apply 2 Dodge to this party member. \nAt the start of the next turn, deal 13 damage to the Far Far Left and Far Far Right current enemy positions.";
      ability4.cost = new ManaColorSO[3]
      {
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue),
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue),
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue)
      };
      ability4.effects[0]._entryVariable = 2;
      ability4.effects[1]._condition = (EffectConditionSO) Conditions.Chance(0);
      ability4.effects[3]._entryVariable = 13;
      Ability ability5 = ability4.Duplicate();
      ability5.name = "Completely Frozen Tripwires";
      ability5.description = "Apply 2 Dodge to this party member. \nAt the start of the next turn, deal 15 damage to the Far Far Left and Far Far Right current enemy positions.";
      ability5.cost = new ManaColorSO[3]
      {
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue),
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue),
        Pigments.Gray
      };
      ability5.effects[3]._entryVariable = 15;
      CasterStoredValueChangeEffect instance3 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance3._valueName = (UnitStoredValueNames) AmbushManager.Patiently;
      instance3._increase = true;
      Ability ability6 = new Ability();
      ability6.name = "Vegetarian Diversion";
      ability6.description = "Heal this party member 1 health and apply 1 Dodge to them. Increase this party member's Ambush by 4 until the start of the next turn. \nMove the Opposing enemy left or right.";
      ability6.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Yellow
      };
      ability6.sprite = ResourceLoader.LoadSprite("Diversion");
      ability6.effects = new Effect[5];
      ability6.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 1, new IntentType?((IntentType) 20), Slots.Self);
      ability6.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyDodgeEffect>(), 1, new IntentType?((IntentType) Dodge.dodge), Slots.Self);
      ability6.effects[2] = new Effect((EffectSO) instance3, 4, new IntentType?((IntentType) 100), Slots.Self);
      ability6.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 0, new IntentType?(), Slots.Front, (EffectConditionSO) Conditions.Chance(0));
      ability6.effects[4] = new Effect((EffectSO) ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, new IntentType?((IntentType) 40), Slots.Front);
      ability6.visuals = ability1.visuals;
      ability6.animationTarget = Slots.Front;
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Gluten-Free Diversion";
      ability7.description = "Heal this party member 1 health and apply 1 Dodge to them. Increase this party member's Ambush by 4 until the start of the next turn. \nApply 2 Ruptured and move the Opposing enemy left or right.";
      ability7.cost = new ManaColorSO[2]
      {
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue),
        Pigments.Yellow
      };
      ability7.effects[3]._entryVariable = 2;
      ability7.effects[3]._intent = new IntentType?((IntentType) 151);
      ability7.effects[3]._condition = (EffectConditionSO) null;
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Imitation Diversion";
      ability8.description = "Heal this party member 2 health and apply 1 Dodge to them. Increase this party member's Ambush by 5 until the start of the next turn. \nApply 2 Ruptured and move the Opposing enemy left or right.";
      ability8.cost = new ManaColorSO[2]
      {
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue),
        Pigments.SplitPigment(Pigments.Red, Pigments.Yellow)
      };
      ability8.effects[0]._entryVariable = 2;
      ability8.effects[2]._entryVariable = 5;
      Ability ability9 = ability8.Duplicate();
      ability9.name = "Impossible Diversion";
      ability9.description = "Heal this party member 2 health and apply 1 Dodge to them. Increase this party member's Ambush by 6 until the start of the next turn. \nApply 4 Ruptured and move the Opposing enemy left or right.";
      ability9.effects[2]._entryVariable = 6;
      ability9.effects[3]._entryVariable = 4;
      Ability ability10 = ability9.Duplicate();
      ability10.name = "It-Can't-Be Diversion";
      ability10.description = "Heal this party member 3 health and apply 1 Dodge to them. Increase this party member's Ambush by 6 until the start of the next turn. \nApply 4 Ruptured and move the Opposing enemy left or right.";
      ability10.cost = new ManaColorSO[2]
      {
        Pigments.Gray,
        Pigments.SplitPigment(Pigments.Red, Pigments.Yellow)
      };
      ability10.effects[0]._entryVariable = 3;
      Ability ability11 = new Ability();
      ability11.name = "Undercooked Snares";
      ability11.description = "Apply 1 Constricted to the Opposing enemy position. Increase this party member's Ambush by 5 until the start of the next turn. \nAt the start of the next turn, deal 4 damage to the current Opposing enemy position.";
      ability11.cost = new ManaColorSO[4]
      {
        Pigments.Blue,
        Pigments.Red,
        Pigments.Red,
        Pigments.Yellow
      };
      ability11.sprite = ResourceLoader.LoadSprite("Snares");
      ability11.effects = new Effect[3];
      ability11.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 1, new IntentType?((IntentType) 170), Slots.Front);
      ability11.effects[1] = new Effect((EffectSO) instance3, 5, new IntentType?((IntentType) 100), Slots.Self);
      ability11.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<AddDelayedAttackEffect>(), 4, new IntentType?((IntentType) 1), Slots.Front);
      ability11.visuals = ability6.visuals;
      ability11.animationTarget = Slots.Front;
      Ability ability12 = ability11.Duplicate();
      ability12.name = "Medium-Rare Snares";
      ability12.description = "Apply 1 Constricted to the Opposing enemy position. Increase this party member's Ambush by 6 until the start of the next turn. \nAt the start of the next turn, deal 6 damage to the current Opposing enemy position.";
      ability12.cost = new ManaColorSO[4]
      {
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue),
        Pigments.Red,
        Pigments.Red,
        Pigments.Yellow
      };
      ability12.effects[1]._entryVariable = 6;
      ability12.effects[2]._entryVariable = 6;
      Ability ability13 = ability12.Duplicate();
      ability13.name = "Seared Snares";
      ability13.description = "Apply 1 Constricted to the Opposing enemy position. Increase this party member's Ambush by 6 until the start of the next turn. \nAt the start of the next turn, deal 9 damage to the current Opposing enemy position.";
      ability13.cost = new ManaColorSO[4]
      {
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue),
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue),
        Pigments.Red,
        Pigments.Yellow
      };
      ability13.effects[2]._entryVariable = 9;
      ability13.effects[2]._intent = new IntentType?((IntentType) 2);
      Ability ability14 = ability13.Duplicate();
      ability14.name = "Well-Done Snares";
      ability14.description = "Apply 1 Constricted to the Opposing enemy position. Increase this party member's Ambush by 7 until the start of the next turn. \nAt the start of the next turn, deal 12 damage to the current Opposing enemy position.";
      ability14.cost = new ManaColorSO[4]
      {
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue),
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue),
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue),
        Pigments.Yellow
      };
      ability14.effects[1]._entryVariable = 7;
      ability14.effects[2]._entryVariable = 12;
      ability14.effects[2]._intent = new IntentType?((IntentType) 3);
      Ability ability15 = ability14.Duplicate();
      ability15.name = "Overcooked Snares";
      ability15.description = "Apply 1 Constricted to the Opposing enemy position. Increase this party member's Ambush by 7 until the start of the next turn. \nAt the start of the next turn, deal 14 damage to the current Opposing enemy position.";
      ability15.cost = new ManaColorSO[4]
      {
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue),
        Pigments.SplitPigment(Pigments.Red, Pigments.Blue),
        Pigments.Gray,
        Pigments.Yellow
      };
      ability15.effects[2]._entryVariable = 14;
      character.AddLevel(16, new Ability[3]
      {
        ability1,
        ability6,
        ability11
      }, 0);
      character.AddLevel(19, new Ability[3]
      {
        ability2,
        ability7,
        ability12
      }, 1);
      character.AddLevel(22, new Ability[3]
      {
        ability3,
        ability8,
        ability13
      }, 2);
      character.AddLevel(25, new Ability[3]
      {
        ability4,
        ability9,
        ability14
      }, 3);
      character.AddCharacter();
    }

    public static void RabidDog()
    {
      DoubleEffectCondition instance1 = ScriptableObject.CreateInstance<DoubleEffectCondition>();
      instance1.first = (EffectConditionSO) Conditions.Chance(50);
      instance1.second = (EffectConditionSO) HasOpposing.Set(false);
      instance1.And = true;
      PerformEffectPassiveAbility instance2 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance2)._passiveName = "Rabid";
      ((BasePassiveAbilitySO) instance2).passiveIcon = ResourceLoader.LoadSprite("Rabid.png", 32);
      ((BasePassiveAbilitySO) instance2).type = (PassiveAbilityTypes) 327850;
      ((BasePassiveAbilitySO) instance2)._enemyDescription = "At the start of each turn, move left or right 1-3 times or until Opposing a party member, then perform a random ability, then apply 1 Dodge and 1 Stunned to this enemy.";
      ((BasePassiveAbilitySO) instance2)._characterDescription = "At the start of each turn, move left or right 1-3 times or until Opposing an enemy, then perform a random ability, then apply 1 Dodge and 1 Stunned to this party member.";
      ((BasePassiveAbilitySO) instance2).doesPassiveTriggerInformationPanel = true;
      instance2.effects = ExtensionMethods.ToEffectInfoArray(new Effect[6]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) HasOpposing.Set(false)),
        new Effect((EffectSO) ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) instance1),
        new Effect((EffectSO) ScriptableObject.CreateInstance<SwapToSidesEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) instance1),
        new Effect((EffectSO) ScriptableObject.CreateInstance<PerformRandomAbilityEffect>(), 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyDodgeEffect>(), 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyStunnedEffect>(), 1, new IntentType?(), Slots.Self)
      });
      ((BasePassiveAbilitySO) instance2)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 21
      };
      Character character = new Character();
      character.name = "Rabid Dog";
      character.characterID = "RabidDog_CH";
      character.healthColor = Pigments.Red;
      character.entityID = (EntityIDs) 327850;
      character.overworldSprite = ResourceLoader.LoadSprite("DogOver", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
      character.frontSprite = ResourceLoader.LoadSprite("DogFront");
      character.backSprite = ResourceLoader.LoadSprite("DogBack");
      character.lockedSprite = ResourceLoader.LoadSprite("DogMenu");
      character.unlockedSprite = ResourceLoader.LoadSprite("DogMenu");
      character.menuChar = false;
      character.isSupport = false;
      character.walksInOverworld = true;
      character.isSecret = true;
      character.appearsInShops = false;
      character.hurtSound = LoadedAssetsHandler.GetEnemy("Bronzo_Bananas_Mean_EN").damageSound;
      character.deathSound = LoadedAssetsHandler.GetEnemy("Bronzo_Bananas_Mean_EN").deathSound;
      character.dialogueSound = LoadedAssetsHandler.GetEnemy("Bronzo_Bananas_Mean_EN").damageSound;
      character.passives = new BasePassiveAbilitySO[1]
      {
        (BasePassiveAbilitySO) instance2
      };
      character.levels = new CharacterRankedData[1];
      Ability ability = new Ability();
      ability.name = "Rabid Bite";
      ability.description = "Deal 7 damage to the Opposing enemy and inflict 3 Acid upon them.";
      ability.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
      };
      ability.sprite = ResourceLoader.LoadSprite("Bite");
      ability.effects = new Effect[2];
      ability.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 7, new IntentType?((IntentType) 2), Slots.Front);
      ability.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyAcidEffect>(), 3, new IntentType?((IntentType) Acid.acid), Slots.Front);
      ability.visuals = LoadedAssetsHandler.GetEnemyAbility("Chomp_A").visuals;
      ability.animationTarget = Slots.Front;
      character.AddLevel(12, new Ability[1]{ ability }, 0);
      character.usesAllAbilities = true;
      character.usesBaseAbility = false;
      character.AddCharacter();
    }

    public static void Items(bool unlockedDefault)
    {
      RestrainingOrderWearable.Setup();
      RestrainingOrderItem heavenUnlock = new RestrainingOrderItem();
      heavenUnlock.name = "Restraining Order";
      heavenUnlock.flavorText = "\"I feel like the only guy in town\"";
      heavenUnlock.description = "For each empty slot or wall next to a target, deal 25% more damage to them.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("RestrainingOrder.png", 32);
      heavenUnlock.trigger = (TriggerCalls) 1000;
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.unlockableID = (UnlockableID) 328750;
      heavenUnlock.namePopup = false;
      heavenUnlock.itemPools = ItemPools.Shop;
      heavenUnlock.shopPrice = 8;
      Patiently.RabidDog();
      CopyAndSpawnCustomCharacterAnywhereEffect instance = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterAnywhereEffect>();
      instance._characterCopy = "RabidDog_CH";
      instance._permanentSpawn = false;
      instance._rank = 0;
      instance._extraModifiers = new WearableStaticModifierSetterSO[0];
      EffectItem osmanUnlock = new EffectItem();
      osmanUnlock.name = "Rabid Dog";
      osmanUnlock.flavorText = "\"BLOOD!\"";
      osmanUnlock.description = "On combat start, spawn the Rabid Dog.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("RabidDog.png", 32);
      osmanUnlock.trigger = (TriggerCalls) 25;
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.unlockableID = (UnlockableID) 327850;
      osmanUnlock.namePopup = true;
      osmanUnlock.itemPools = ItemPools.Shop;
      osmanUnlock.shopPrice = 7;
      osmanUnlock.effects = new Effect[1]
      {
        new Effect((EffectSO) instance, 1, new IntentType?(), Slots.Self)
      };
      osmanUnlock.consumedOnUse = false;
      if (unlockedDefault)
      {
        heavenUnlock.AddItem();
        osmanUnlock.AddItem();
      }
      else
      {
        new FoolBossUnlockSystem.FoolItemPairs(LoadedAssetsHandler.GetCharcater("Bola_CH"), (Item) heavenUnlock, (Item) osmanUnlock).Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 328750, (AchievementUnlockType) 5, "Restraining Order", "Unlocked a new item.", ResourceLoader.LoadSprite("DivinePatiently.png", 32)).Prepare(Edge.GetID("Bola_CH"), (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 327850, (AchievementUnlockType) 4, "Rabid Dog", "Unlocked a new item.", ResourceLoader.LoadSprite("WitnessPatiently.png", 32)).Prepare(Edge.GetID("Bola_CH"), (BossType) 9);
      }
    }
  }
}
