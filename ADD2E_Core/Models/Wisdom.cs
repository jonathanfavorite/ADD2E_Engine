using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
using ADD2E_Core.Interfaces;
namespace ADD2E_Core.Models
{
    public class Wisdom : IAbilityScore
    {
        public AbilityScoreType Name { get; set; } = AbilityScoreType.Wisdom;
        public int Value { get; set; } = 10;
        public int MagicalDefenceAdjustment { get; set; } = 0;
        public int BonusSpells { get; set; } = 0;
        public double ChanceOfSpellFailPercentage { get; set; } = 0.20;
    }
}
