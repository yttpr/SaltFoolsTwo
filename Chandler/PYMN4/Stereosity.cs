// Decompiled with JetBrains decompiler
// Type: PYMN4.Stereosity
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
  public static class Stereosity
  {
    public static bool Runnable;
    public static bool Ran;

    public static void Add()
    {
      PigmentUsedCollector.Setup();
      BartholomewPassiveAbility instance1 = ScriptableObject.CreateInstance<BartholomewPassiveAbility>();
      instance1._passiveName = "Torn Apart";
      instance1.passiveIcon = ResourceLoader.LoadSprite("GuttedIcon", 32);
      instance1.type = (PassiveAbilityTypes) 2233534;
      instance1._enemyDescription = "Permanently applies Gutted to this enemy.";
      instance1._characterDescription = "Permanently applies Gutted to this character.";
      instance1.doesPassiveTriggerInformationPanel = false;
      instance1._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 5
      };
      instance1._secondTriggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 28
      };
      Character character = new Character();
      character.name = "Bartholomew";
      character.healthColor = Pigments.Blue;
      character.entityID = (EntityIDs) 327747;
      character.overworldSprite = ResourceLoader.LoadSprite("BartholomewOver", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
      character.frontSprite = ResourceLoader.LoadSprite("FrontBartholomew1", 32);
      character.backSprite = ResourceLoader.LoadSprite("BackBartholomew1", 32);
      character.lockedSprite = ResourceLoader.LoadSprite("BartholomewLock", 32);
      character.unlockedSprite = ResourceLoader.LoadSprite("BartholomewMenu", 32);
      character.menuChar = true;
      character.isSupport = true;
      character.walksInOverworld = false;
      character.hurtSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").damageSound;
      character.deathSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").deathSound;
      character.dialogueSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").damageSound;
      character.passives = new BasePassiveAbilitySO[2]
      {
        (BasePassiveAbilitySO) instance1,
        Passives.Withering
      };
      character.levels = new CharacterRankedData[3];
      ExtraCCSprites_ArraySO instance2 = ScriptableObject.CreateInstance<ExtraCCSprites_ArraySO>();
      instance2._useDefault = (ExtraSpriteType) 0;
      instance2._doesLoop = true;
      instance2._useSpecial = (ExtraSpriteType) 327747;
      instance2._frontSprite = new Sprite[4]
      {
        ResourceLoader.LoadSprite("FrontBartholomew1"),
        ResourceLoader.LoadSprite("FrontBartholomew2"),
        ResourceLoader.LoadSprite("FrontBartholomew3"),
        ResourceLoader.LoadSprite("FrontBartholomew4")
      };
      instance2._backSprite = new Sprite[4]
      {
        ResourceLoader.LoadSprite("BackBartholomew1"),
        ResourceLoader.LoadSprite("BackBartholomew2"),
        ResourceLoader.LoadSprite("BackBartholomew3"),
        ResourceLoader.LoadSprite("BackBartholomew4")
      };
      character.extraSprites = (ExtraCharacterCombatSpritesSO) instance2;
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (TooltipTextHandlerSO).GetMethod("ProcessStoredValue", ~BindingFlags.Default), typeof (Stereosity).GetMethod("cursePercentStoredValue", ~BindingFlags.Default));
      CasterStoredValueChangeEffect instance3 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance3._valueName = (UnitStoredValueNames) 327757;
      instance3._increase = true;
      Ability ability1 = new Ability();
      ability1.name = "Whispers of Sleep";
      ability1.description = "Heal 2-4 health to this character. 0% chance to Curse this character. \nIncrease this percent by 3. \n40% chance to refresh this character.";
      ability1.cost = new ManaColorSO[1]{ Pigments.Blue };
      ability1.sprite = ResourceLoader.LoadSprite("whispers");
      ability1.effects = new Effect[4];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealUpToPLusTwoEffect>(), 2, new IntentType?((IntentType) 20), Slots.Self);
      ability1.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<BartholomewApplyCursedEffect>(), 1, new IntentType?((IntentType) 152), Slots.Self);
      ability1.effects[2] = new Effect((EffectSO) instance3, 3, new IntentType?((IntentType) 100), Slots.Self);
      ability1.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(40));
      ability1.visuals = (AttackVisualsSO) null;
      ability1.animationTarget = Slots.Self;
      character.baseAbility = ability1;
      ScriptableObject.CreateInstance<DamageEffect>()._indirect = true;
      DamageEffect instance4 = ScriptableObject.CreateInstance<DamageEffect>();
      instance4._usePreviousExitValue = true;
      Ability ability2 = new Ability();
      ability2.name = "Dim Nausea";
      ability2.description = "Deal 1 direct damage to this character and 4x the amount of damage to the Opposing enemy.";
      ability2.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Red
      };
      ability2.sprite = ResourceLoader.LoadSprite("nausea");
      ability2.effects = new Effect[2];
      ability2.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 1, new IntentType?((IntentType) 0), Slots.Self);
      ability2.effects[1] = new Effect((EffectSO) instance4, 4, new IntentType?((IntentType) 1), Slots.Front);
      ability2.visuals = LoadedAssetsHandler.GetCharacterAbility("Hex_1_A").visuals;
      ability2.animationTarget = Slots.Front;
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Bleached Nausea";
      ability3.description = "Deal 2 direct damage to this character and 4x the amount of damage to the Opposing enemy.";
      ability3.effects[1]._entryVariable = 4;
      ability3.effects[0]._entryVariable = 2;
      Ability ability4 = ability3.Duplicate();
      ability4.name = "Monochrome Nausea";
      ability4.description = "Deal 2 direct damage to this character and 6x the amount of damage to the Opposing enemy.";
      ability4.effects[1]._entryVariable = 6;
      HealEffect instance5 = ScriptableObject.CreateInstance<HealEffect>();
      instance5.usePreviousExitValue = true;
      Ability ability5 = new Ability();
      ability5.name = "Soft Light";
      ability5.description = "Deal 2 damage to this character, and heal the Left and Right allies for the amount of damage taken. \nApply Focused on both.";
      ability5.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.Purple
      };
      ability5.sprite = ResourceLoader.LoadSprite("light");
      ability5.effects = new Effect[3];
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 2, new IntentType?((IntentType) 0), Slots.Self);
      ability5.effects[1] = new Effect((EffectSO) instance5, 1, new IntentType?((IntentType) 20), Slots.Sides);
      ability5.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFocusedEffect>(), 1, new IntentType?((IntentType) 156), Slots.Sides);
      ability5.visuals = LoadedAssetsHandler.LoadCharacterAbility("WholeAgain_1_A").visuals;
      ability5.animationTarget = Slots.Sides;
      Ability ability6 = ability5.Duplicate();
      ability6.name = "Eager Light";
      ability6.description = "Deal 2 damage to this character, and heal the Left and Right allies for 2x the amount of damage taken. \nApply Focused on both.";
      ability6.effects[1]._entryVariable = 2;
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Desperate Light";
      ability7.description = "Deal 2 damage to this character, and heal the Left and Right allies for 3x the amount of damage taken. \nApply Focused on both.";
      ability7.effects[1]._entryVariable = 3;
      ability7.effects[1]._intent = new IntentType?((IntentType) 21);
      ScriptableObject.CreateInstance<PreviousEffectCondition>().wasSuccessful = true;
      PreviousEffectCondition instance6 = ScriptableObject.CreateInstance<PreviousEffectCondition>();
      instance6.wasSuccessful = false;
      instance6.previousAmount = 2;
      Ability ability8 = new Ability();
      ability8.name = "Slow Colors";
      ability8.description = "Attempt to change this party member's health color to the Pigment used for this ability and heal them 4 health. \nMay potentially not work with Split or Custom pigments.";
      ability8.cost = new ManaColorSO[1]{ Pigments.Gray };
      ability8.sprite = ResourceLoader.LoadSprite("colors");
      ability8.effects = new Effect[2];
      ability8.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<BartholomewColorEffect>(), 1, new IntentType?((IntentType) 63), Slots.Self);
      ability8.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 4, new IntentType?((IntentType) 20), Slots.Self);
      ability8.visuals = LoadedAssetsHandler.GetCharacterAbility("Tears_1_A").visuals;
      ability8.animationTarget = Slots.Self;
      Ability ability9 = ability8.Duplicate();
      ability9.name = "Wasting Colors";
      ability9.description = "Attempt to change this party member's health color to the Pigment used for this ability and heal them 5 health. \nMay potentially not work with Split or Custom pigments.";
      ability9.effects[1]._entryVariable = 5;
      ability9.effects[1]._intent = new IntentType?((IntentType) 21);
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Insomniac Colors";
      ability10.description = "Attempt to change this party member's health color to the Pigment used for this ability and heal them 6 health. \nMay potentially not work with Split or Custom pigments.";
      ability10.effects[1]._entryVariable = 6;
      character.AddLevel(12, new Ability[3]
      {
        ability2,
        ability5,
        ability8
      }, 0);
      character.AddLevel(14, new Ability[3]
      {
        ability3,
        ability6,
        ability9
      }, 1);
      character.AddLevel(16, new Ability[3]
      {
        ability4,
        ability7,
        ability10
      }, 2);
      character.AddCharacter();
    }

    public static string cursePercentStoredValue(
      Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
      TooltipTextHandlerSO self,
      UnitStoredValueNames storedValue,
      int value)
    {
      Color magenta = Color.magenta;
      string str1;
      if (storedValue == (UnitStoredValueNames)327757)
      {
        if (value <= 0)
        {
          str1 = "";
        }
        else
        {
          string str2 = "Curse Chance +" + string.Format("{0}", (object) value) + "%";
          string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(self._negativeSTColor) + ">";
          string str4 = "</color>";
          str1 = str3 + str2 + str4;
        }
      }
      else
        str1 = orig(self, storedValue, value);
      return str1;
    }

    public static void Items(bool UnlockedDefault)
    {
      EffectItem heavenUnlock = new EffectItem();
      heavenUnlock.name = "Spider Vinegar";
      heavenUnlock.flavorText = "\"The spiders are fake, but my disgust is real.\"";
      heavenUnlock.description = "On dealing an even amount of damage, attempt to consume 1 pigment of the lucky pigment generator's color. \nOn dealing an odd amount of damage, attempt to produce 1 pigment of the lucky pigment generator's color.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("SpiderVinegar.png", 32);
      heavenUnlock.trigger = (TriggerCalls) 29;
      heavenUnlock.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<OddEvenEffectorCondition>()
      };
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.unlockableID = (UnlockableID) 328747;
      heavenUnlock.namePopup = true;
      heavenUnlock.itemPools = ItemPools.Shop;
      heavenUnlock.shopPrice = 4;
      DeathCupWearable.Setup();
      DeathCupItem osmanUnlock = new DeathCupItem();
      osmanUnlock.name = "Death Cup";
      osmanUnlock.flavorText = "\"Please don't eat it.\"";
      osmanUnlock.description = "Acquiring this item will give you an additional copy, once. \nIf this party member is the only one holding a copy of this item, they die. \nOn dealing damage, for each party member holding a copy of this item in combat, deal 1 indirect damage to the target.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("DeathCup.png", 32);
      osmanUnlock.trigger = (TriggerCalls) 1000;
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.unlockableID = (UnlockableID) 327847;
      osmanUnlock.namePopup = false;
      osmanUnlock.itemPools = ItemPools.Shop;
      osmanUnlock.shopPrice = 5;
      Stereosity.ExtraCap();
      if (UnlockedDefault)
      {
        heavenUnlock.AddItem();
        osmanUnlock.AddItem();
      }
      else
      {
        new FoolBossUnlockSystem.FoolItemPairs(LoadedAssetsHandler.GetCharcater("Bartholomew_CH"), (Item) heavenUnlock, (Item) osmanUnlock).Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 328747, (AchievementUnlockType) 5, "Spider Vinegar", "Unlocked a new item.", ResourceLoader.LoadSprite("DivineStereosity.png", 32)).Prepare(Edge.GetID("Bartholomew_CH"), (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 327847, (AchievementUnlockType) 4, "Death Cup", "Unlocked a new item.", ResourceLoader.LoadSprite("WitnessStereosity.png", 32)).Prepare(Edge.GetID("Bartholomew_CH"), (BossType) 9);
      }
    }

    public static void SecondCap(int percent)
    {
    }

    public static void ExtraCap()
    {
      DeathCupItem deathCupItem = new DeathCupItem();
      deathCupItem.name = "Death Cup";
      deathCupItem.flavorText = "\"Please don't eat it.\"";
      deathCupItem.description = "Acquiring this item will give you an additional copy, once. \nIf this party member is the only one holding a copy of this item, they die. \nOn dealing damage, for each party member holding a copy of this item in combat, deal 1 indirect damage to the target.";
      deathCupItem.sprite = ResourceLoader.LoadSprite("DeathCup.png", 32);
      deathCupItem.trigger = (TriggerCalls) 1000;
      deathCupItem.consumeTrigger = (TriggerCalls) 1000;
      deathCupItem.unlockableID = (UnlockableID) 329547;
      deathCupItem.namePopup = false;
      deathCupItem.itemPools = ItemPools.Extra;
      deathCupItem.shopPrice = 8;
      deathCupItem.AddItem();
    }
  }
}
