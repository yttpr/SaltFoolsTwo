// Decompiled with JetBrains decompiler
// Type: PYMN4.Dodge
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace PYMN4
{
  public static class Dodge
  {
    public static int dodge = 588489;
    public static StatusEffectType Type = (StatusEffectType) Dodge.dodge;
    public static TriggerCalls Call = (TriggerCalls) Dodge.dodge;
    public static SwapToSidesEffect swap = ScriptableObject.CreateInstance<SwapToSidesEffect>();
    public static ApplyDodgeEffect dodgeApply = ScriptableObject.CreateInstance<ApplyDodgeEffect>();
    public static Sprite dodgeSprite = ResourceLoader.LoadSprite("Dodge.png", 32);
    public static string name = nameof (Dodge);
    public static int chance = 100;
    public static string description = "On being targetted by an ability by an opponent, " + Dodge.chance.ToString() + "% chance to move left or right to avoid it. " + Dodge.name + " decreases by 1 at the start of each turn and on activation.";
    public static IntentInfo dodgeIntent = (IntentInfo) new IntentInfoBasic();
    public static StatusEffectInfoSO dodgeInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
    public static bool Set = false;

    public static void SwapUnitToSides(TargetSlotInfo slot, IUnit unit)
    {
      int num;
      ((EffectSO) Dodge.swap).PerformEffect(CombatManager.Instance._stats, unit, new TargetSlotInfo[1]
      {
        slot
      }, true, 1, out num);
    }

    public static TargetSlotInfo[] GetTargets(
      Func<BaseCombatTargettingSO, SlotsCombat, int, bool, TargetSlotInfo[]> orig,
      BaseCombatTargettingSO self,
      SlotsCombat slots,
      int casterSlotID,
      bool isCasterCharacter)
    {
      foreach (TargetSlotInfo slot in orig(self, slots, casterSlotID, isCasterCharacter))
      {
        if (slot.HasUnit && slot.Unit.ContainsStatusEffect(Dodge.Type, 0) && UnityEngine.Random.Range(0, 100) < Dodge.chance && slot.Unit.IsUnitCharacter != isCasterCharacter)
        {
          Dodge.SwapUnitToSides(slot, slot.Unit);
          CombatManager.Instance.PostNotification(Dodge.Call.ToString(), (object) slot.Unit, (object) null);
        }
      }
      return orig(self, slots, casterSlotID, isCasterCharacter);
    }

    public static void TickDodge(IUnit unit, TargetSlotInfo slot)
    {
      if (unit.ContainsStatusEffect(Dodge.Type, 2))
      {
        int num;
        ((EffectSO) Dodge.dodgeApply).PerformEffect(CombatManager.Instance._stats, slot.Unit, new TargetSlotInfo[1]
        {
          slot
        }, true, -1, out num);
      }
      else
        unit.TryRemoveStatusEffect(Dodge.Type);
    }

        public static int StartEffect(Func<EffectInfo, CombatStats, IUnit, TargetSlotInfo[], bool, int, int> orig, EffectInfo self, CombatStats stats, IUnit caster, TargetSlotInfo[] possibleTargets, bool areTargetSlots, int previousExitValue)
        {
            bool flag = false;
            List<int> list = new List<int>();
            foreach (TargetSlotInfo targetSlotInfo in possibleTargets)
            {
                bool flag2 = !list.Contains(targetSlotInfo.SlotID);
                if (flag2)
                {
                    list.Add(targetSlotInfo.SlotID);
                }
            }
            bool flag3 = list.Count >= 5;
            if (flag3)
            {
                flag = true;
            }
            bool flag4 = areTargetSlots && !flag;
            if (flag4)
            {
                bool flag5 = false;
                foreach (TargetSlotInfo targetSlotInfo2 in possibleTargets)
                {
                    bool flag6 = targetSlotInfo2.HasUnit && targetSlotInfo2.Unit.ContainsStatusEffect(Dodge.Type, 0);
                    if (flag6)
                    {
                        bool flag7 = UnityEngine.Random.Range(0, 100) < Dodge.chance && targetSlotInfo2.Unit.IsUnitCharacter != caster.IsUnitCharacter;
                        if (flag7)
                        {
                            CombatManager.Instance.PostNotification(Dodge.Call.ToString(), targetSlotInfo2.Unit, null);
                            Dodge.SwapUnitToSides(targetSlotInfo2, targetSlotInfo2.Unit);
                            flag5 = true;
                        }
                    }
                }
                bool flag8 = flag5;
                if (flag8)
                {
                    possibleTargets = ((self.targets != null) ? self.targets.GetTargets(stats.combatSlots, caster.SlotID, caster.IsUnitCharacter) : new TargetSlotInfo[0]);
                    areTargetSlots = (!(self.targets != null) || self.targets.AreTargetSlots);
                }
            }
            return orig(self, stats, caster, possibleTargets, areTargetSlots, previousExitValue);
        }

        public static void AddDodgeIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
    {
      orig(self);
      Dodge.dodgeIntent._type = (IntentType) Dodge.dodge;
      Dodge.dodgeIntent._sprite = Dodge.dodgeSprite;
      Dodge.dodgeIntent._color = Color.white;
      Dodge.dodgeIntent._sound = self._intentDB[(IntentType) 171]._sound;
      IntentInfo intentInfo;
      self._intentDB.TryGetValue((IntentType) Dodge.dodge, out intentInfo);
      if (intentInfo != null)
        return;
      self._intentDB.Add((IntentType) Dodge.dodge, Dodge.dodgeIntent);
    }

    public static void AddDodgeStatus(Action<CombatManager> orig, CombatManager self)
    {
      orig(self);
      Dodge.dodgeInfo.name = Dodge.name;
      Dodge.dodgeInfo.icon = Dodge.dodgeSprite;
      Dodge.dodgeInfo._statusName = Dodge.name;
      Dodge.dodgeInfo.statusEffectType = Dodge.Type;
      Dodge.dodgeInfo._description = Dodge.description;
      Dodge.dodgeInfo._applied_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 2].UpdatedSoundEvent;
      Dodge.dodgeInfo._updated_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 2].UpdatedSoundEvent;
      Dodge.dodgeInfo._removed_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 2].RemovedSoundEvent;
      StatusEffectInfoSO statusEffectInfoSo;
      self._stats.statusEffectDataBase.TryGetValue(Dodge.Type, out statusEffectInfoSo);
      if (statusEffectInfoSo == null)
      {
        self._stats.statusEffectDataBase.Add(Dodge.Type, Dodge.dodgeInfo);
        Dodge.Setup();
      }
      else
        Dodge.Set = true;
    }

    public static bool ApplyStatusEffectCH(
      Func<CharacterCombat, IStatusEffect, int, bool> orig,
      CharacterCombat self,
      IStatusEffect statusEffect,
      int amount)
    {
      for (int index = 0; index < self.StatusEffects.Count; ++index)
      {
        IStatusEffect statusEffect1 = self.StatusEffects[index];
        if (statusEffect1.EffectType == statusEffect.EffectType)
        {
          if (((object) statusEffect).GetType() == ((object) statusEffect1).GetType())
            return orig(self, statusEffect, amount);
          IStatusEffect istatusEffect = statusEffect1;
          foreach (ConstructorInfo constructor in ((object) statusEffect1).GetType().GetConstructors())
          {
            if (constructor.GetParameters().Length == 2)
              istatusEffect = (IStatusEffect) Activator.CreateInstance(((object) statusEffect1).GetType(), (object) statusEffect.StatusContent, (object) statusEffect.Restrictor);
            else if (constructor.GetParameters().Length == 0)
            {
              istatusEffect = (IStatusEffect) Activator.CreateInstance(((object) statusEffect1).GetType());
            }
            else
            {
              if (constructor.GetParameters().Length != 1)
                return false;
              istatusEffect = (IStatusEffect) Activator.CreateInstance(((object) statusEffect1).GetType(), (object) statusEffect.Restrictor);
            }
          }
          istatusEffect.SetEffectInformation(statusEffect.EffectInfo);
          return orig(self, istatusEffect, amount);
        }
      }
      return orig(self, statusEffect, amount);
    }

    public static bool ApplyStatusEffectEN(
      Func<EnemyCombat, IStatusEffect, int, bool> orig,
      EnemyCombat self,
      IStatusEffect statusEffect,
      int amount)
    {
      for (int index = 0; index < self.StatusEffects.Count; ++index)
      {
        IStatusEffect statusEffect1 = self.StatusEffects[index];
        if (statusEffect1.EffectType == statusEffect.EffectType)
        {
          if (((object) statusEffect).GetType() == ((object) statusEffect1).GetType())
            return orig(self, statusEffect, amount);
          IStatusEffect istatusEffect = statusEffect1;
          foreach (ConstructorInfo constructor in ((object) statusEffect1).GetType().GetConstructors())
          {
            if (constructor.GetParameters().Length == 2)
              istatusEffect = (IStatusEffect) Activator.CreateInstance(((object) statusEffect1).GetType(), (object) statusEffect.StatusContent, (object) statusEffect.Restrictor);
            else if (constructor.GetParameters().Length == 0)
            {
              istatusEffect = (IStatusEffect) Activator.CreateInstance(((object) statusEffect1).GetType());
            }
            else
            {
              if (constructor.GetParameters().Length != 1)
                return false;
              istatusEffect = (IStatusEffect) Activator.CreateInstance(((object) statusEffect1).GetType(), (object) statusEffect.Restrictor);
            }
          }
          istatusEffect.SetEffectInformation(statusEffect.EffectInfo);
          return orig(self, istatusEffect, amount);
        }
      }
      return orig(self, statusEffect, amount);
    }

    public static void Add()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof (Dodge).GetMethod("AddDodgeStatus", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (IntentHandlerSO).GetMethod("Initialize", ~BindingFlags.Default), typeof (Dodge).GetMethod("AddDodgeIntent", ~BindingFlags.Default));
      IDetour idetour3 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("ApplyStatusEffect", ~BindingFlags.Default), typeof (Dodge).GetMethod("ApplyStatusEffectCH", ~BindingFlags.Default));
      IDetour idetour4 = (IDetour) new Hook((MethodBase) typeof (EnemyCombat).GetMethod("ApplyStatusEffect", ~BindingFlags.Default), typeof (Dodge).GetMethod("ApplyStatusEffectEN", ~BindingFlags.Default));
    }

    public static void Setup()
    {
      if (Dodge.Set)
        return;
      Dodge.Set = true;
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (EffectInfo).GetMethod("StartEffect", ~BindingFlags.Default), typeof (Dodge).GetMethod("StartEffect", ~BindingFlags.Default));
    }
  }
}
