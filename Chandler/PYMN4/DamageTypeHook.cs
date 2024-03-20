using DG.Tweening;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using TMPro;
using UnityEngine;

namespace PYMN4
{
    public static class DamageTypeHook
    {
        public static void Add()
        {
            IDetour hook = new Hook(typeof(DamageTextOptions).GetMethod("PrepareTextOptions", BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod | BindingFlags.CreateInstance | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.ExactBinding | BindingFlags.SuppressChangeType | BindingFlags.OptionalParamBinding | BindingFlags.IgnoreReturn), typeof(DamageTypeHook).GetMethod("DamageTypeSetter", BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod | BindingFlags.CreateInstance | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.ExactBinding | BindingFlags.SuppressChangeType | BindingFlags.OptionalParamBinding | BindingFlags.IgnoreReturn));
            IDetour detour = new Hook(typeof(UnitSoundHandlerSO).GetMethod("TryGetDamageEventName", BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod | BindingFlags.CreateInstance | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.ExactBinding | BindingFlags.SuppressChangeType | BindingFlags.OptionalParamBinding | BindingFlags.IgnoreReturn), typeof(DamageTypeHook).GetMethod("CustomDamageSound", BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod | BindingFlags.CreateInstance | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.ExactBinding | BindingFlags.SuppressChangeType | BindingFlags.OptionalParamBinding | BindingFlags.IgnoreReturn));
        }

        public static string CustomDamageSound(Func<UnitSoundHandlerSO, DamageType, string> orig, UnitSoundHandlerSO self, DamageType damageType)
        {
            string str;
            str = (damageType != (DamageType)888666 ? orig(self, damageType) : self._linkedEvent);
            return str;
        }

        public static Sequence DamageTypeSetter(Func<DamageTextOptions, CombatText, string, int, Sequence> orig, DamageTextOptions self, CombatText textHolder, string text, int type)
        {
            Sequence sequence;
            if (type != 888666)
            {
                sequence = orig(self, textHolder, text, type);
            }
            else
            {
                TMP_ColorGradient tMPColorGradient = null;
                Color32 color32 = new Color32(63, 205, 189, 255);
                tMPColorGradient = ScriptableObject.CreateInstance<TMP_ColorGradient>();
                tMPColorGradient.bottomLeft = color32;
                tMPColorGradient.bottomRight = color32;
                tMPColorGradient.topLeft = color32;
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