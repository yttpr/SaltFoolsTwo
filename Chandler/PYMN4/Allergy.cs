// Decompiled with JetBrains decompiler
// Type: PYMN4.Allergy
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BrutalAPI;
using System;
using THE_DEAD;
using UnityEngine;

namespace PYMN4
{
  public static class Allergy
  {
    public static void Add()
    {
      // ISSUE: unable to decompile the method.
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
