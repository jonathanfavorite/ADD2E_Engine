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
        }
        public ThacoScore getThaco(ClassGroup t, int Level = 1)
        {
            return thacoScores[t].First(l => l.Level == Level);
        }
        private List<ThacoScore> PriestThaco()
        {
            List<ThacoScore> returnList = new List<ThacoScore>()
            {

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
    }
}
