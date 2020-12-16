using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ADD2E_Core.Models;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Services
{
    public class ThacoManager
    {
        private Dictionary<ClassGroup, List<ThacoScore>> thacoScores;
        public ThacoManager()
        {
            thacoScores = new Dictionary<ClassGroup, List<ThacoScore>>();
            thacoScores.Add(ClassGroup.Priest, PriestThaco());
            thacoScores.Add(ClassGroup.Warrior, FighterThaco());
            thacoScores.Add(ClassGroup.Rogue, RogueThaco());
            thacoScores.Add(ClassGroup.Wizard, WizardThaco());
        }
        public ThacoScore getThaco(ClassGroup t, int Level = 1)
        {
            return thacoScores[t].First(l => l.Level == Level);
        }
        private List<ThacoScore> PriestThaco()
        {
            List<ThacoScore> returnList = new List<ThacoScore>()
            {
                 new ThacoScore { ClassGroup = ClassGroup.Priest, Level = 1, Value = 20 },
                 new ThacoScore { ClassGroup = ClassGroup.Priest, Level = 2, Value = 20 },
                 new ThacoScore { ClassGroup = ClassGroup.Priest, Level = 3, Value = 20 },
                 new ThacoScore { ClassGroup = ClassGroup.Priest, Level = 4, Value = 18 },
                 new ThacoScore { ClassGroup = ClassGroup.Priest, Level = 5, Value = 18 },
                 new ThacoScore { ClassGroup = ClassGroup.Priest, Level = 6, Value = 18 },
                 new ThacoScore { ClassGroup = ClassGroup.Priest, Level = 7, Value = 16 },
                 new ThacoScore { ClassGroup = ClassGroup.Priest, Level = 8, Value = 16 },
                 new ThacoScore { ClassGroup = ClassGroup.Priest, Level = 9, Value = 16 },
                 new ThacoScore { ClassGroup = ClassGroup.Priest, Level = 10, Value = 14 },
                 new ThacoScore { ClassGroup = ClassGroup.Priest, Level = 11, Value = 14 },
                 new ThacoScore { ClassGroup = ClassGroup.Priest, Level = 12, Value = 14 },
                 new ThacoScore { ClassGroup = ClassGroup.Priest, Level = 13, Value = 12 },
                 new ThacoScore { ClassGroup = ClassGroup.Priest, Level = 14, Value = 12 },
                 new ThacoScore { ClassGroup = ClassGroup.Priest, Level = 15, Value = 12 },
                 new ThacoScore { ClassGroup = ClassGroup.Priest, Level = 16, Value = 10 },
                 new ThacoScore { ClassGroup = ClassGroup.Priest, Level = 17, Value = 10 },
                 new ThacoScore { ClassGroup = ClassGroup.Priest, Level = 18, Value = 10 },
                 new ThacoScore { ClassGroup = ClassGroup.Priest, Level = 19, Value = 8 },
                 new ThacoScore { ClassGroup = ClassGroup.Priest, Level = 20, Value = 8 }
            };
            return returnList;
        }
        private List<ThacoScore> RogueThaco()
        {
            List<ThacoScore> returnList = new List<ThacoScore>()
            {
                new ThacoScore { ClassGroup = ClassGroup.Rogue, Level = 1, Value = 20 },
                new ThacoScore { ClassGroup = ClassGroup.Rogue, Level = 2, Value = 20 },
                new ThacoScore { ClassGroup = ClassGroup.Rogue, Level = 3, Value = 19 },
                new ThacoScore { ClassGroup = ClassGroup.Rogue, Level = 4, Value = 19 },
                new ThacoScore { ClassGroup = ClassGroup.Rogue, Level = 5, Value = 18 },
                new ThacoScore { ClassGroup = ClassGroup.Rogue, Level = 6, Value = 18 },
                new ThacoScore { ClassGroup = ClassGroup.Rogue, Level = 7, Value = 17 },
                new ThacoScore { ClassGroup = ClassGroup.Rogue, Level = 8, Value = 17 },
                new ThacoScore { ClassGroup = ClassGroup.Rogue, Level = 9, Value = 16 },
                new ThacoScore { ClassGroup = ClassGroup.Rogue, Level = 10, Value = 16 },
                new ThacoScore { ClassGroup = ClassGroup.Rogue, Level = 11, Value = 15 },
                new ThacoScore { ClassGroup = ClassGroup.Rogue, Level = 12, Value = 15 },
                new ThacoScore { ClassGroup = ClassGroup.Rogue, Level = 13, Value = 14 },
                new ThacoScore { ClassGroup = ClassGroup.Rogue, Level = 14, Value = 14 },
                new ThacoScore { ClassGroup = ClassGroup.Rogue, Level = 15, Value = 13 },
                new ThacoScore { ClassGroup = ClassGroup.Rogue, Level = 16, Value = 13 },
                new ThacoScore { ClassGroup = ClassGroup.Rogue, Level = 17, Value = 12 },
                new ThacoScore { ClassGroup = ClassGroup.Rogue, Level = 18, Value = 12 },
                new ThacoScore { ClassGroup = ClassGroup.Rogue, Level = 19, Value = 11 },
                new ThacoScore { ClassGroup = ClassGroup.Rogue, Level = 20, Value = 11 },
            };
            return returnList;
        }
        private List<ThacoScore> FighterThaco()
        {
            List<ThacoScore> returnList = new List<ThacoScore>()
            {
                new ThacoScore { ClassGroup = ClassGroup.Warrior, Level = 1, Value = 20 },
                new ThacoScore { ClassGroup = ClassGroup.Warrior, Level = 2, Value = 19 },
                new ThacoScore { ClassGroup = ClassGroup.Warrior, Level = 3, Value = 18 },
                new ThacoScore { ClassGroup = ClassGroup.Warrior, Level = 4, Value = 17 },
                new ThacoScore { ClassGroup = ClassGroup.Warrior, Level = 5, Value = 16 },
                new ThacoScore { ClassGroup = ClassGroup.Warrior, Level = 6, Value = 15 },
                new ThacoScore { ClassGroup = ClassGroup.Warrior, Level = 7, Value = 14 },
                new ThacoScore { ClassGroup = ClassGroup.Warrior, Level = 8, Value = 13 },
                new ThacoScore { ClassGroup = ClassGroup.Warrior, Level = 9, Value = 12 },
                new ThacoScore { ClassGroup = ClassGroup.Warrior, Level = 10, Value = 11 },
                new ThacoScore { ClassGroup = ClassGroup.Warrior, Level = 11, Value = 10 },
                new ThacoScore { ClassGroup = ClassGroup.Warrior, Level = 12, Value = 9},
                new ThacoScore { ClassGroup = ClassGroup.Warrior, Level = 13, Value = 8 },
                new ThacoScore { ClassGroup = ClassGroup.Warrior, Level = 14, Value = 7 },
                new ThacoScore { ClassGroup = ClassGroup.Warrior, Level = 15, Value = 6 },
                new ThacoScore { ClassGroup = ClassGroup.Warrior, Level = 16, Value = 5 },
                new ThacoScore { ClassGroup = ClassGroup.Warrior, Level = 17, Value = 4 },
                new ThacoScore { ClassGroup = ClassGroup.Warrior, Level = 18, Value = 3 },
                new ThacoScore { ClassGroup = ClassGroup.Warrior, Level = 19, Value = 2 },
                new ThacoScore { ClassGroup = ClassGroup.Warrior, Level = 20, Value = 1 }
            };
            return returnList;
        }
        private List<ThacoScore> WizardThaco()
        {
            List<ThacoScore> returnList = new List<ThacoScore>()
            {
                new ThacoScore { ClassGroup = ClassGroup.Wizard, Level = 1, Value = 20 },
                new ThacoScore { ClassGroup = ClassGroup.Wizard, Level = 2, Value = 20 },
                new ThacoScore { ClassGroup = ClassGroup.Wizard, Level = 3, Value = 20 },
                new ThacoScore { ClassGroup = ClassGroup.Wizard, Level = 4, Value = 19 },
                new ThacoScore { ClassGroup = ClassGroup.Wizard, Level = 5, Value = 19 },
                new ThacoScore { ClassGroup = ClassGroup.Wizard, Level = 6, Value = 19 },
                new ThacoScore { ClassGroup = ClassGroup.Wizard, Level = 7, Value = 18 },
                new ThacoScore { ClassGroup = ClassGroup.Wizard, Level = 8, Value = 18 },
                new ThacoScore { ClassGroup = ClassGroup.Wizard, Level = 9, Value = 18 },
                new ThacoScore { ClassGroup = ClassGroup.Wizard, Level = 10, Value = 17 },
                new ThacoScore { ClassGroup = ClassGroup.Wizard, Level = 11, Value = 17 },
                new ThacoScore { ClassGroup = ClassGroup.Wizard, Level = 12, Value = 17 },
                new ThacoScore { ClassGroup = ClassGroup.Wizard, Level = 13, Value = 16 },
                new ThacoScore { ClassGroup = ClassGroup.Wizard, Level = 14, Value = 16 },
                new ThacoScore { ClassGroup = ClassGroup.Wizard, Level = 15, Value = 16 },
                new ThacoScore { ClassGroup = ClassGroup.Wizard, Level = 16, Value = 15 },
                new ThacoScore { ClassGroup = ClassGroup.Wizard, Level = 17, Value = 15 },
                new ThacoScore { ClassGroup = ClassGroup.Wizard, Level = 18, Value = 15 },
                new ThacoScore { ClassGroup = ClassGroup.Wizard, Level = 19, Value = 14 },
                new ThacoScore { ClassGroup = ClassGroup.Wizard, Level = 20, Value = 14 }
            };
            return returnList;
        }
    }
}
