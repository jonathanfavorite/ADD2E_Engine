using System;
using System.Collections.Generic;
using System.Text;

namespace ADD2E_Core.Models
{
    public class ClassExperienceLevel
    {
        public int Level { get; set; }
        public int Experience { get; set; }
        public int HitDiceAmount { get; set; }
        public int HitDiceBonus { get; set; } = 0;
    }
}
