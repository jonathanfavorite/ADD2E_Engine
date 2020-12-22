using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Models
{
    public class Spell : ISpell
    {
        public string SpellID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; } = 1;
        public List<ClassType> Classes { get; set; } = new List<ClassType>();
        public List<SpellSchool> School { get; set; } = new List<SpellSchool>();
        public SpellRangeInfo Range { get; set; } = new SpellRangeInfo();
        public List<SpellCompontents> Compontents { get; set; } = new List<SpellCompontents>();
        public List<SavingThrowType> SavingThrows { get; set; } = new List<SavingThrowType>();
        public SpellDurationInfo Duration { get; set; } = new SpellDurationInfo();
        public int CastingTime { get; set; } = 1; // Rounds (Need to conver to seconds later)
        public AreaOfEffect AOE { get; set; } = new AreaOfEffect();
        public string Description { get; set; } = string.Empty;

    }
}
