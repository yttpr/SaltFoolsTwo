// Decompiled with JetBrains decompiler
// Type: PYMN4.MoodValueModifier
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using System;

namespace PYMN4
{
  public class MoodValueModifier : IntValueModifier
  {
    public readonly int toPow;

    public MoodValueModifier(int toPow)
      : base(65)
    {
      this.toPow = toPow;
    }

    public override int Modify(int value) => value > 0 ? Math.Max(value - this.toPow, 1) : value;
  }
}
