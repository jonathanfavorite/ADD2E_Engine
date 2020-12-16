using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Models;
namespace ADD2E_Core.Services
{
    public class MoneyManager
    {
        public Money CalculateMoney(Money m)
        {
            int toCopper = convertMoneyToCopper(m);
            Money newMoney = convertMoneyFromCopper(toCopper);
            return newMoney;
        }
        public Money convertMoneyFromCopper(int copper)
        {
            var remainder = copper;

            var GoldMath = (int)Math.Floor((decimal)copper / 10000);
            remainder -= (GoldMath * 10000);

            var SilverMath = (int)Math.Floor((decimal)remainder / 100);
            remainder -= (SilverMath * 100);

            var CopperMath = remainder;

            Money returnMoney = new Money
            {
                Gold = GoldMath,
                Silver = SilverMath,
                Copper = CopperMath
            };

            return returnMoney;
        }
        public int convertMoneyToCopper(Money m)
        {
            int conversionMath = (m.Gold * 10000) + (m.Silver * 100) + m.Copper;
            return conversionMath;
        }
    }
}
