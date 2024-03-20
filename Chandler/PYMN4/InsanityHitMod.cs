// Decompiled with JetBrains decompiler
// Type: PYMN4.InsanityHitMod
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

namespace PYMN4
{
  public class InsanityHitMod : IntValueModifier
  {
    public readonly IUnit unit;

    public InsanityHitMod(IUnit unit)
      : base(100)
    {
      this.unit = unit;
    }

    public override int Modify(int value)
    {
      this.unit.SetStoredValue((UnitStoredValueNames) 327748, this.unit.GetStoredValue((UnitStoredValueNames) 327748) + value);
      value = 0;
      return value;
    }
  }
}
