using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Models
{
    public class Intelligence
    {
        public AbilityScoreType Name { get; private set; } = AbilityScoreType.Intelligence;
        public int Value { get; set; } = 10;
        public int LanguagesKnown { get; set; } = 2;
        public int SpellLevel { get; set; } = 4;
        public double ChanceToLearnSpellPercentage { get; set; } = 0.35;
        public int MaxNumberOfSpells { get; set; } = 5;
    }
}
