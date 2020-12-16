using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
using ADD2E_Core.Interfaces;
namespace ADD2E_Core.Models
{
    public class Fighter : IFighter
    {
        public string Name { get; set; } = "Fighter";

        public List<AbilityScoreType> PrimeRequirement { get; set; } = new List<AbilityScoreType>();
        public int HitDie { get; set; } = 10;
        public ClassGroup ClassGroup { get; set; } = ClassGroup.Warrior;
        public List<RaceType> AllowedRaces { get; set; } = new List<RaceType>();
        public Dictionary<AbilityScoreType, int> MinimumAbilityScoreRequirements { get; set; } = new Dictionary<AbilityScoreType, int>();

    }
}
