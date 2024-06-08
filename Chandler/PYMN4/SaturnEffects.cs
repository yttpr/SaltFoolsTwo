using System;
using System.Reflection;
using BrutalAPI;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace PYMN4
{
    // Token: 0x0200002D RID: 45
    public static class SaturnEffects
    {
        // Token: 0x060000FA RID: 250 RVA: 0x00007678 File Offset: 0x00005878
        public static void UseMutedAbilityChara(Action<CharacterCombat, int, FilledManaCost[]> orig, CharacterCombat self, int abilityID, FilledManaCost[] filledCost)
        {
            AbilitySO ability = self.CombatAbilities[abilityID].ability;
            bool flag = self.ContainsStatusEffect((StatusEffectType)846750, 0) && ability._abilityName != "Slap";
            if (flag)
            {
                StringReference stringReference = new StringReference(ability.GetAbilityLocData().text);
                CombatManager.Instance.PostNotification(30.ToString(), self, stringReference);
                CombatManager.Instance.AddRootAction(new StartAbilityCostAction(self.ID, filledCost));
                Debug.Log("is muted, used not slap");
                CombatManager.Instance.AddRootAction(new AddLuckyManaAction());
                CombatManager.Instance.AddRootAction(new EndAbilityAction(self.ID, self.IsUnitCharacter));
                self.CanUseAbilities = false;
                self.HasManuallyUsedAbilityThisTurn = true;
                self.UpdatePerformAbilityCounter();
                self.SetVolatileUpdateUIAction(false);
            }
            else
            {
                orig(self, abilityID, filledCost);
            }
        }

        // Token: 0x060000FB RID: 251 RVA: 0x00007768 File Offset: 0x00005968
        public static void UseMutedAbilityEn(Action<EnemyCombat, int> orig, EnemyCombat self, int abilitySlot)
        {
            if (abilitySlot >= self.Abilities.Count)
            {
                abilitySlot = self.Abilities.Count - 1;
            }
            AbilitySO ability = self.Abilities[abilitySlot].ability;
            if (self.ContainsStatusEffect((StatusEffectType)846750) && ability._abilityName != "Slap")
            {
                Debug.Log("is muted, used not slap");
                StringReference args = new StringReference("Slap");
                CombatManager.Instance.PostNotification(TriggerCalls.OnAbilityWillBeUsed.ToString(), self, args);
                Effect slap = new Effect(ScriptableObject.CreateInstance<SlapEffect>(), 1, null, Slots.Self);
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1] { slap }), (self as IUnit)));
                self.EndTurn();
                return;
            }
            orig(self, abilitySlot);
        }

        // Token: 0x060000FC RID: 252 RVA: 0x00007834 File Offset: 0x00005A34
        public static void AddMutedStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            SaturnEffects.muted.name = "Muted";
            SaturnEffects.muted.icon = ResourceLoader.LoadSprite("MutedIcon", 32, null);
            SaturnEffects.muted._statusName = "Muted";
            SaturnEffects.muted.statusEffectType = (StatusEffectType)846750;
            SaturnEffects.muted._description = "If this character or enemy attempts to perform an ability other than Slap, it fails. If this character does not have Slap, adds it as an additional ability; enemies simply perform Slap instead of their listed ability. \nReduce by 1 at the end of each turn.";
            SaturnEffects.muted._applied_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType)10].AppliedSoundEvent;
            SaturnEffects.muted._updated_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType)10].UpdatedSoundEvent;
            SaturnEffects.muted._removed_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType)10].RemovedSoundEvent;
            StatusEffectInfoSO statusEffectInfoSO;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)846750, out statusEffectInfoSO);
            bool flag = statusEffectInfoSO == null;
            if (flag)
            {
                self._stats.statusEffectDataBase.Add((StatusEffectType)846750, SaturnEffects.muted);
            }
        }

        // Token: 0x060000FD RID: 253 RVA: 0x00007948 File Offset: 0x00005B48
        public static void MutedIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            SaturnEffects.mutedIntent._type = (IntentType)846750;
            SaturnEffects.mutedIntent._sprite = ResourceLoader.LoadSprite("MutedIcon", 32, null);
            SaturnEffects.mutedIntent._color = Color.white;
            SaturnEffects.mutedIntent._sound = self._intentDB[(IntentType)158]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)846750, out intentInfo);
            bool flag = intentInfo == null;
            if (flag)
            {
                self._intentDB.Add((IntentType)846750, SaturnEffects.mutedIntent);
            }
        }

        // Token: 0x060000FE RID: 254 RVA: 0x000079EC File Offset: 0x00005BEC
        public static void AddPaleStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            SaturnEffects.pale.name = "Pale";
            SaturnEffects.pale.icon = ResourceLoader.LoadSprite("PaleStatus", 32, null);
            SaturnEffects.pale._statusName = "Pale";
            SaturnEffects.pale.statusEffectType = (StatusEffectType)888666;
            SaturnEffects.pale._description = "Upon taking indirect damage, deal all stacks of Pale as a percent of maximum health damage. This damage ignores damage modifiers. \nThis status is prevented from activating on character's if they take no damage. This is not the same for enemies.";
            SaturnEffects.pale._applied_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType)5].AppliedSoundEvent;
            SaturnEffects.pale._updated_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType)5].UpdatedSoundEvent;
            SaturnEffects.pale._removed_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType)5].RemovedSoundEvent;
            StatusEffectInfoSO statusEffectInfoSO;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)888666, out statusEffectInfoSO);
            bool flag = statusEffectInfoSO == null;
            if (flag)
            {
                self._stats.statusEffectDataBase.Add((StatusEffectType)888666, SaturnEffects.pale);
            }
        }

        // Token: 0x060000FF RID: 255 RVA: 0x00007AFC File Offset: 0x00005CFC
        public static void PaleIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            SaturnEffects.paleIntent._type = (IntentType)666888;
            SaturnEffects.paleIntent._sprite = ResourceLoader.LoadSprite("PaleStatus", 32, null);
            SaturnEffects.paleIntent._color = Color.white;
            SaturnEffects.paleIntent._sound = self._intentDB[(IntentType)154]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)666888, out intentInfo);
            bool flag = intentInfo == null;
            if (flag)
            {
                self._intentDB.Add((IntentType)666888, SaturnEffects.paleIntent);
            }
        }

        // Token: 0x06000100 RID: 256 RVA: 0x00007BA0 File Offset: 0x00005DA0
        public static void AddAnestheticsStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            orig(self);
            SaturnEffects.anesthetics.name = "Anesthetics";
            SaturnEffects.anesthetics.icon = ResourceLoader.LoadSprite("anesthetics2", 32, null);
            SaturnEffects.anesthetics._statusName = "Anesthetics";
            SaturnEffects.anesthetics.statusEffectType = (StatusEffectType)204308;
            SaturnEffects.anesthetics._description = "All damage received will be decreased by 1 for each Anesthetic, this applies to both direct and indirect damage. This effect cannot decrease damage to levels below zero. Decreases by 1 at the start of each turn.";
            SaturnEffects.anesthetics._applied_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType)11].AppliedSoundEvent;
            SaturnEffects.anesthetics._updated_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType)11].UpdatedSoundEvent;
            SaturnEffects.anesthetics._removed_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType)11].RemovedSoundEvent;
            StatusEffectInfoSO statusEffectInfoSO;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)204308, out statusEffectInfoSO);
            bool flag = statusEffectInfoSO == null;
            if (flag)
            {
                self._stats.statusEffectDataBase.Add((StatusEffectType)204308, SaturnEffects.anesthetics);
            }
        }

        // Token: 0x06000101 RID: 257 RVA: 0x00007CB4 File Offset: 0x00005EB4
        public static void AnestheticsIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            orig(self);
            SaturnEffects.anestheticsIntent._type = (IntentType)987898;
            SaturnEffects.anestheticsIntent._sprite = ResourceLoader.LoadSprite("anesthetics2", 32, null);
            SaturnEffects.anestheticsIntent._color = Color.white;
            SaturnEffects.anestheticsIntent._sound = self._intentDB[(IntentType)159]._sound;
            IntentInfo intentInfo;
            self._intentDB.TryGetValue((IntentType)987898, out intentInfo);
            bool flag = intentInfo == null;
            if (flag)
            {
                self._intentDB.Add((IntentType)987898, SaturnEffects.anestheticsIntent);
            }
        }

        // Token: 0x06000102 RID: 258 RVA: 0x00007D58 File Offset: 0x00005F58
        public static void Add()
        {
            IDetour detour = new Hook(typeof(CombatManager).GetMethod("InitializeCombat", (BindingFlags)(-1)), typeof(SaturnEffects).GetMethod("AddPaleStatusEffect", (BindingFlags)(-1)));
            IDetour detour2 = new Hook(typeof(IntentHandlerSO).GetMethod("Initialize", (BindingFlags)(-1)), typeof(SaturnEffects).GetMethod("PaleIntent", (BindingFlags)(-1)));
            IDetour detour3 = new Hook(typeof(CombatManager).GetMethod("InitializeCombat", (BindingFlags)(-1)), typeof(SaturnEffects).GetMethod("AddAnestheticsStatusEffect", (BindingFlags)(-1)));
            IDetour detour4 = new Hook(typeof(IntentHandlerSO).GetMethod("Initialize", (BindingFlags)(-1)), typeof(SaturnEffects).GetMethod("AnestheticsIntent", (BindingFlags)(-1)));
            IDetour detour5 = new Hook(typeof(CombatManager).GetMethod("InitializeCombat", (BindingFlags)(-1)), typeof(SaturnEffects).GetMethod("AddMutedStatusEffect", (BindingFlags)(-1)));
            IDetour detour6 = new Hook(typeof(IntentHandlerSO).GetMethod("Initialize", (BindingFlags)(-1)), typeof(SaturnEffects).GetMethod("MutedIntent", (BindingFlags)(-1)));
            IDetour detour7 = new Hook(typeof(CharacterCombat).GetMethod("UseAbility", (BindingFlags)(-1)), typeof(SaturnEffects).GetMethod("UseMutedAbilityChara", (BindingFlags)(-1)));
            IDetour detour8 = new Hook(typeof(EnemyCombat).GetMethod("UseAbility", (BindingFlags)(-1)), typeof(SaturnEffects).GetMethod("UseMutedAbilityEn", (BindingFlags)(-1)));
        }

        // Token: 0x0400005B RID: 91
        public static StatusEffectInfoSO muted = ScriptableObject.CreateInstance<StatusEffectInfoSO>();

        // Token: 0x0400005C RID: 92
        public static IntentInfo mutedIntent = new IntentInfoBasic();

        // Token: 0x0400005D RID: 93
        public static StatusEffectInfoSO pale = ScriptableObject.CreateInstance<StatusEffectInfoSO>();

        // Token: 0x0400005E RID: 94
        public static IntentInfo paleIntent = new IntentInfoBasic();

        // Token: 0x0400005F RID: 95
        public static StatusEffectInfoSO anesthetics = ScriptableObject.CreateInstance<StatusEffectInfoSO>();

        // Token: 0x04000060 RID: 96
        public static IntentInfo anestheticsIntent = new IntentInfoBasic();
    }
}
