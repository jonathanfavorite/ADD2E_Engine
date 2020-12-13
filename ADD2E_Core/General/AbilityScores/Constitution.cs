using System;
using System.Collections.Generic;
using System.Text;

namespace ADD2E_Core.General.AbilityScoresList
{
    public class Constitution
    {
        public EAbilityScores Name { get; private set; } = EAbilityScores.Constitution;
        public int Value { get; set; } = 10;
        public int HitPointAdjustment { get; set; } = 0;
        public double SystemShockPercentage { get; set; } = 0.70;
        public double ResurrectionSurvivalPercentage { get; set; } = 0.70;
        public int PoisionSave { get; set; } = 0;

    }
}
