using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
using ADD2E_Core.Interfaces;
namespace ADD2E_Core.Models
{
    public class SpellRangeInfo
    {
        public int yards { get; set; } = 0;
        public SpellRangeType RangeType { get; set; }

    }
}
