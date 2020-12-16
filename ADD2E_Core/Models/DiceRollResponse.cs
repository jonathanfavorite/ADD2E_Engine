using System;
using System.Collections.Generic;
using System.Text;

namespace ADD2E_Core.Models
{
    public class DiceRollResponse
    {
        public List<DiceRoll> Rolls { get; set; }
        public int Total { get; set; } = 0;
    }
}
