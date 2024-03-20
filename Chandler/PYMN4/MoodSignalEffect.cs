// Decompiled with JetBrains decompiler
// Type: PYMN4.MoodSignalEffect
// Assembly: Chandler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70077DCF-0D44-4526-848C-067B1F97CE1A
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Brutal Orchestra\BepInEx\plugins\Chandler.dll

namespace PYMN4
{
  public class MoodSignalEffect : EffectSO
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      CombatManager.Instance.PostNotification(((TriggerCalls) 327746).ToString(), (object) caster, (object) null);
      string str = "Mood: -" + caster.GetStoredValue((UnitStoredValueNames) 327746).ToString();
      CombatManager.Instance.AddUIAction((CombatAction) new ShowPassiveInformationUIAction(caster.ID, caster.IsUnitCharacter, str, ResourceLoader.LoadSprite("mood", 32)));
      return true;
    }
  }
}
