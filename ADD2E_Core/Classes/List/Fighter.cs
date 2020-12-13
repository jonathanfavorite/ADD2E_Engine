using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.General;
using ADD2E_Core.Races;
using ADD2E_Core.PlayerCharacter;
using ADD2E_Core.Classes.List.FighterDetails;
namespace ADD2E_Core.Classes.List
{
    public class Fighter : IFighter
    {
        public string Name { get; set; } = "Fighter";

        public List<EAbilityScores> PrimeRequirement { get; set; } = new List<EAbilityScores>();
        public int HitDie { get; set; } = 10;
        public List<ERaces> AllowedRaces { get; set; } = new List<ERaces>();
        public Dictionary<EAbilityScores, int> MinimumAbilityScoreRequirements { get; set; } = new Dictionary<EAbilityScores, int>();
        public List<FighterExperienceLevels> ExperienceLevels { get; set; }
        public Fighter()
        {
            PrimeRequirement.Add(EAbilityScores.Strength);
            MinimumAbilityScoreRequirements.Add(EAbilityScores.Strength, 9);
            AllowedRaces.Add(ERaces.All);
            ExperienceLevels = FormatExperienceLevels();
        }
        public int CalculateHitDie(Player player)
        {
            return 0;
        }
        public List<FighterExperienceLevels> FormatExperienceLevels()
        {
            List<FighterExperienceLevels> returnFighterExpLevels = new List<FighterExperienceLevels>
            {
                new FighterExperienceLevels { Level = 1, Experience = 0, HitDiceAmount = 1},
                new FighterExperienceLevels { Level = 2, Experience = 2000, HitDiceAmount = 2},
                new FighterExperienceLevels { Level = 3, Experience = 4000, HitDiceAmount = 3},
                new FighterExperienceLevels { Level = 4, Experience = 8000, HitDiceAmount = 4},
                new FighterExperienceLevels { Level = 5, Experience = 16000, HitDiceAmount = 5},
                new FighterExperienceLevels { Level = 6, Experience = 32000, HitDiceAmount = 6},
                new FighterExperienceLevels { Level = 7, Experience = 64000, HitDiceAmount = 7},
                new FighterExperienceLevels { Level = 8, Experience = 125000, HitDiceAmount = 8},
                new FighterExperienceLevels { Level = 9, Experience = 250000, HitDiceAmount = 9},
                new FighterExperienceLevels { Level = 10, Experience = 500000, HitDiceAmount = 10, HitDiceAdjustment = 3},
                new FighterExperienceLevels { Level = 11, Experience = 750000, HitDiceAmount = 11, HitDiceAdjustment = 6},
                new FighterExperienceLevels { Level = 12, Experience = 1000000, HitDiceAmount = 12, HitDiceAdjustment = 9},
                new FighterExperienceLevels { Level = 13, Experience = 1250000, HitDiceAmount = 13, HitDiceAdjustment = 12},
                new FighterExperienceLevels { Level = 14, Experience = 1500000, HitDiceAmount = 14, HitDiceAdjustment = 15},
            };
            return returnFighterExpLevels;
        }
        public int MeleeAttacksPerRound(Player player)
        {
            int AtkPerRound = 1;
            if (player.Level <= 6)
            {
                AtkPerRound = 1;
            }
            else if (player.Level <= 12)
            {
                AtkPerRound = 2;
            }
            else
            {
                AtkPerRound = 2;
            }
            return AtkPerRound;
        }
        
    }
}
