using System;

namespace PYMN4
{
    // Token: 0x0200006B RID: 107
    public class BartholomewColorEffect : EffectSO
    {
        // Token: 0x060001CC RID: 460 RVA: 0x0001113C File Offset: 0x0000F33C
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            exitAmount = 0;
            bool flag = PigmentUsedCollector.ID == caster.ID && PigmentUsedCollector.lastUsed.Count > 0;
            if (flag)
            {
                bool flag2 = PigmentUsedCollector.lastUsed[0].healthSprite != null;
                if (flag2)
                {
                    bool flag3 = caster.ChangeHealthColor(PigmentUsedCollector.lastUsed[0]);
                    if (flag3)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
