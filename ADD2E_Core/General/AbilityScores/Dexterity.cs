using System;
using System.Collections.Generic;
using System.Text;

namespace ADD2E_Core.General.AbilityScoresList
{
    public class Dexterity
    {
        public EAbilityScores Name { get; private set; } = EAbilityScores.Dextarity;
        public int Value { get; set; } = 10;
        public int ReactionAdjustment { get; set; } = 0;
        public int MissleAttackAdjustment { get; set; } = 0;
        public int DefenceAdjustment { get; set; } = 0;
    }
}
