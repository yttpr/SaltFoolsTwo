// Decompiled with JetBrains decompiler
// Type: PYMN4.DeathCupBoostAction
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using System.Collections;

namespace PYMN4
{
  public class DeathCupBoostAction : CombatAction
  {
    public IUnit _target;
    public IUnit _caster;

    public DeathCupBoostAction(IUnit caster, IUnit target)
    {
      this._caster = caster;
      this._target = target;
    }

    public override IEnumerator Execute(CombatStats stats)
    {
      CharacterCombat chara = this._caster as CharacterCombat;
      if (chara != null && chara.HasUsableItem && chara.HeldItem is DeathCupWearable)
      {
        CombatManager.Instance.AddUIAction((CombatAction) new ShowItemInformationUIAction(this._caster.ID, "Death Cup", false, ResourceLoader.LoadSprite("DeathCup.png", 32)));
        this._target.Damage(DeathCupWearable.Holders.Count, (IUnit) null, (DeathType) 1, -1, false, false, true, (DamageType) 0);
      }
      yield return (object) null;
    }
  }
}
