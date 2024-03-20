// Decompiled with JetBrains decompiler
// Type: PYMN4.HarmonyLobotomyAction
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using System;
using System.Collections;

namespace PYMN4
{
  public class HarmonyLobotomyAction : CombatAction
  {
    public IUnit _target;
    public IUnit _caster;
    public int _amount;

    public HarmonyLobotomyAction(IUnit caster, IUnit target, int amount)
    {
      this._caster = caster;
      this._target = target;
      this._amount = amount;
    }

    public override IEnumerator Execute(CombatStats stats)
    {
      if (this._caster is CharacterCombat chara)
      {
        if (chara.HasUsableItem && chara.HeldItem is LobotomyWearable lob && lob.reference == LobotomyWearable.LobotomyReference.SingingMachine)
        {
          CombatManager.Instance.AddUIAction((CombatAction) new ShowItemInformationUIAction(this._caster.ID, "Harmonic Notes", false, ResourceLoader.LoadSprite("OurHarmony.png", 32)));
          int value = Math.Max(1, this._target.MaximumHealth - this._amount);
          this._target.MaximizeHealth(value);
        }
        lob = (LobotomyWearable) null;
      }
      yield return (object) null;
    }
  }
}
