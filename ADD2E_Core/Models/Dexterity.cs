using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Models
{
    public class Dexterity
    {
        public AbilityScoreType Name { get; private set; } = AbilityScoreType.Dextarity;
        public int Value { get; set; } = 10;
        public int ReactionAdjustment { get; set; } = 0;
        public int MissleAttackAdjustment { get; set; } = 0;
        public int DefenceAdjustment { get; set; } = 0;
    }
}
