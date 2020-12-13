using System;
using System.Collections.Generic;
using System.Text;

namespace ADD2E_Core.General.Dice
{
    public class RollResponse
    {
        public List<IndividualRoll> Rolls { get; set; }
        public int Total { get; set; } = 0;
    }
    public class IndividualRoll
    {
        public string Roll { get; set; }
        public int Amount { get; set; }
    }
}
