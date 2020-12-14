using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.General;
namespace ADD2E_Core.General.AbilityScoresList
{
    public class Strength
    {
        public EAbilityScores Name { get; private set; } = EAbilityScores.Strength;
        public int Value { get; set; } = 10;
        public int HitProb { get; set; } = 0;
        public int MaxPress { get; set; } = 0;
        public int OpenDoors { get; set; } = 0;
        public int DamageAdjustment { get; set; } = 0;
        public double BendBarsPercentage { get; set; } = 0.01;
    }
}
