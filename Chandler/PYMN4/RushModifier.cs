// Decompiled with JetBrains decompiler
// Type: PYMN4.RushModifier
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using System;

namespace PYMN4
{
  public class RushModifier : IntValueModifier
  {
    public RushModifier()
      : base(70)
    {
    }

    public override int Modify(int value)
    {
      value = (int) Math.Ceiling((double) ((float) value * 1.5f));
      return value;
    }
  }
}
