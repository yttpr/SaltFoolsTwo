// Decompiled with JetBrains decompiler
// Type: PYMN4.ClearAmbushAction
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

using System.Collections;

namespace PYMN4
{
  public class ClearAmbushAction : CombatAction
  {
    public bool _playerTurn;

    public ClearAmbushAction(bool PlayerTurn) => this._playerTurn = PlayerTurn;

    public override IEnumerator Execute(CombatStats stats)
    {
      if (this._playerTurn)
      {
        foreach (CharacterCombat chara in CombatManager.Instance._stats.CharactersOnField.Values)
          chara.SetStoredValue((UnitStoredValueNames) AmbushManager.Patiently, 0);
      }
      else
      {
        foreach (EnemyCombat enemy in CombatManager.Instance._stats.EnemiesOnField.Values)
          enemy.SetStoredValue((UnitStoredValueNames) AmbushManager.Patiently, 0);
      }
      yield return (object) null;
    }
  }
}
