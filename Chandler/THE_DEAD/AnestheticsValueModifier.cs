// Decompiled with JetBrains decompiler
// Type: THE_DEAD.AnestheticsValueModifier
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using System;

namespace THE_DEAD
{
  public class AnestheticsValueModifier : IntValueModifier
  {
    public readonly int toNumb;

    public AnestheticsValueModifier(int toNumb)
      : base(70)
    {
      this.toNumb = toNumb;
    }

    public override int Modify(int value) => value > 0 ? Math.Max(value - this.toNumb, 0) : Math.Max(value, 0);
  }
}
