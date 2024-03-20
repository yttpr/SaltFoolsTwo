using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PYMN4
{
    public static class ScreenShake
    {
        public static OverworldManagerBG overMan;

        public static void Awake(Action<OverworldManagerBG> orig, OverworldManagerBG self)
        {
            orig(self);
            ScreenShake.overMan = self;
        }

        public static AnimationCurve curve()
        {
            Keyframe keyframe = new Keyframe(0f, 0f);
            Keyframe keyframe1 = new Keyframe(0.15f, 50f);
            Keyframe keyframe2 = new Keyframe(0.225f, 45f);
            Keyframe keyframe3 = new Keyframe(1f, 0f);
            return new AnimationCurve(new Keyframe[] { keyframe, keyframe1, keyframe2, keyframe3 });
        }

        public static void Setup()
        {
            IDetour hook = new Hook(typeof(OverworldManagerBG).GetMethod("Awake", BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod | BindingFlags.CreateInstance | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.ExactBinding | BindingFlags.SuppressChangeType | BindingFlags.OptionalParamBinding | BindingFlags.IgnoreReturn), typeof(ScreenShake).GetMethod("Awake", BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod | BindingFlags.CreateInstance | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.ExactBinding | BindingFlags.SuppressChangeType | BindingFlags.OptionalParamBinding | BindingFlags.IgnoreReturn));
        }

        public static void Shake(float duration = 0.5f)
        {
            ScreenShake.overMan.StartCoroutine(ScreenShake.Shaking(duration));
        }

        public static IEnumerator Shaking(float duration)
        {
            Dictionary<Camera, Vector3> cams = new Dictionary<Camera, Vector3>();
            foreach (Camera cam in UnityEngine.Object.FindObjectsOfType<Camera>())
            {
                cams.Add(cam, cam.transform.position);
                //cam = null;
            }
            Camera[] array = null;
            float elapsedTime = 0f;
            AnimationCurve Curve = ScreenShake.curve();
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float strnegth = Curve.Evaluate(elapsedTime / duration);
                foreach (Camera cam2 in cams.Keys)
                {
                    cam2.transform.position = cams[cam2] + UnityEngine.Random.insideUnitSphere;
                    //cam2 = null;
                }
                Dictionary<Camera, Vector3>.KeyCollection.Enumerator enumerator = default(Dictionary<Camera, Vector3>.KeyCollection.Enumerator);
                yield return null;
            }
            foreach (Camera cam3 in cams.Keys)
            {
                cam3.transform.position = cams[cam3];
                //cam3 = null;
            }
            Dictionary<Camera, Vector3>.KeyCollection.Enumerator enumerator2 = default(Dictionary<Camera, Vector3>.KeyCollection.Enumerator);
            yield break;
        }
    }
}