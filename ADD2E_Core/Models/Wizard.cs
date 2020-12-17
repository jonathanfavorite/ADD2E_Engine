using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Models
{
    public class Wizard : IWizard
    {
        public string Name { get; set; } = "Wizard";
        public List<AbilityScoreType> PrimeRequirement { get; set; } = new List<AbilityScoreType>();
        public int HitDie { get; set; } = 4;
        public ClassGroup ClassGroup { get; set; } = ClassGroup.Wizard;
        public List<RaceType> AllowedRaces { get; set; } = new List<RaceType>();
        public Dictionary<AbilityScoreType, int> MinimumAbilityScoreRequirements { get; set; } = new Dictionary<AbilityScoreType, int>();
        public Wizard()
        {
            PrimeRequirement.Add(AbilityScoreType.Intelligence);
            MinimumAbilityScoreRequirements.Add(AbilityScoreType.Intelligence, 9);
            AllowedRaces.Add(RaceType.Human);
            AllowedRaces.Add(RaceType.Elf);
            AllowedRaces.Add(RaceType.HalfElf);
        }
    }
}
