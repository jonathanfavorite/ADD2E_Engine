using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Interfaces
{
    public interface IClass
    {
        string Name { get; set; }
        List<AbilityScoreType> PrimeRequirement { get; set; }
        int HitDie { get; set; }
        List<RaceType> AllowedRaces { get; set; }
        Dictionary<AbilityScoreType, int> MinimumAbilityScoreRequirements { get; set; }
        ClassGroup ClassGroup { get; set; }
    }
}
