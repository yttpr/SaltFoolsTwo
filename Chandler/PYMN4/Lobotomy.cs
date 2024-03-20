// Decompiled with JetBrains decompiler
// Type: PYMN4.Lobotomy
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

namespace PYMN4
{
  public static class Lobotomy
  {
    public static void Add()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof (Lobotomy).GetMethod("moodStoredValue", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof (Lobotomy).GetMethod("moodDefenseStoredValue", ~BindingFlags.Default));
      CasterStoredValueChangeEffect instance1 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance1._increase = true;
      instance1._valueName = (UnitStoredValueNames) 327746;
      CasterStoredValueChangeEffect instance2 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance2._increase = true;
      instance2._valueName = (UnitStoredValueNames) 327745;
      FireNoReduce.Add();
      PerformDoubleEffectPassiveAbility instance3 = ScriptableObject.CreateInstance<PerformDoubleEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance3)._passiveName = "Mood";
      ((BasePassiveAbilitySO) instance3).passiveIcon = ResourceLoader.LoadSprite("mood", 32);
      ((BasePassiveAbilitySO) instance3).type = (PassiveAbilityTypes) 327746;
      ((BasePassiveAbilitySO) instance3)._characterDescription = "This character deals less damage depending on how low their Mood is. Damage cannot decrease below 1. \nMood decreases by 1 on taking any damage and at the start of each turn.";
      ((BasePassiveAbilitySO) instance3)._enemyDescription = ((BasePassiveAbilitySO) instance3)._characterDescription;
      ((BasePassiveAbilitySO) instance3).doesPassiveTriggerInformationPanel = false;
      ((BasePassiveAbilitySO) instance3).specialStoredValue = (UnitStoredValueNames) 327746;
      ((BasePassiveAbilitySO) instance3)._triggerOn = new TriggerCalls[2]
      {
        (TriggerCalls) 16,
        (TriggerCalls) 6
      };
      ((BasePassiveAbilitySO) instance3).conditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<MoodCondition>()
      };
      instance3.effects = ExtensionMethods.ToEffectInfoArray(new Effect[2]
      {
        new Effect((EffectSO) instance1, 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<MoodSignalEffect>(), 1, new IntentType?(), Slots.Self)
      });
      instance3._secondTriggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 21
      };
      instance3._secondEffects = ExtensionMethods.ToEffectInfoArray(new Effect[2]
      {
        new Effect((EffectSO) instance1, 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<MoodSignalEffect>(), 1, new IntentType?(), Slots.Self)
      });
      instance3._secondPerformConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<MoodTurnEndCondition>()
      };
      instance3._secondDoesPerformPopUp = false;
      SetCasterExtraSpritesEffect instance4 = ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>();
      instance4._spriteType = (ExtraSpriteType) 327746;
      PerformEffectPassiveAbility instance5 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance5)._passiveName = "Cold-Blooded";
      ((BasePassiveAbilitySO) instance5).passiveIcon = ResourceLoader.LoadSprite("cold", 32);
      ((BasePassiveAbilitySO) instance5).type = (PassiveAbilityTypes) 327745;
      ((BasePassiveAbilitySO) instance5)._characterDescription = "All Fire damage received by this character is multiplied by -1. This damage cannot set this character's health above their maximum health. \nFire on this party member's position does not decrease.";
      ((BasePassiveAbilitySO) instance5)._enemyDescription = ((BasePassiveAbilitySO) instance3)._characterDescription;
      ((BasePassiveAbilitySO) instance5).doesPassiveTriggerInformationPanel = false;
      ((BasePassiveAbilitySO) instance5)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 6
      };
      ((BasePassiveAbilitySO) instance5).conditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<ColdHealCondition>()
      };
      instance5.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) instance4, 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(1))
      });
      PerformEffectPassiveAbility instance6 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance6)._passiveName = "Pyromaniac";
      ((BasePassiveAbilitySO) instance6).passiveIcon = ResourceLoader.LoadSprite("maniac", 32);
      ((BasePassiveAbilitySO) instance6).type = (PassiveAbilityTypes) 327744;
      ((BasePassiveAbilitySO) instance6)._characterDescription = "On reducing Mood to -12, reset Mood and inflict 2-3 Fire to every enemy position and 0-1 Fire to every party member position.";
      ((BasePassiveAbilitySO) instance6)._enemyDescription = ((BasePassiveAbilitySO) instance3)._characterDescription;
      ((BasePassiveAbilitySO) instance6).doesPassiveTriggerInformationPanel = true;
      ((BasePassiveAbilitySO) instance6)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 327746
      };
      ((BasePassiveAbilitySO) instance6).conditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<PyromaniaCondition>()
      };
      instance6.effects = ExtensionMethods.ToEffectInfoArray(new Effect[3]
      {
        new Effect((EffectSO) instance4, 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(2)),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFirePlusUpToOneSlotEffect>(), 0, new IntentType?(), Slots.SlotTarget(new int[9]
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
        }, true)),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFirePlusUpToOneSlotEffect>(), 2, new IntentType?(), Slots.SlotTarget(new int[9]
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
        }))
      });
      Character character = new Character();
      character.name = "Moon";
      character.healthColor = Pigments.Purple;
      character.entityID = (EntityIDs) 327746;
      character.overworldSprite = ResourceLoader.LoadSprite("MoonOver", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
      character.frontSprite = ResourceLoader.LoadSprite("Moon1", 32);
      character.backSprite = ResourceLoader.LoadSprite("BackMoon", 32);
      character.lockedSprite = ResourceLoader.LoadSprite("MoonLock", 32);
      character.unlockedSprite = ResourceLoader.LoadSprite("MoonMenu", 32);
      character.menuChar = true;
      character.isSupport = false;
      character.walksInOverworld = true;
      character.hurtSound = "event:/Combat/StatusEffects/SE_Fire_Apl";
      character.deathSound = LoadedAssetsHandler.GetCharcater("Dimitri_CH").deathSound;
      character.dialogueSound = "event:/Combat/StatusEffects/SE_Fire_Apl";
      character.passives = new BasePassiveAbilitySO[3]
      {
        (BasePassiveAbilitySO) instance3,
        (BasePassiveAbilitySO) instance5,
        (BasePassiveAbilitySO) instance6
      };
      ScriptableObject.CreateInstance<ChangeMaxHealthEffect>()._increase = false;
      ExtraCCSprites_ArraySO instance7 = ScriptableObject.CreateInstance<ExtraCCSprites_ArraySO>();
      instance7._useDefault = (ExtraSpriteType) 0;
      instance7._doesLoop = false;
      instance7._useSpecial = (ExtraSpriteType) 327746;
      instance7._frontSprite = new Sprite[1]
      {
        ResourceLoader.LoadSprite("Moon2")
      };
      instance7._backSprite = new Sprite[1]
      {
        ResourceLoader.LoadSprite("BackMoon")
      };
      character.extraSprites = (ExtraCharacterCombatSpritesSO) instance7;
      Ability ability1 = new Ability();
      ability1.name = "Small Flame";
      ability1.description = "Inflict 1 Fire on the Opposing enemy tile and 1 Fire to self. Prevent Mood from decreasing for the rest of this turn. \nIf this party member was already in Fire, deal 4 indirect damage to this character and refresh them as well.";
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.Red
      };
      ability1.sprite = ResourceLoader.LoadSprite("flame", 32);
      ability1.effects = new Effect[5];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<IfInFireEffect>(), 4, new IntentType?((IntentType) 100), Slots.Self);
      ability1.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, new IntentType?((IntentType) 172), Slots.Front);
      ability1.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, new IntentType?(), Slots.Front, (EffectConditionSO) Conditions.Chance(0));
      ability1.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, new IntentType?((IntentType) 172), Slots.Self);
      ability1.effects[4] = new Effect((EffectSO) instance2, 1, new IntentType?((IntentType) 1), Slots.Self);
      ability1.visuals = LoadedAssetsHandler.GetCharacterAbility("Torch_1_A").visuals;
      ability1.animationTarget = Slots.Self;
      Ability ability2 = ability1.Duplicate();
      ability2.name = "Tender Flame";
      ability2.description = "Inflict 1-2 Fire on the Opposing enemy tile and 1 Fire to self. Prevent Mood from decreasing for the rest of this turn. \nIf this party member was already in Fire, deal 3 indirect damage to this party member and refresh them as well.";
      ability2.effects[0]._entryVariable = 3;
      ability2.effects[2]._condition = (EffectConditionSO) Conditions.Chance(50);
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Artistic Flame";
      ability3.description = "Inflict 1-2 Fire on the Opposing enemy tile and 1 Fire to self. Prevent Mood from decreasing for the rest of this turn. \nIf this party member was already in Fire, deal 2 indirect damage to this party member and refresh them as well.";
      ability3.effects[0]._entryVariable = 2;
      Ability ability4 = ability1.Duplicate();
      ability4.name = "Beautiful Flame";
      ability4.description = "Inflict 2 Fire on the Opposing enemy tile and 1 Fire to self. Prevent Mood from decreasing for the rest of this turn. \nIf this party member was already in Fire, deal 1 indirect damage to self and refresh this party member as well.";
      ability4.effects[0]._entryVariable = 1;
      ability4.effects[1]._entryVariable = 2;
      PreviousEffectCondition instance8 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance8.wasSuccessful = true;
      Ability ability5 = new Ability();
      ability5.name = "Burn Injuries";
      ability5.description = "Deal 12 direct fire damage to the Opposing enemy and inflict 1 Fire on self. Decrease Mood by 2.";
      ability5.cost = new ManaColorSO[3]
      {
        Pigments.Yellow,
        Pigments.Red,
        Pigments.Red
      };
      ability5.sprite = ResourceLoader.LoadSprite("burn");
      ability5.effects = new Effect[4];
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<FireDamageEffect>(), 12, new IntentType?((IntentType) 3), Slots.Front);
      ability5.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, new IntentType?((IntentType) 172), Slots.Self);
      ability5.effects[2] = new Effect((EffectSO) instance1, 2, new IntentType?((IntentType) 100), Slots.Self, (EffectConditionSO) ScriptableObject.CreateInstance<MoodDefendedCondition>());
      ability5.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<MoodSignalEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) instance8);
      ability5.visuals = LoadedAssetsHandler.GetCharacterAbility("Torch_1_A").visuals;
      ability5.animationTarget = Slots.Front;
      Ability ability6 = ability5.Duplicate();
      ability6.name = "Burn Wounds";
      ability6.description = "Deal 14 direct fire damage to the Opposing enemy and inflict 1 Fire on self. Decrease Mood by 3.";
      ability6.effects[0]._entryVariable = 14;
      ability6.effects[2]._entryVariable = 3;
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Burn Chars";
      ability7.description = "Deal 15 direct fire damage to the Opposing enemy and inflict 1 Fire on self. Decrease Mood by 4.";
      ability7.effects[0]._entryVariable = 15;
      ability7.effects[2]._entryVariable = 4;
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Burn Flavor";
      ability8.description = "Deal 17 direct fire damage to the Opposing enemy and inflict 1 Fire on self. Decrease Mood by 5.";
      ability8.effects[0]._entryVariable = 17;
      ability8.effects[0]._intent = new IntentType?((IntentType) 4);
      ability8.effects[2]._entryVariable = 5;
      ScriptableObject.CreateInstance<DamageEffect>()._indirect = true;
      ScriptableObject.CreateInstance<DamageRandomPlusOneEffect>()._indirect = true;
      TargettingAllInFire instance9 = ScriptableObject.CreateInstance<TargettingAllInFire>();
      instance9.getAllies = false;
      instance9.getAllUnitSlots = false;
      Ability ability9 = new Ability();
      ability9.name = "Arson Habits";
      ability9.description = "Copy all Fire on this party member's position onto the Opposing position and deal 7 direct fire damage to all enemies in Fire. \nDecrease Mood by 2.";
      ability9.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Red
      };
      ability9.sprite = ResourceLoader.LoadSprite("arson");
      ability9.effects = new Effect[3];
      ability9.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<CopyFireMoonEffect>(), 1, new IntentType?((IntentType) 172), Slots.Front);
      ability9.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<FireDamageEffect>(), 7, new IntentType?((IntentType) 2), (BaseCombatTargettingSO) instance9);
      ability9.effects[2] = new Effect((EffectSO) instance1, 2, new IntentType?((IntentType) 100), Slots.Self, (EffectConditionSO) ScriptableObject.CreateInstance<MoodDefendedCondition>());
      ability9.visuals = LoadedAssetsHandler.GetCharacterAbility("Sear_1_A").visuals;
      ability9.animationTarget = (BaseCombatTargettingSO) MultiTargetting.Create((BaseCombatTargettingSO) instance9, Slots.Front);
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Arson Tendencies";
      ability10.description = "Copy all Fire on this party member's position onto the Opposing position and deal 10 direct fire damage to all enemies in Fire. \nDecrease Mood by 3.";
      ability10.effects[1]._entryVariable = 10;
      ability10.effects[2]._entryVariable = 3;
      Ability ability11 = ability10.Duplicate();
      ability11.name = "Arson Addiction";
      ability11.description = "Copy all Fire on this party member's position onto the Opposing position and deal 13 direct fire damage to all enemies in Fire. \nDecrease Mood by 4.";
      ability11.effects[1]._entryVariable = 13;
      ability11.effects[1]._intent = new IntentType?((IntentType) 3);
      ability11.effects[2]._entryVariable = 4;
      Ability ability12 = ability11.Duplicate();
      ability12.name = "Arson Necessity";
      ability12.description = "Copy all Fire on this party member's position onto the Opposing position and deal 16 direct fire damage to all enemies in Fire. \nDecrease Mood by 5.";
      ability12.effects[1]._entryVariable = 16;
      ability12.effects[1]._intent = new IntentType?((IntentType) 4);
      ability12.effects[2]._entryVariable = 5;
      character.AddLevel(10, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(12, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(15, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      character.AddLevel(17, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.AddCharacter();
    }

    public static string moodStoredValue(
      Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
      TooltipTextHandlerSO self,
      UnitStoredValueNames storedValue,
      int value)
    {
      Color magenta = Color.magenta;
      string str1;
      if (storedValue == (UnitStoredValueNames)327746)
      {
        if (value <= 0)
        {
          str1 = "";
        }
        else
        {
          string str2 = "Mood: -" + string.Format("{0}", (object) value);
          string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._negativeSTColor) + ">";
          string str4 = "</color>";
          str1 = str3 + str2 + str4;
        }
      }
      else
        str1 = orig(self, storedValue, value);
      return str1;
    }

    public static string moodDefenseStoredValue(
      Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
      TooltipTextHandlerSO self,
      UnitStoredValueNames storedValue,
      int value)
    {
      Color magenta = Color.magenta;
      string str1;
      if (storedValue == (UnitStoredValueNames)327745)
      {
        if (value <= 0)
        {
          str1 = "";
        }
        else
        {
          string str2 = "Mood will not decrease this turn";
          string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._positiveSTColor) + ">";
          string str4 = "</color>";
          str1 = str3 + str2 + str4;
        }
      }
      else
        str1 = orig(self, storedValue, value);
      return str1;
    }

    public static void Items(bool unlockedDefault)
    {
      LobotomyWearable.Setup();
      LobotomyReferenceItem heavenUnlock = new LobotomyReferenceItem();
      heavenUnlock.name = "Weighted Scales";
      heavenUnlock.flavorText = "\"Always rigged in our favor.\"";
      heavenUnlock.description = "Instead of dealing damage, this party member applies an equivalent amount of Pale.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("WeightedScales.png", 32);
      heavenUnlock.trigger = (TriggerCalls) 1000;
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.unlockableID = (UnlockableID) 328746;
      heavenUnlock.namePopup = false;
      heavenUnlock.itemPools = ItemPools.Treasure;
      heavenUnlock.shopPrice = 6;
      heavenUnlock.reference = LobotomyWearable.LobotomyReference.JudgementBird;
      LobotomyReferenceItem osmanUnlock = new LobotomyReferenceItem();
      osmanUnlock.name = "Harmonic Notes";
      osmanUnlock.flavorText = "\"Our voices intertwine, as noise transforms into music.\"";
      osmanUnlock.description = "On dealing damage to an enemy, decrease their maximum health by the same amount.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("OurHarmony.png", 32);
      osmanUnlock.trigger = (TriggerCalls) 1000;
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.unlockableID = (UnlockableID) 327846;
      osmanUnlock.namePopup = false;
      osmanUnlock.itemPools = ItemPools.Treasure;
      osmanUnlock.shopPrice = 7;
      osmanUnlock.reference = LobotomyWearable.LobotomyReference.SingingMachine;
      if (unlockedDefault)
      {
        heavenUnlock.AddItem();
        osmanUnlock.AddItem();
      }
      else
      {
        new FoolBossUnlockSystem.FoolItemPairs(LoadedAssetsHandler.GetCharcater("Moon_CH"), (Item) heavenUnlock, (Item) osmanUnlock).Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 328746, (AchievementUnlockType) 5, "Weighted Scales", "Unlocked a new item.", ResourceLoader.LoadSprite("DivineLobotomy.png", 32)).Prepare(Edge.GetID("Moon_CH"), (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 327846, (AchievementUnlockType) 4, "Harmonic Notes", "Unlocked a new item.", ResourceLoader.LoadSprite("WitnessLobotomy.png", 32)).Prepare(Edge.GetID("Moon_CH"), (BossType) 9);
      }
    }
  }
}
