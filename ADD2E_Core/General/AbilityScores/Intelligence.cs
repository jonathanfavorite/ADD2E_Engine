using System;
using System.Collections.Generic;
using System.Text;

namespace ADD2E_Core.General.AbilityScoresList
{
    public class Intelligence
    {
        public EAbilityScores Name { get; private set; } = EAbilityScores.Intelligence;
        public int Value { get; set; } = 10;
        public int LanguagesKnown { get; set; } = 2;
        public int SpellLevel { get; set; } = 4;
        public double ChanceToLearnSpellPercentage { get; set; } = 0.35;
        public int MaxNumberOfSpells { get; set; } = 5;


    }
}
