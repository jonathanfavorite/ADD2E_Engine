using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Models;

namespace ADD2E_Core.Services
{
    public class SavingThrowManager
    {
        public Dictionary<ClassGroup, List<SavingThrow>> List;
        private List<SavingThrowType> TypeList;
        public SavingThrowManager()
        {
            List = new Dictionary<ClassGroup, List<SavingThrow>>();
            TypeList = new List<SavingThrowType>
            {
                SavingThrowType.Paralyzation,
                SavingThrowType.Poison,
                SavingThrowType.DeathMagic,
                SavingThrowType.Rod,
                SavingThrowType.Staff,
                SavingThrowType.Wand,
                SavingThrowType.Petrification,
                SavingThrowType.Polymorph,
                SavingThrowType.BreathWeapon,
                SavingThrowType.Spell
            };
            List.Add(ClassGroup.Warrior, WarriorSaves());
        }
        private List<SavingThrow> WarriorSaves()
        {
            return new List<SavingThrow>
            {
                new SavingThrow { Level = 1, Value = 10, ThrowType = TypeList },
                new SavingThrow { Level = 2, Value = 10, ThrowType = TypeList },
                new SavingThrow { Level = 3, Value = 10, ThrowType = TypeList },
                new SavingThrow { Level = 4, Value = 9, ThrowType = TypeList },
                new SavingThrow { Level = 5, Value = 9, ThrowType = TypeList },
                new SavingThrow { Level = 6, Value = 9, ThrowType = TypeList },
                new SavingThrow { Level = 7, Value = 7, ThrowType = TypeList },
                new SavingThrow { Level = 8, Value = 7, ThrowType = TypeList },
                new SavingThrow { Level = 9, Value = 7, ThrowType = TypeList },
                new SavingThrow { Level = 10, Value = 6, ThrowType = TypeList },
                new SavingThrow { Level = 11, Value = 6, ThrowType = TypeList },
                new SavingThrow { Level = 12, Value = 6, ThrowType = TypeList },
                new SavingThrow { Level = 13, Value = 5, ThrowType = TypeList },
                new SavingThrow { Level = 14, Value = 5, ThrowType = TypeList },
                new SavingThrow { Level = 15, Value = 5, ThrowType = TypeList },
                new SavingThrow { Level = 16, Value = 4, ThrowType = TypeList },
                new SavingThrow { Level = 17, Value = 4, ThrowType = TypeList },
                new SavingThrow { Level = 18, Value = 4, ThrowType = TypeList },
                new SavingThrow { Level = 19, Value = 2, ThrowType = TypeList },
            };
        }

    }
   
}
