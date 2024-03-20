// Decompiled with JetBrains decompiler
// Type: PYMN4.DeathCupWearable
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using Tools;
using UnityEngine;

namespace PYMN4
{
  public class DeathCupWearable : BaseWearableSO
  {
    public static List<CharacterCombat> Holders = new List<CharacterCombat>();
    public static OverworldManagerBG overManager = (OverworldManagerBG) null;

    public override bool IsItemImmediate => false;

    public override bool DoesItemTrigger => true;

    public override void CustomOnTriggerAttached(IWearableEffector caller)
    {
      base.CustomOnTriggerAttached(caller);
      DeathCupWearable.Holders.Add(caller as CharacterCombat);
      CombatManager.Instance.AddRootAction((CombatAction) new DeathCupCheckAction());
    }

    public override void CustomOnTriggerDettached(IWearableEffector caller)
    {
      base.CustomOnTriggerDettached(caller);
      DeathCupWearable.Holders.Remove(caller as CharacterCombat);
      CombatManager.Instance.AddRootAction((CombatAction) new DeathCupCheckAction());
    }

    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CombatStats).GetMethod("PlayerTurnStart", ~BindingFlags.Default), typeof (DeathCupWearable).GetMethod("PlayerTurnTick", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (CombatStats).GetMethod("PlayerTurnEnd", ~BindingFlags.Default), typeof (DeathCupWearable).GetMethod("PlayerTurnTick", ~BindingFlags.Default));
      IDetour idetour3 = (IDetour) new Hook((MethodBase) typeof (OverworldManagerBG).GetMethod("Awake", ~BindingFlags.Default), typeof (DeathCupWearable).GetMethod("GetOverworldBG", ~BindingFlags.Default));
      IDetour idetour4 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("WillApplyDamage", ~BindingFlags.Default), typeof (DeathCupWearable).GetMethod("WillApplyDamage", ~BindingFlags.Default));
      IDetour idetour5 = (IDetour) new Hook((MethodBase) typeof (PlayerInGameData).GetMethod("AddNewItem", ~BindingFlags.Default), typeof (DeathCupWearable).GetMethod("AddNewItem", ~BindingFlags.Default));
      IDetour idetour6 = (IDetour) new Hook((MethodBase) typeof (CombatStats).GetMethod("FinalizeCombat", ~BindingFlags.Default), typeof (DeathCupWearable).GetMethod("FinalizeCombat", ~BindingFlags.Default));
      IDetour idetour7 = (IDetour) new Hook((MethodBase) typeof (MainMenuController).GetMethod("OnContinuePressed", ~BindingFlags.Default), typeof (DeathCupWearable).GetMethod("OnContinuePressed", ~BindingFlags.Default));
      IDetour idetour8 = (IDetour) new Hook((MethodBase) typeof (OverworldExtraUIHandler).GetMethod("OpenItemExchangeMenu", ~BindingFlags.Default), typeof (DeathCupWearable).GetMethod("OpenItemExchangeMenu", ~BindingFlags.Default));
    }

    public static void AddNewItem(
      Action<PlayerInGameData, BaseWearableSO> orig,
      PlayerInGameData self,
      BaseWearableSO item)
    {
      orig(self, item);
      if (item is DeathCupWearable && DeathCupWearable.AddCopy(LoadedAssetsHandler.GetWearable("DeathCup_EW") as DeathCupWearable))
        orig(self, item);
      Stereosity.SecondCap(5);
    }

    public static bool AddCopy(DeathCupWearable item)
    {
      bool hasItemSpace = DeathCupWearable.overManager._informationHolder.Run.playerData.HasItemSpace;
      if (hasItemSpace)
        return true;
      StringTrioData itemLocData = item.GetItemLocData();
      string str = string.Format(LocUtils.LocDB.GetUIData((UILocID) 122), (object) itemLocData.text);
      if (!hasItemSpace)
        str = str + "\n" + LocUtils.LocDB.GetUIData((UILocID) 74);
      string uiData = LocUtils.LocDB.GetUIData((UILocID) 37);
      ConfirmDialogReference confirmDialogReference = new ConfirmDialogReference(str, uiData, "", item.wearableImage, itemLocData.description);
      NtfUtils.notifications.PostNotification(Utils.showConfirmDialogNtf, (object) null, (object) confirmDialogReference);
      if (confirmDialogReference.result != (DialogResult)1)
      {
        DeathCupWearable.overManager._soundManager.PlayOneshotSound(DeathCupWearable.overManager._soundManager.itemGet);
        if (!hasItemSpace)
          ((MonoBehaviour) DeathCupWearable.overManager).StartCoroutine(DeathCupWearable.overManager.OpenExchangeItemsOnConfirmation(confirmDialogReference, new BaseWearableSO[1]
          {
            (BaseWearableSO) item
          }));
      }
      return false;
    }

    public static void GetOverworldBG(Action<OverworldManagerBG> orig, OverworldManagerBG self)
    {
      orig(self);
      DeathCupWearable.overManager = self;
      Stereosity.SecondCap(15);
    }

    public static void PlayerTurnTick(Action<CombatStats> orig, CombatStats self)
    {
      orig(self);
      CombatManager.Instance.AddSubAction((CombatAction) new DeathCupCheckAction());
    }

    public static int WillApplyDamage(
      Func<CharacterCombat, int, IUnit, int> orig,
      CharacterCombat self,
      int amount,
      IUnit targetUnit)
    {
      if (DeathCupWearable.Holders.Count > 0)
        CombatManager.Instance.AddSubAction((CombatAction) new DeathCupBoostAction((IUnit) self, targetUnit));
      return orig(self, amount, targetUnit);
    }

    public static void FinalizeCombat(Action<CombatStats> orig, CombatStats self)
    {
      orig(self);
      DeathCupWearable.Holders.Clear();
    }

    public static void OnContinuePressed(Action<MainMenuController> orig, MainMenuController self)
    {
      orig(self);
      DeathCupWearable.Holders.Clear();
      YarnMand.info = self._informationHolder;
    }

        public static void OpenItemExchangeMenu(Action<OverworldExtraUIHandler, BaseWearableSO[]> orig, OverworldExtraUIHandler self, BaseWearableSO[] currentLoot)
        {
            int num = 0;
            int num2 = 0;
            foreach (BaseWearableSO baseWearableSO in currentLoot)
            {
                bool flag = baseWearableSO is DeathCupWearable;
                if (flag)
                {
                    num++;
                }
                bool flag2 = baseWearableSO == LoadedAssetsHandler.GetWearable("DeathCup_EW");
                if (flag2)
                {
                    num2++;
                }
            }
            bool flag3 = num % 2 != 0 && num2 % 2 == 0;
            if (flag3)
            {
                orig(self, new List<BaseWearableSO>(currentLoot)
                {
                    LoadedAssetsHandler.GetWearable("DeathCup_EW")
                }.ToArray());
            }
            else
            {
                orig(self, currentLoot);
            }
        }
    }
}
