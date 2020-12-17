using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
using ADD2E_Core.Models;
namespace ADD2E_Core.Interfaces
{
    public interface ISpells
    {
        string Name { get; set; }
        SpellRangeInfo Range { get; set; }
        List<SpellSchool> School { get; set; }
    }
}
