using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Models;
using System.Linq;
namespace ADD2E_Core.Services
{
    public class DiceManager
    {
        public DiceRollResponse Roll(int amount, int sides)
        {
            List<DiceRoll> rollList = new List<DiceRoll>();
            int Total = 0;
            for (int i = 0; i <= amount - 1; i++)
            {
                Random r = new Random();
                int thisRoll = r.Next(1, sides);
                var tmpRoll = new DiceRoll
                {
                    RollToText = string.Format($"{amount}d{sides}"),
                    Amount = thisRoll
                };
                rollList.Add(tmpRoll);
                Total += thisRoll;
            }
            return new DiceRollResponse { Rolls = rollList, Total = Total };
        }
        public int RollOnce(int sidedDie)
        {
            Random r = new Random();
            return r.Next(1, sidedDie);
        }
        public int FourDSixDropTheLowest()
        {
            List<int> rolls = new List<int>();
            Random r = new Random();
            for (int i = 0; i <= 3; i++)
            {
                rolls.Add(r.Next(1, 7));
            }
            return rolls.OrderByDescending(x => x).Take(rolls.Count() - 1).Sum();
        }
    }
}
