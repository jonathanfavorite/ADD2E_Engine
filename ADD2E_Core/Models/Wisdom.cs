using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Models
{
    public class Wisdom
    {
        public AbilityScoreType Name { get; private set; } = AbilityScoreType.Wisdom;
        public int Value { get; set; } = 10;
        public int MagicalDefenceAdjustment { get; set; } = 0;
        public int BonusSpells { get; set; } = 0;
        public double ChanceOfSpellFailPercentage { get; set; } = 0.20;
    }
}
