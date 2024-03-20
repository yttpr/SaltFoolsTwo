// Decompiled with JetBrains decompiler
// Type: PYMN4.Hacks
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;

namespace PYMN4
{
  public static class Hacks
  {
    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (MainMenuController).GetMethod("LoadOldRun", ~BindingFlags.Default), typeof (Hacks).GetMethod("LoadOldRun", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (MainMenuController).GetMethod("OnEmbarkPressed", ~BindingFlags.Default), typeof (Hacks).GetMethod("LoadOldRun", ~BindingFlags.Default));
    }

    public static void LoadOldRun(Action<MainMenuController> orig, MainMenuController self)
    {
      orig(self);
      FreeFool.Moon();
      FreeFool.Bartholomew();
      FreeFool.Saline();
      FreeFool.Esther();
      FreeFool.Bola();
    }
  }
}
