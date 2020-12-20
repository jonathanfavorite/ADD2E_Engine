using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
using ADD2E_Core.Interfaces;
namespace ADD2E_Core.Models
{
    public class Constitution : IAbilityScore
    {
        public AbilityScoreType Name { get; set; } = AbilityScoreType.Constitution;
        public int Value { get; set; } = 10;
        public int HitPointAdjustment { get; set; } = 0;
        public double SystemShockPercentage { get; set; } = 0.70;
        public double ResurrectionSurvivalPercentage { get; set; } = 0.70;
        public int PoisionSave { get; set; } = 0;
        public int WarriorsHPBonus { get; set; } = 0;
    }
}
