using DG.Tweening;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

namespace PYMN4
{
    public static class Acid
    {
        public static int acid;

        public static string name;

        public static string description;

        public static Sprite acidSprite;

        public static IntentInfo acidIntent;

        public static StatusEffectInfoSO acidInfo;

        static Acid()
        {
            Acid.acid = 65821;
            Acid.name = "Acid";
            Acid.description = "Deal 3 indirect damage to this unit upon performing an ability. Decrease Acid by 1 at the end of each turn.";
            Acid.acidSprite = ResourceLoader.LoadSprite("Acid.png", 32, null);
            Acid.acidIntent = new IntentInfoBasic();
            Acid.acidInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
        }

        public static void Add()
        {
            IDetour hook = new Hook(typeof(DamageTextOptions).GetMethod("PrepareTextOptions", BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod | BindingFlags.CreateInstance | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.ExactBinding | BindingFlags.SuppressChangeType | BindingFlags.OptionalParamBinding | BindingFlags.IgnoreReturn), typeof(Acid).GetMethod("DamageTypeSetter", BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod | BindingFlags.CreateInstance | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.ExactBinding | BindingFlags.SuppressChangeType | BindingFlags.OptionalParamBinding | BindingFlags.IgnoreReturn));
            IDetour detour = new Hook(typeof(UnitSoundHandlerSO).GetMethod("TryGetDamageEventName", BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod | BindingFlags.CreateInstance | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.ExactBinding | BindingFlags.SuppressChangeType | BindingFlags.OptionalParamBinding | BindingFlags.IgnoreReturn), typeof(Acid).GetMethod("CustomDamageSound", BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod | BindingFlags.CreateInstance | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.ExactBinding | BindingFlags.SuppressChangeType | BindingFlags.OptionalParamBinding | BindingFlags.IgnoreReturn));
            IDetour hook1 = new Hook(typeof(CombatManager).GetMethod("InitializeCombat", BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod | BindingFlags.CreateInstance | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.ExactBinding | BindingFlags.SuppressChangeType | BindingFlags.OptionalParamBinding | BindingFlags.IgnoreReturn), typeof(Acid).GetMethod("AddAcidStatusEffect", BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod | BindingFlags.CreateInstance | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.ExactBinding | BindingFlags.SuppressChangeType | BindingFlags.OptionalParamBinding | BindingFlags.IgnoreReturn));
            IDetour detour1 = new Hook(typeof(IntentHandlerSO).GetMethod("Initialize", BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod | BindingFlags.CreateInstance | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.ExactBinding | BindingFlags.SuppressChangeType | BindingFlags.OptionalParamBinding | BindingFlags.IgnoreReturn), typeof(Acid).GetMethod("AddAcidIntent", BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod | BindingFlags.CreateInstance | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.ExactBinding | BindingFlags.SuppressChangeType | BindingFlags.OptionalParamBinding | BindingFlags.IgnoreReturn));
        }

        public static void AddAcidIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
        {
            IntentInfo intentInfo;
            orig(self);
            Acid.acidIntent._type = (IntentType)Acid.acid;
            Acid.acidIntent._sprite = Acid.acidSprite;
            Acid.acidIntent._color = Color.white;
            Acid.acidIntent._sound = self._intentDB[(IntentType)151]._sound;
            self._intentDB.TryGetValue((IntentType)Acid.acid, out intentInfo);
            if (intentInfo == null)
            {
                self._intentDB.Add((IntentType)Acid.acid, Acid.acidIntent);
            }
        }

        public static void AddAcidStatusEffect(Action<CombatManager> orig, CombatManager self)
        {
            StatusEffectInfoSO statusEffectInfoSO;
            orig(self);
            Acid.acidInfo.name = (Acid.name);
            Acid.acidInfo.icon = Acid.acidSprite;
            Acid.acidInfo._statusName = Acid.name;
            Acid.acidInfo.statusEffectType = (StatusEffectType)Acid.acid;
            Acid.acidInfo._description = Acid.description;
            Acid.acidInfo._applied_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType)2].AppliedSoundEvent;
            Acid.acidInfo._updated_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType)2].UpdatedSoundEvent;
            Acid.acidInfo._removed_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType)2].RemovedSoundEvent;
            self._stats.statusEffectDataBase.TryGetValue((StatusEffectType)Acid.acid, out statusEffectInfoSO);
            if (statusEffectInfoSO == null)
            {
                self._stats.statusEffectDataBase.Add((StatusEffectType)Acid.acid, Acid.acidInfo);
            }
        }

        public static string CustomDamageSound(Func<UnitSoundHandlerSO, DamageType, string> orig, UnitSoundHandlerSO self, DamageType damageType)
        {
            string str;
            str = (damageType != (DamageType)Acid.acid ? orig(self, damageType) : self._rupturedDmgEvent);
            return str;
        }

        public static Sequence DamageTypeSetter(Func<DamageTextOptions, CombatText, string, int, Sequence> orig, DamageTextOptions self, CombatText textHolder, string text, int type)
        {
            Sequence sequence;
            if (type != Acid.acid)
            {
                sequence = orig(self, textHolder, text, type);
            }
            else
            {
                Color32 color32 = new Color32(81, 209, 81, 255);
                Color32 color321 = new Color32(46, 155, 46, 255);
                TMP_ColorGradient tMPColorGradient = ScriptableObject.CreateInstance<TMP_ColorGradient>();
                tMPColorGradient.bottomLeft = color32;
                tMPColorGradient.bottomRight = color321;
                tMPColorGradient.topLeft = color321;
                tMPColorGradient.topRight = color32;
                TextMeshPro textMeshPro = textHolder.Text;
                textMeshPro.text = (text);
                textMeshPro.colorGradientPreset = (tMPColorGradient);
                Transform _transform = textHolder.transform;
                Sequence sequence1 = DOTween.Sequence();
                Tween tween = TweenSettingsExtensions.SetEase<Sequence>(ShortcutExtensions.DOLocalJump(_transform, _transform.position, self._jumpForce * textHolder.Scale, 1, self._jumpTime, false), (Ease)1);
                TweenSettingsExtensions.Append(sequence1, tween);
                sequence = sequence1;
            }
            return sequence;
        }
    }
}