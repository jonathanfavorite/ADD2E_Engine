using System;
using System.Collections.Generic;
using System.Text;

namespace ADD2E_Core.General.AbilityScoresList
{
    public class Charisma
    {
        public EAbilityScores Name { get; private set; } = EAbilityScores.Charisma;
        public int Value { get; set; } = 10;
        public int MaximumHenchmen { get; set; } = 4;
        public int LoyaltyBase { get; set; } = 0;
        public int ReactionAdjustment { get; set; } = 0;
    }
}
