// Decompiled with JetBrains decompiler
// Type: PYMN4.LobotomyWearable
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using Hawthorne;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;


namespace PYMN4
{
  public class LobotomyWearable : BaseWearableSO
  {
    public LobotomyWearable.LobotomyReference reference;
    public IUnit SingingMachineTarget = (IUnit) null;

    public override bool IsItemImmediate => false;

    public override bool DoesItemTrigger => true;

    public override void CustomOnTriggerAttached(IWearableEffector caller)
    {
      base.CustomOnTriggerAttached(caller);
      this.SingingMachineTarget = (IUnit) null;
    }

    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("WillApplyDamage", ~BindingFlags.Default), typeof (LobotomyWearable).GetMethod("WillApplyDamage", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("DidApplyDamage", ~BindingFlags.Default), typeof (LobotomyWearable).GetMethod("DidApplyDamage", ~BindingFlags.Default));
    }

    public static bool ApplyPale(IUnit target, int entry)
    {
      StatusEffectInfoSO statusEffectInfoSo;
      CombatManager.Instance._stats.statusEffectDataBase.TryGetValue((StatusEffectType) 888666, out statusEffectInfoSo);
      int amount = entry;
      IStatusEffect istatusEffect = (IStatusEffect) new Pale_StatusEffect(amount);
      istatusEffect.SetEffectInformation(statusEffectInfoSo);
      IStatusEffector istatusEffector = target as IStatusEffector;
      bool flag = false;
      int index1 = 999;
      for (int index2 = 0; index2 < istatusEffector.StatusEffects.Count; ++index2)
      {
        if (istatusEffector.StatusEffects[index2].EffectType == istatusEffect.EffectType)
        {
          index1 = index2;
          flag = true;
        }
      }
      if (flag)
      {
        foreach (MethodBase constructor in ((object) istatusEffector.StatusEffects[index1]).GetType().GetConstructors())
        {
          if (constructor.GetParameters().Length == 2)
            istatusEffect = (IStatusEffect) Activator.CreateInstance(((object) istatusEffector.StatusEffects[index1]).GetType(), (object) amount, (object) 0);
        }
      }
      istatusEffect.SetEffectInformation(statusEffectInfoSo);
      return target.ApplyStatusEffect(istatusEffect, amount);
    }

    public static int WillApplyDamage(
      Func<CharacterCombat, int, IUnit, int> orig,
      CharacterCombat self,
      int amount,
      IUnit targetUnit)
    {
      int entry = orig(self, amount, targetUnit);
      if (self.HasUsableItem && self.HeldItem is LobotomyWearable heldItem)
      {
        if (heldItem.reference == LobotomyWearable.LobotomyReference.JudgementBird)
        {
          CombatManager.Instance.AddUIAction((CombatAction) new ShowItemInformationUIAction(self.ID, "Weighted Scales", false, ResourceLoader.LoadSprite("WeightedScales.png", 32)));
          if (LobotomyWearable.ApplyPale(targetUnit, entry))
            return 0;
        }
        else if (heldItem.reference == LobotomyWearable.LobotomyReference.SingingMachine)
          heldItem.SingingMachineTarget = targetUnit;
      }
      return entry;
    }

    public static void DidApplyDamage(
      Action<CharacterCombat, int> orig,
      CharacterCombat self,
      int amount)
    {
      orig(self, amount);
      
      bool yea = self.HasUsableItem && self.HeldItem is LobotomyWearable;
            if (!yea) return;
            LobotomyWearable heldItem = self.HeldItem as LobotomyWearable;
      if (heldItem.reference != LobotomyWearable.LobotomyReference.SingingMachine || heldItem.SingingMachineTarget == null)
        return;
      CombatManager.Instance.AddSubAction((CombatAction) new HarmonyLobotomyAction((IUnit) self, heldItem.SingingMachineTarget, amount));
      heldItem.SingingMachineTarget = (IUnit) null;
    }

    public enum LobotomyReference
    {
      StandardTrainingDummyRabbit = 0,
      OneSinAndAHundredGoodDeeds = 3,
      QueenOfHatred = 4,
      HappyTeddyBear = 6,
      RedShoes = 8,
      Theresia = 9,
      OldLady = 12, // 0x0000000C
      NamelessFetus = 15, // 0x0000000F
      LadyFacingTheWall = 18, // 0x00000012
      NothingThere = 20, // 0x00000014
      Mhz = 27, // 0x0000001B
      SingingMachine = 30, // 0x0000001E
      SilentOrchestra = 31, // 0x0000001F
      WarmHeartedWoodsman = 32, // 0x00000020
      SnowQueen = 37, // 0x00000025
      BigBird = 40, // 0x00000028
      AllAroundHelper = 41, // 0x00000029
      SnowWhitesApple = 42, // 0x0000002A
      SpiderBud = 43, // 0x0000002B
      BeautyAndTheBeast = 44, // 0x0000002C
      PlagueDoctor = 45, // 0x0000002D
      WhiteNight = 46, // 0x0000002E
      DontTouchMe = 47, // 0x0000002F
      RudoltaOfTheSleigh = 49, // 0x00000031
      QueenBee = 50, // 0x00000032
      BloodBath = 51, // 0x00000033
      OpenedCanOfWellCheers = 52, // 0x00000034
      Alruine = 53, // 0x00000035
      ForsakenMurderer = 54, // 0x00000036
      ChildOfTheGalaxy = 55, // 0x00000037
      PunishingBird = 56, // 0x00000038
      RedRidingHoodMercenary = 57, // 0x00000039
      BigAndWillBeBadWolf = 58, // 0x0000003A
      BaldIsAwsome = 59, // 0x0000003B
      FragmentOfTheUniverse = 60, // 0x0000003C
      CrumblingArmor = 61, // 0x0000003D
      JudgementBird = 62, // 0x0000003E
      ApocalypseBird = 63, // 0x0000003F
      KingOfGreed = 64, // 0x00000040
      PriceOfSilence = 65, // 0x00000041
      LittlePrince = 66, // 0x00000042
      Laetitia = 67, // 0x00000043
      FuneralOfTheDeadButterflies = 68, // 0x00000044
      DerFreischutz = 69, // 0x00000045
      DreamOfABlackSwan = 70, // 0x00000046
      DreamingCurrent = 71, // 0x00000047
      BurrowingHeaven = 72, // 0x00000048
      KnightOfDespair = 73, // 0x00000049
      NakedNest = 74, // 0x0000004A
      MountainOfSmilingBodies = 75, // 0x0000004B
      Schadenfreude = 76, // 0x0000004C
      HeartOfAspiration = 77, // 0x0000004D
      NotesFromACrazedResearcher = 78, // 0x0000004E
      FleshIdol = 79, // 0x0000004F
      SapOfTheWorldTree = 80, // 0x00000050
      MirrorOfAdjustment = 81, // 0x00000051
      ShelterFromMarch = 82, // 0x00000052
      FairyFestival = 83, // 0x00000053
      MeatFlower = 84, // 0x00000054
      WeCanChangeAnything = 85, // 0x00000055
      ExpressTrainToHell = 86, // 0x00000056
      ScarecrowSearchingForWisdom = 87, // 0x00000057
      DimensionalRefractionVariant = 88, // 0x00000058
      Censored = 89, // 0x00000059
      SkinProphecy = 90, // 0x0000005A
      PortraitOfAnotherWorld = 91, // 0x0000005B
      TodaysShyLook = 92, // 0x0000005C
      BlueStar = 93, // 0x0000005D
      YouMustBeHappy = 94, // 0x0000005E
      LuminousBracelet = 95, // 0x0000005F
      BehaviorAdjustment = 96, // 0x00000060
      OldFaithAndPromise = 97, // 0x00000061
      Porccubus = 98, // 0x00000062
      VoidDream = 99, // 0x00000063
      GraveOfTheCherryBlossoms = 100, // 0x00000064
      Firebird = 101, // 0x00000065
      Yin = 102, // 0x00000066
      Yang = 103, // 0x00000067
      BackwardsClock = 104, // 0x00000068
      IlPiantoDellaLuna = 105, // 0x00000069
      ArmyInBlack = 106, // 0x0000006A
      Ppodae = 107, // 0x0000006B
      ParasiteTree = 108, // 0x0000006C
      MeltingLove = 109, // 0x0000006D
      CloudedMonk = 110, // 0x0000006E
    }
  }
}
