using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
using ADD2E_Core.Models;
namespace ADD2E_Core.Interfaces
{
    public interface ISpell
    {
        string SpellID { get; set; }
        string Name { get; set; }
        int Level { get; set; }
        List<ClassType> Classes { get; set; }
        List<SpellSchool> School { get; set; }
        SpellRangeInfo Range { get; set; }
        List<SpellCompontents> Compontents { get; set; }
        List<SavingThrowType> SavingThrows { get; set; }
        SpellDurationInfo Duration { get; set; }
        int CastingTime { get; set; }
        AreaOfEffect AOE { get; set; }
        string Description { get; set; }
    }
}
