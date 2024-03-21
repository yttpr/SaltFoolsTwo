// Decompiled with JetBrains decompiler
// Type: PYMN4.Allergy
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using THE_DEAD;
using UnityEngine;

namespace PYMN4
{
  public static class Allergy
  {
        public static void Add()
        {
            delusion.Add();
            IDetour detour = new Hook(typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", (BindingFlags)(-1)), typeof(Allergy).GetMethod("InsanityStoredValue", (BindingFlags)(-1)));
            SalinePassiveAbility salinePassiveAbility = ScriptableObject.CreateInstance<SalinePassiveAbility>();
            salinePassiveAbility._passiveName = "Insanity";
            salinePassiveAbility.passiveIcon = ResourceLoader.LoadSprite("psycho", 32, null);
            salinePassiveAbility.type = (PassiveAbilityTypes)327748;
            salinePassiveAbility._enemyDescription = "does not peramamently apply gutted to this enemy......";
            salinePassiveAbility._characterDescription = "Instead of taking damage, increase Insanity. At the end of each turn, there is an Insanity% chance to spawn a Delusion. \nInsanity over 100% rolls into an additional enemy. \nInsanity doubles at the end of each turn.";
            salinePassiveAbility.doesPassiveTriggerInformationPanel = true;
            salinePassiveAbility._triggerOn = new TriggerCalls[] { TriggerCalls.OnBeingDamaged, TriggerCalls.OnTurnFinished, TriggerCalls.CanDie };
            Character character = new Character();
            character.name = "Saline";
            character.healthColor = Pigments.Purple;
            character.entityID = (EntityIDs)327748;
            character.overworldSprite = ResourceLoader.LoadSprite("SalineOver", 32, new Vector2?(new Vector2(0.5f, 0f)));
            character.frontSprite = ResourceLoader.LoadSprite("FrontSaline1", 32, null);
            character.backSprite = ResourceLoader.LoadSprite("BackSaline1", 32, null);
            character.lockedSprite = ResourceLoader.LoadSprite("SalineLock", 32, null);
            character.unlockedSprite = ResourceLoader.LoadSprite("SalineMenu", 32, null);
            character.menuChar = true;
            character.isSupport = false;
            character.walksInOverworld = true;
            character.hurtSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").damageSound;
            character.deathSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").deathSound;
            character.dialogueSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").damageSound;
            character.passives = new BasePassiveAbilitySO[]
            {
                salinePassiveAbility,
                Passives.Enfeebled,
                Passives.Withering
            };
            character.passives[2] = UnityEngine.Object.Instantiate<BasePassiveAbilitySO>(character.passives[2]);
            character.passives[2]._characterDescription = "If no other party member's without Withering are alive this party member will instantly die. This effect is checked on a party member's death, and at the end of each turn.";
            character.levels = new CharacterRankedData[4];
            ExtraCCSprites_ArraySO extraCCSprites_ArraySO = ScriptableObject.CreateInstance<ExtraCCSprites_ArraySO>();
            extraCCSprites_ArraySO._useDefault = (ExtraSpriteType)0;
            extraCCSprites_ArraySO._doesLoop = false;
            extraCCSprites_ArraySO._useSpecial = (ExtraSpriteType)327748;
            extraCCSprites_ArraySO._frontSprite = new Sprite[]
            {
                ResourceLoader.LoadSprite("FrontSaline2", 1, null)
            };
            extraCCSprites_ArraySO._backSprite = new Sprite[]
            {
                ResourceLoader.LoadSprite("BackSaline2", 1, null)
            };
            character.extraSprites = extraCCSprites_ArraySO;
            IDetour detour2 = new Hook(typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", (BindingFlags)(-1)), typeof(Allergy).GetMethod("InsanityDoublingStoredValue", (BindingFlags)(-1)));
            CasterStoredValueChangeEffect casterStoredValueChangeEffect = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            casterStoredValueChangeEffect._valueName = (UnitStoredValueNames)327748;
            casterStoredValueChangeEffect._increase = false;
            casterStoredValueChangeEffect._minimumValue = 0;
            CasterStoredValueChangeEffect casterStoredValueChangeEffect2 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            casterStoredValueChangeEffect2._valueName = (UnitStoredValueNames)327748;
            casterStoredValueChangeEffect2._increase = true;
            CasterStoredValueChangeEffect casterStoredValueChangeEffect3 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            casterStoredValueChangeEffect3._valueName = (UnitStoredValueNames)327758;
            casterStoredValueChangeEffect3._increase = true;
            Ability ability = new Ability();
            ability.name = "Take the Pill";
            ability.description = "Apply 1 Anesthetics on self. Decrease Insanity by 30 and prevent it from doubling this turn.";
            ability.cost = new ManaColorSO[]
            {
                Pigments.Yellow
            };
            ability.sprite = ResourceLoader.LoadSprite("pill", 1, null);
            ability.effects = new Effect[3];
            ability.effects[0] = new Effect(ScriptableObject.CreateInstance<ApplyAnestheticsEffect>(), 1, new IntentType?((IntentType)987898), Slots.Self, null);
            ability.effects[1] = new Effect(casterStoredValueChangeEffect, 30, null, Slots.Self, null);
            ability.effects[2] = new Effect(casterStoredValueChangeEffect3, 1, new IntentType?((IntentType)100), Slots.Self, null);
            ability.visuals = null;
            ability.animationTarget = Slots.Self;
            character.baseAbility = ability;
            DamageEffect damageEffect = ScriptableObject.CreateInstance<DamageEffect>();
            damageEffect._ignoreShield = true;
            Ability ability2 = new Ability();
            ability2.name = "Curious Gaze";
            ability2.description = "Deal 6 Shield-Piercing damage to the Opposing enemy. Apply 1 Frail to the Left and Right enemies. Increase Insanity by 5.";
            ability2.cost = new ManaColorSO[]
            {
                Pigments.Purple,
                Pigments.Red
            };
            ability2.sprite = ResourceLoader.LoadSprite("gaze", 1, null);
            ability2.effects = new Effect[3];
            ability2.effects[0] = new Effect(damageEffect, 6, new IntentType?((IntentType)1), Slots.Front, null);
            ability2.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 1, new IntentType?((IntentType)150), Slots.LeftRight, null);
            ability2.effects[2] = new Effect(casterStoredValueChangeEffect2, 5, new IntentType?((IntentType)100), Slots.Self, null);
            ability2.visuals = LoadedAssetsHandler.GetCharacterAbility("Tears_1_A").visuals;
            ability2.animationTarget = Slots.Front;
            Ability ability3 = ability2.Duplicate();
            ability3.name = "Insightful Gaze";
            ability3.description = "Deal 8 Shield-Piercing damage to the Opposing enemy. Apply 1 Frail to the Left and Right enemies. Increase Insanity by 8.";
            ability3.effects[0]._intent = new IntentType?((IntentType)2);
            ability3.effects[0]._entryVariable = 8;
            ability3.effects[2]._entryVariable = 8;
            Ability ability4 = ability3.Duplicate();
            ability4.name = "Pinpoint Gaze";
            ability4.description = "Deal 10 Shield-Piercing damage to the Opposing enemy. Apply 1 Frail to the Left and Right enemies. Increase Insanity by 10.";
            ability4.effects[0]._entryVariable = 10;
            ability4.effects[2]._entryVariable = 10;
            Ability ability5 = ability4.Duplicate();
            ability5.name = "Dreadful Gaze";
            ability5.description = "Deal 12 Shield-Piercing damage to the Opposing enemy. Apply 1 Frail to the Left and Right enemies. Increase Insanity by 12.";
            ability5.effects[0]._intent = new IntentType?((IntentType)3);
            ability5.effects[0]._entryVariable = 12;
            ability5.effects[2]._entryVariable = 12;
            Targetting_ByUnit_Side targetting_ByUnit_Side = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
            targetting_ByUnit_Side.getAllies = false;
            targetting_ByUnit_Side.getAllUnitSlots = false;
            Ability ability6 = new Ability();
            ability6.name = "Reactive Imagination";
            ability6.description = "Deal 10 damage to the Opposing enemy. Apply 1-2 Ruptured to all enemies. Increase Insanity by 10.";
            ability6.cost = new ManaColorSO[]
            {
                Pigments.Purple,
                Pigments.Red,
                Pigments.Red
            };
            ability6.sprite = ResourceLoader.LoadSprite("imagination", 1, null);
            ability6.effects = new Effect[3];
            ability6.effects[0] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 10, new IntentType?((IntentType)2), Slots.Front, null);
            ability6.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyRupturedUpToPlusOneEffect>(), 1, new IntentType?((IntentType)151), targetting_ByUnit_Side, null);
            ability6.effects[2] = new Effect(casterStoredValueChangeEffect2, 10, new IntentType?((IntentType)100), Slots.Self, null);
            ability6.visuals = LoadedAssetsHandler.GetCharacterAbility("OfDeath_1_A").visuals;
            ability6.animationTarget = Slots.Front;
            Ability ability7 = ability6.Duplicate();
            ability7.name = "Lucid Imagination";
            ability7.description = "Deal 13 damage to the Opposing enemy. Apply 2 Ruptured to all enemies. Increase Insanity by 12.";
            ability7.effects[0]._intent = new IntentType?((IntentType)3);
            ability7.effects[0]._entryVariable = 13;
            ability7.effects[1]._entryVariable = 2;
            ability7.effects[1]._effect = ScriptableObject.CreateInstance<ApplyRupturedEffect>();
            ability7.effects[2]._entryVariable = 12;
            Ability ability8 = ability7.Duplicate();
            ability8.name = "Free Imagination";
            ability8.description = "Deal 16 damage to the Opposing enemy. Apply 2 Ruptured to all enemies. Increase Insanity by 15.";
            ability8.effects[0]._intent = new IntentType?((IntentType)4);
            ability8.effects[0]._entryVariable = 16;
            ability8.effects[2]._entryVariable = 15;
            Ability ability9 = ability8.Duplicate();
            ability9.name = "Unbound Imagination";
            ability9.description = "Deal 20 damage to the Opposing enemy. Apply 2-3 Ruptured to all enemies. Increase Insanity by 18.";
            ability9.effects[0]._entryVariable = 20;
            ability9.effects[1]._effect = ScriptableObject.CreateInstance<ApplyRupturedUpToPlusOneEffect>();
            ability9.effects[2]._entryVariable = 18;
            Ability ability10 = new Ability();
            ability10.name = "Crawling Hatred";
            ability10.description = "Curse the Opposing enemy. Insanity% chance to apply 1 Scar to them; does not apply more than 1 Scar at a time. \n40% chance to refresh. Increase Insanity by 1.";
            ability10.cost = new ManaColorSO[]
            {
                Pigments.Purple
            };
            ability10.sprite = ResourceLoader.LoadSprite("hatred", 1, null);
            ability10.effects = new Effect[4];
            ability10.effects[0] = new Effect(ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, new IntentType?((IntentType)152), Slots.Front, null);
            ability10.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyScarsIfInsaneEffect>(), 1, new IntentType?((IntentType)159), Slots.Front, null);
            ability10.effects[2] = new Effect(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, new IntentType?((IntentType)100), Slots.Self, Conditions.Chance(40));
            ability10.effects[3] = new Effect(casterStoredValueChangeEffect2, 1, new IntentType?((IntentType)100), Slots.Self, null);
            ability10.visuals = LoadedAssetsHandler.GetCharacterAbility("Wrath_1_A").visuals;
            ability10.animationTarget = Slots.Front;
            Ability ability11 = ability10.Duplicate();
            ability11.name = "Scuttling Hatred";
            ability11.description = "Curse the Opposing enemy. Insanity% chance to apply 1 Scar to them; does not apply more than 1 Scar at a time. \n50% chance to refresh. Increase Insanity by 1.";
            ability11.effects[2]._condition = Conditions.Chance(50);
            Ability ability12 = ability11.Duplicate();
            ability12.name = "Slithering Hatred";
            ability12.description = "Curse the Opposing enemy. Insanity% chance to apply 1 Scar to them; does not apply more than 1 Scar at a time. \n55% chance to refresh. Increase Insanity by 1.";
            ability12.effects[2]._condition = Conditions.Chance(55);
            Ability ability13 = ability12.Duplicate();
            ability13.name = "Stalking Hatred";
            ability13.description = "Curse the Opposing enemy. Insanity% chance to apply 1 Scar to them; does not apply more than 1 Scar at a time. \n60% chance to refresh. Increase Insanity by 1.";
            ability13.effects[2]._condition = Conditions.Chance(60);
            character.AddLevel(20, new Ability[]
            {
                ability2,
                ability6,
                ability10
            }, 0);
            character.AddLevel(20, new Ability[]
            {
                ability3,
                ability7,
                ability11
            }, 1);
            character.AddLevel(20, new Ability[]
            {
                ability4,
                ability8,
                ability12
            }, 2);
            character.AddLevel(20, new Ability[]
            {
                ability5,
                ability9,
                ability13
            }, 3);
            character.AddCharacter();
        }

        public static string InsanityStoredValue(
      Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
      TooltipTextHandlerSO self,
      UnitStoredValueNames storedValue,
      int value)
    {
      Color magenta = Color.magenta;
      string str1;
      if (storedValue == (UnitStoredValueNames)327748)
      {
        if (value <= 0)
        {
          str1 = "";
        }
        else
        {
          string str2 = "Insanity: " + string.Format("{0}", (object) value);
          string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.magenta) + ">";
          string str4 = "</color>";
          str1 = str3 + str2 + str4;
        }
      }
      else
        str1 = orig(self, storedValue, value);
      return str1;
    }

    public static string InsanityDoublingStoredValue(
      Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
      TooltipTextHandlerSO self,
      UnitStoredValueNames storedValue,
      int value)
    {
      Color magenta = Color.magenta;
      string str1;
      if (storedValue == (UnitStoredValueNames)327758)
      {
        if (value <= 0)
        {
          str1 = "";
        }
        else
        {
          string str2 = "Insanity will not double this turn";
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
      EffectItem heavenUnlock = new EffectItem();
      heavenUnlock.name = "Beta-Blockers";
      heavenUnlock.flavorText = "\"This won't hurt a bit.\"";
      heavenUnlock.description = "Apply 4 Anesthetics to this party member on combat start.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("BetaBlockers.png", 32);
      heavenUnlock.trigger = (TriggerCalls) 25;
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.unlockableID = (UnlockableID) 328748;
      heavenUnlock.namePopup = true;
      heavenUnlock.itemPools = ItemPools.Shop;
      heavenUnlock.shopPrice = 8;
      heavenUnlock.effects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyAnestheticsEffect>(), 4, new IntentType?(), Slots.Self)
      };
      EffectItem osmanUnlock = new EffectItem();
      osmanUnlock.name = "Devil's Purse";
      osmanUnlock.flavorText = "\"You caught a... shark egg sac! 15 cm.\"";
      osmanUnlock.description = "On combat start, heal this party member 15 health and destroy this item.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("DevilPurse.png", 32);
      osmanUnlock.trigger = (TriggerCalls) 32;
      osmanUnlock.consumedOnUse = true;
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.unlockableID = (UnlockableID) 327848;
      osmanUnlock.namePopup = true;
      osmanUnlock.itemPools = ItemPools.Fish;
      osmanUnlock.shopPrice = 4;
      osmanUnlock.effects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 15, new IntentType?(), Slots.Self)
      };
      if (unlockedDefault)
      {
        heavenUnlock.AddItem();
        osmanUnlock.AddItem();
      }
      else
      {
        new FoolBossUnlockSystem.FoolItemPairs(LoadedAssetsHandler.GetCharcater("Saline_CH"), (Item) heavenUnlock, (Item) osmanUnlock, osmanFishPoolWeight: 3).Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 328748, (AchievementUnlockType) 5, "Beta-Blockers", "Unlocked a new item.", ResourceLoader.LoadSprite("DivineAllergy.png", 32)).Prepare(Edge.GetID("Saline_CH"), (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 327848, (AchievementUnlockType) 4, "Devil's Purse", "Unlocked a new item.", ResourceLoader.LoadSprite("WitnessAllergy.png", 32)).Prepare(Edge.GetID("Saline_CH"), (BossType) 9);
      }
    }
  }
}
