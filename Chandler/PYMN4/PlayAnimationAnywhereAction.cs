// Decompiled with JetBrains decompiler
// Type: PYMN4.PlayAnimationAnywhereAction
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using System.Collections;

namespace PYMN4
{
  public class PlayAnimationAnywhereAction : CombatAction
  {
    public AttackVisualsSO _visuals;
    public TargetSlotInfo[] _targets;

    public PlayAnimationAnywhereAction(AttackVisualsSO visuals, TargetSlotInfo[] targets)
    {
      this._visuals = visuals;
      this._targets = targets;
    }

    public override IEnumerator Execute(CombatStats stats)
    {
      if (this._targets.Length != 0)
        yield return (object) stats.combatUI.PlayAbilityAnimation(this._visuals, this._targets, true);
    }
  }
}
