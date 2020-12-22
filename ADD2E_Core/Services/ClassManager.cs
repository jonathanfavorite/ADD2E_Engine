using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
using ADD2E_Core.Models;
using System.Linq;
namespace ADD2E_Core.Services
{
    public static class ClassManager
    {
       private static Dictionary<ClassType, List<ClassExperienceLevel>> experienceLevels;

        private static void AddExperienceLevels()
        {
            experienceLevels = new Dictionary<ClassType, List<ClassExperienceLevel>>();
            experienceLevels.Add(ClassType.Fighter, FighterExperienceLevels());
            experienceLevels.Add(ClassType.Wizard, WizardExperienceLevels());
        }
        public static ClassExperienceLevel getExperienceLevels(ClassType t, int Level = 1)
        {
            AddExperienceLevels();
            if(Level >= 20)
            {
                return experienceLevels[t].First(l => l.Level == 20);
            }
            else
            {
                return experienceLevels[t].First(l => l.Level == Level);
            }
            
        }
        public static ClassExperienceLevel GetLevelByExperience(ClassType t, int experience)
        {
            AddExperienceLevels();
            var x = experienceLevels[t].Last(exp => exp.Experience <= experience);
            return x;
        }
        public static SavingThrow SetupSavingThrows(ClassGroup t, int Level = 1)
        {
            return SavingThrowManager.GetSavingThrow(t, Level);
        }
        private static List<ClassExperienceLevel> FighterExperienceLevels()
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
                new ClassExperienceLevel { Level = 10, Experience = 500000, HitDiceAmount = 9, HitDiceBonus = 3},
                new ClassExperienceLevel { Level = 11, Experience = 750000, HitDiceAmount = 9, HitDiceBonus = 6},
                new ClassExperienceLevel { Level = 12, Experience = 1000000, HitDiceAmount = 9, HitDiceBonus = 9},
                new ClassExperienceLevel { Level = 13, Experience = 1250000, HitDiceAmount = 9, HitDiceBonus = 12},
                new ClassExperienceLevel { Level = 14, Experience = 1500000, HitDiceAmount = 9, HitDiceBonus = 15},
                new ClassExperienceLevel { Level = 15, Experience = 1750000, HitDiceAmount = 9, HitDiceBonus = 18},
                new ClassExperienceLevel { Level = 16, Experience = 2000000, HitDiceAmount = 9, HitDiceBonus = 21},
                new ClassExperienceLevel { Level = 17, Experience = 2250000, HitDiceAmount = 9, HitDiceBonus = 24},
                new ClassExperienceLevel { Level = 18, Experience = 2500000, HitDiceAmount = 9, HitDiceBonus = 27},
                new ClassExperienceLevel { Level = 19, Experience = 2750000, HitDiceAmount = 9, HitDiceBonus = 30},
                new ClassExperienceLevel { Level = 20, Experience = 3000000, HitDiceAmount = 9, HitDiceBonus = 33}
            };
            return returnFighterExpLevels;
        }
        private static List<ClassExperienceLevel> WizardExperienceLevels()
        {
            List<ClassExperienceLevel> returnWizardExpLevels = new List<ClassExperienceLevel>
            {
                new ClassExperienceLevel {Level = 1, Experience = 0, HitDiceAmount = 1},
                new ClassExperienceLevel {Level = 2, Experience = 2500, HitDiceAmount = 2},
                new ClassExperienceLevel {Level = 3, Experience = 5000, HitDiceAmount = 3},
                new ClassExperienceLevel {Level = 4, Experience = 10000, HitDiceAmount = 4},
                new ClassExperienceLevel {Level = 5, Experience = 20000, HitDiceAmount = 5},
                new ClassExperienceLevel {Level = 6, Experience = 40000, HitDiceAmount = 6},
                new ClassExperienceLevel {Level = 7, Experience = 60000, HitDiceAmount = 7},
                new ClassExperienceLevel {Level = 8, Experience = 90000, HitDiceAmount = 8},
                new ClassExperienceLevel {Level = 9, Experience = 135000, HitDiceAmount = 9},
                new ClassExperienceLevel {Level = 10, Experience = 25000, HitDiceAmount = 10},
                new ClassExperienceLevel {Level = 11, Experience = 375000, HitDiceAmount = 10, HitDiceBonus = 1},
                new ClassExperienceLevel {Level = 12, Experience = 750000, HitDiceAmount = 10, HitDiceBonus = 2},
                new ClassExperienceLevel {Level = 13, Experience = 1125000, HitDiceAmount = 10, HitDiceBonus = 3},
                new ClassExperienceLevel {Level = 14, Experience = 1500000, HitDiceAmount = 10, HitDiceBonus = 4},
                new ClassExperienceLevel {Level = 15, Experience = 1875000, HitDiceAmount = 10, HitDiceBonus = 5},
                new ClassExperienceLevel {Level = 16, Experience = 2250000, HitDiceAmount = 10, HitDiceBonus = 6},
                new ClassExperienceLevel {Level = 17, Experience = 2625000, HitDiceAmount = 10, HitDiceBonus = 7},
                new ClassExperienceLevel {Level = 18, Experience = 3000000, HitDiceAmount = 10, HitDiceBonus = 8},
                new ClassExperienceLevel {Level = 19, Experience = 3375000, HitDiceAmount = 10, HitDiceBonus = 9},
                new ClassExperienceLevel {Level = 20, Experience = 3750000, HitDiceAmount = 10, HitDiceBonus = 10},
            };
            return returnWizardExpLevels;
        }
    }
}
