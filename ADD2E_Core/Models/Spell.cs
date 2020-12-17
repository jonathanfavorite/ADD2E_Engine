using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Models
{
    public class Spell : ISpells
    {
        public string Name { get; set; }
        public List<SpellSchool> School { get; set; }
        public SpellRangeInfo Range { get; set; }
        public List<SpellCompontents> Compontents { get; set; }
        public SpellDurationInfo Duration { get; set; }
        public int CastingTime { get; set; } = 1;

    }
}
