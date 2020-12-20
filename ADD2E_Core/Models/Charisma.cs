using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
using ADD2E_Core.Interfaces;
namespace ADD2E_Core.Models
{
    public class Charisma : IAbilityScore
    {
        public AbilityScoreType Name { get; set; } = AbilityScoreType.Charisma;
        public int Value { get; set; } = 10;
        public int MaximumHenchmen { get; set; } = 4;
        public int LoyaltyBase { get; set; } = 0;
        public int ReactionAdjustment { get; set; } = 0;
    }
}
