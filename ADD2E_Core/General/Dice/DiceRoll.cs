using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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
        public int RollOnce(int sidedDie)
        {
            Random r = new Random();
            return r.Next(1, sidedDie);
        }
        public int FourDSixDropTheLowest()
        {
            List<int> rolls = new List<int>();
            for(int i = 0; i <= 3; i++)
            {
                Random r = new Random();
                rolls.Add(r.Next(1, 6));
                //rolls.Add(6); //for testing
            }
            return rolls.OrderByDescending(x => x).Take(rolls.Count() - 1).Sum();
        }
    }
}
