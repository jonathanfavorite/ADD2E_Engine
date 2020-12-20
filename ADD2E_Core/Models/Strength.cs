using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
using ADD2E_Core.Interfaces;
namespace ADD2E_Core.Models
{
    public class Strength : IAbilityScore
    {
        public AbilityScoreType Name { get; set; } = AbilityScoreType.Strength;
        public int Value { get; set; } = 10;
        public int HitProb { get; set; } = 0;
        public int MaxPress { get; set; } = 0;
        public int OpenDoors { get; set; } = 0;
        public int DamageAdjustment { get; set; } = 0;
        public double BendBarsPercentage { get; set; } = 0.01;
    }
}
