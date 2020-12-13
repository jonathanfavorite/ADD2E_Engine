using System;
using System.Collections.Generic;
using System.Text;

namespace ADD2E_Core.General.Dice
{
    public class DiceRoll
    {
        public RollResponse Roll(int amount, int sides)
        {
            List<IndividualRoll> rollList = new List<IndividualRoll>();
            int Total = 0;
            for(int i = 0; i <= amount - 1; i++)
            {
                Random r = new Random();
                int thisRoll = r.Next(1, sides);
                var tmpRoll = new IndividualRoll
                {
                    Roll = string.Format($"{amount}d{sides}"),
                    Amount = thisRoll
                };
                rollList.Add(tmpRoll);
                Total += thisRoll;
            }
            return new RollResponse { Rolls = rollList, Total = Total };
        }
    }
}
