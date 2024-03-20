// Decompiled with JetBrains decompiler
// Type: Hawthorne.RemainSameTrigger
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

namespace Hawthorne
{
  public class RemainSameTrigger : IntValueModifier
  {
    public readonly int amount;

    public RemainSameTrigger(int amount)
      : base(1000)
    {
      this.amount = amount;
    }

    public override int Modify(int value) => this.amount;
  }
}
