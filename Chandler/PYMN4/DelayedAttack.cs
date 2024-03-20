// Decompiled with JetBrains decompiler
// Type: PYMN4.DelayedAttack
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

namespace PYMN4
{
  public class DelayedAttack
  {
    public int Damage;
    public TargetSlotInfo Target;
    public IUnit caster;

    public DelayedAttack(int damage, TargetSlotInfo target, IUnit caster)
    {
      this.Damage = damage;
      this.Target = target;
      this.caster = caster;
    }

    public void Add() => DelayedAttackManager.Attacks.Add(this);

    public int Perform()
    {
      if (this.caster != null && this.caster.IsAlive)
      {
        if (this.Target.HasUnit)
          return this.Target.Unit.Damage(this.caster.WillApplyDamage(this.Damage, this.Target.Unit), this.caster, (DeathType) 1, -1, true, true, false, (DamageType) 0).damageAmount;
      }
      else if (this.Target.HasUnit)
      {
        this.Target.Unit.Damage(this.Damage, (IUnit) null, (DeathType) 1, -1, true, true, false, (DamageType) 0);
        return 0;
      }
      return 0;
    }
  }
}
