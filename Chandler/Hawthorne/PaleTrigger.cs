using System;
using BrutalAPI;
using UnityEngine;

namespace Hawthorne
{
    // Token: 0x02000006 RID: 6
    public class PaleTrigger : IntValueModifier
    {
        // Token: 0x06000039 RID: 57 RVA: 0x00002BC5 File Offset: 0x00000DC5
        public PaleTrigger(int newHP, Pale_StatusEffect paleSE, IStatusEffector effector, int amount) : base(888)
        {
            this.newHP = newHP;
            this.paleSE = paleSE;
            this.effector = effector;
            this.amount = amount;
        }

        // Token: 0x0600003A RID: 58 RVA: 0x00002BF4 File Offset: 0x00000DF4
        public override int Modify(int value)
        {
            if (value > 0 && this.effector is IUnit unit)
            {
                Effect effect = new Effect(ScriptableObject.CreateInstance<PaleHarmEffect>(), this.amount, null, Slots.Self, null);
                CombatManager.Instance.AddSubAction(new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[]
                {
                    effect
                }), unit, 0));
            }
            return value;
        }

        // Token: 0x0400000A RID: 10
        public readonly int newHP;

        // Token: 0x0400000B RID: 11
        public readonly Pale_StatusEffect paleSE;

        // Token: 0x0400000C RID: 12
        public readonly IStatusEffector effector;

        // Token: 0x0400000D RID: 13
        public readonly int amount;
    }
}
