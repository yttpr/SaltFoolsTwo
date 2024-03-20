// Decompiled with JetBrains decompiler
// Type: PYMN4.PrepareCleanAmbushAction
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using System.Collections;

namespace PYMN4
{
  public class PrepareCleanAmbushAction : CombatAction
  {
    public bool _playerTurn;

    public PrepareCleanAmbushAction(bool PlayerTurn) => this._playerTurn = PlayerTurn;

    public override IEnumerator Execute(CombatStats stats)
    {
      if (this._playerTurn)
        CombatManager.Instance.AddRootAction((CombatAction) new ClearAmbushAction(this._playerTurn));
      else
        CombatManager.Instance.AddSubAction((CombatAction) new ClearAmbushAction(this._playerTurn));
      yield return (object) null;
    }
  }
}
