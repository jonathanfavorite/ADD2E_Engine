using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
using ADD2E_Core.Models;
using System.Linq;
namespace ADD2E_Core.Services
{
    public class ClassManager
    {
       private Dictionary<ClassType, List<ClassExperienceLevel>> experienceLevels;
       public ClassManager()
        {
            experienceLevels = new Dictionary<ClassType, List<ClassExperienceLevel>>();
            experienceLevels.Add(ClassType.Fighter, FighterExperienceLevels());
        }
        public ClassExperienceLevel getExperienceLevels(ClassType t, int Level = 1)
        {
            return experienceLevels[t].First(l => l.Level == Level);
        }
        private List<ClassExperienceLevel> FighterExperienceLevels()
        {
            List<ClassExperienceLevel> returnFighterExpLevels = new List<ClassExperienceLevel>
            {
                new ClassExperienceLevel { Level = 1, Experience = 0, HitDiceAmount = 1},
                new ClassExperienceLevel { Level = 2, Experience = 2000, HitDiceAmount = 2},
                new ClassExperienceLevel { Level = 3, Experience = 4000, HitDiceAmount = 3},
                new ClassExperienceLevel { Level = 4, Experience = 8000, HitDiceAmount = 4},
                new ClassExperienceLevel { Level = 5, Experience = 16000, HitDiceAmount = 5},
                new ClassExperienceLevel { Level = 6, Experience = 32000, HitDiceAmount = 6},
                new ClassExperienceLevel { Level = 7, Experience = 64000, HitDiceAmount = 7},
                new ClassExperienceLevel { Level = 8, Experience = 125000, HitDiceAmount = 8},
                new ClassExperienceLevel { Level = 9, Experience = 250000, HitDiceAmount = 9},
                new ClassExperienceLevel { Level = 10, Experience = 500000, HitDiceAmount = 10, HitDiceBonus = 3},
                new ClassExperienceLevel { Level = 11, Experience = 750000, HitDiceAmount = 11, HitDiceBonus = 6},
                new ClassExperienceLevel { Level = 12, Experience = 1000000, HitDiceAmount = 12, HitDiceBonus = 9},
                new ClassExperienceLevel { Level = 13, Experience = 1250000, HitDiceAmount = 13, HitDiceBonus = 12},
                new ClassExperienceLevel { Level = 14, Experience = 1500000, HitDiceAmount = 14, HitDiceBonus = 15},
            };
            return returnFighterExpLevels;
        }
    }
}
