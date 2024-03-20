// Decompiled with JetBrains decompiler
// Type: Hawthorne.PaleHarmEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using System;
using UnityEngine;

namespace Hawthorne
{
  public class PaleHarmEffect : EffectSO
  {
    [SerializeField]
    public bool _justOneTarget;
    [SerializeField]
    public bool _randomBetweenPrevious;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      int maximumHealth = caster.MaximumHealth;
      int currentHealth = caster.CurrentHealth;
      Decimal d = (Decimal) maximumHealth * (Decimal) entryVariable / 100M;
      Decimal num1 = Math.Ceiling(d);
      int num2 = UnityEngine.Random.Range((int) Math.Floor(d), (int) num1 + 1);
      exitAmount += num2;
      int num3 = currentHealth - num2;
      if (num2 > currentHealth)
        num2 = currentHealth;
      caster.Damage(num2, (IUnit) null, (DeathType) 1, -1, false, false, true, (DamageType) 888666);
      return exitAmount > 0;
    }
  }
}
