using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Interfaces
{
    public interface IAbilityScore
    {
        AbilityScoreType Name { get; set; }
        int Value { get; set; }
    }
}
