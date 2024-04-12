// Decompiled with JetBrains decompiler
// Type: PYMN4.Edge
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using BepInEx;
using System.Collections.Generic;
using UnityEngine;

namespace PYMN4
{
  [BepInPlugin("Salt.Chandler", "Salt Fools 2?? (\"TM\")", "1.3.8")]
    [BepInDependency("Bones404.BrutalAPI", (BepInDependency.DependencyFlags)1)]
    public class Edge : BaseUnityPlugin
  {
    public static AssetBundle assets;

    public void Awake()
    {
      Edge.assets = AssetBundle.LoadFromMemory(ResourceLoader.ResourceBinary("chandler"));
      FoolBossUnlockSystem.Setup();
      SaturnEffects.Add();
      Lobotomy.Add();
      Stereosity.Add();
      Allergy.Add();
      DamageTypeHook.Add();
      Ellegy.Add();
      Dodge.Add();
      Acid.Add();
      DelayedAttackManager.Setup();
      AmbushManager.Setup();
      Patiently.Add();
      Lobotomy.Items(false);
      Stereosity.Items(false);
      Allergy.Items(false);
      Ellegy.Items(false);
      Patiently.Items(false);
      YarnMand.Setup();
      RealConfig.Setup();
      Unlocking unlocking = new Unlocking(RealConfig.Check("DoQuests"));
      Unlocking.Setup();
      Unlock.Setup();
      Hacks.Setup();
      Quests.Setup();
      FreeFool.Moon();
      FreeFool.Bartholomew();
      FreeFool.Saline();
      FreeFool.Esther();
      FreeFool.Bola();
      FreeFool.Add();
      Debug.Log((object) "DAMN DANIEL");
      Debug.Log((object) "Chilly made me say this");
      this.Logger.LogInfo((object) "Salt.Chandler loaded successfully??");
    }

    public static EntityIDs GetID(string id) => LoadedAssetsHandler.GetCharcater(id).characterEntityID;

    public static void RandomAchievos(int amount)
    {
      for (int index = 0; index < amount; ++index)
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) (844699 + index), (AchievementUnlockType) 5, index.ToString(), "Unlocked a new item.", ResourceLoader.LoadSprite("DivineEllegy.png", 32)).Prepare(Edge.GetID("Esther_CH"), (BossType) (844699 + index));
    }

    public static void MoreFool()
    {
      CardTypeInfo cardTypeInfo1 = new CardTypeInfo();
      cardTypeInfo1._cardInfo = new CardInfo()
      {
        cardType = (CardType) 204,
        pilePosition = (PilePositionType) 2
      };
      cardTypeInfo1._minimumAmount = 20;
      cardTypeInfo1._maximumAmount = 20;
      CardTypeInfo cardTypeInfo2 = new CardTypeInfo();
      cardTypeInfo2._cardInfo = new CardInfo()
      {
        cardType = (CardType) 0,
        pilePosition = (PilePositionType) 2
      };
      cardTypeInfo2._minimumAmount = 20;
      cardTypeInfo2._maximumAmount = 20;
      ZoneBGDataBaseSO zoneDb = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_02") as ZoneBGDataBaseSO;
      List<CardTypeInfo> cardTypeInfoList = new List<CardTypeInfo>((IEnumerable<CardTypeInfo>) zoneDb._deckInfo._possibleCards);
      cardTypeInfoList.Add(cardTypeInfo1);
      cardTypeInfoList.Add(cardTypeInfo2);
      zoneDb._deckInfo._possibleCards = cardTypeInfoList.ToArray();
    }
  }
}
