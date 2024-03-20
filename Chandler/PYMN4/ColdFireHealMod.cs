// Decompiled with JetBrains decompiler
// Type: PYMN4.ColdFireHealMod
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

namespace PYMN4
{
  public class ColdFireHealMod : IntValueModifier
  {
    public readonly IUnit unit;

    public ColdFireHealMod(IUnit unit)
      : base(800)
    {
      this.unit = unit;
    }

    public override int Modify(int value)
    {
      value *= -1;
      if (this.unit.CurrentHealth - value > this.unit.MaximumHealth)
        value = this.unit.CurrentHealth - this.unit.MaximumHealth;
      return value;
    }
  }
}
