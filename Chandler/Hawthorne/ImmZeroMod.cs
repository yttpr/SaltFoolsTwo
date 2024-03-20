// Decompiled with JetBrains decompiler
// Type: Hawthorne.ImmZeroMod
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

namespace Hawthorne
{
  public class ImmZeroMod : IntValueModifier
  {
    public readonly int amount;

    public ImmZeroMod()
      : base(5)
    {
    }

    public override int Modify(int value) => 0;
  }
}
