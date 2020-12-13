using System;
using System.Collections.Generic;
using System.Text;

namespace ADD2E_Core.Classes.List.FighterDetails
{
    public class FighterExperienceLevels
    {
        public int Level { get; set; }
        public int Experience { get; set; }
        public int HitDiceAmount { get; set; }
        public int HitDiceAdjustment { get; set; } = 0;
    }
}
