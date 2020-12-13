using System;
using System.Collections.Generic;
using System.Text;

namespace ADD2E_Core.General.AbilityScoresList
{
    public class Wisdom
    {
        public EAbilityScores Name { get; private set; } = EAbilityScores.Wisdom;
        public int Value { get; set; } = 10;
        public int MagicalDefenceAdjustment { get; set; } = 0;
        public int BonusSpells { get; set; } = 0;
        public double ChanceOfSpellFailPercentage { get; set; } = 0.20;
    }
}
