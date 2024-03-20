// Decompiled with JetBrains decompiler
// Type: PYMN4.BeheadModifier
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

namespace PYMN4
{
  public class BeheadModifier : IntValueModifier
  {
    public readonly IUnit self;

    public BeheadModifier(IUnit unit)
      : base(1200)
    {
      this.self = unit;
    }

    public override int Modify(int value)
    {
      if (this.self.CurrentHealth <= 1 || value < this.self.CurrentHealth)
        return value;
      CombatManager.Instance.AddUIAction((CombatAction) new ShowItemInformationUIAction(this.self.ID, "Beheading", false, ResourceLoader.LoadSprite("Guillotine.png", 32)));
      value = this.self.CurrentHealth - 1;
      return value;
    }
  }
}
