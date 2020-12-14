using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.General;
using ADD2E_Core.Races;
using ADD2E_Core.Characters;
using ADD2E_Core.Classes.List.FighterDetails;
using ADD2E_Core.Combat;
namespace ADD2E_Core.Classes
{
    public interface IClass
    {
        string Name { get; set; }
        List<EAbilityScores> PrimeRequirement { get; set; }
        int HitDie { get; set; }
        List<ERaces> AllowedRaces { get; set; }
        Dictionary<EAbilityScores, int> MinimumAbilityScoreRequirements { get; set; }
        List<FighterExperienceLevels> ExperienceLevels { get; set; }
        EClassGroup ClassGroup { get; set; }

    }
}
