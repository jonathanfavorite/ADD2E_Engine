using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Models;
namespace ADD2E_Core.Services
{
    public static class MoneyManager
    {
        public static Money CalculateMoney(Money m)
        {
            int toCopper = convertMoneyToCopper(m);
            Money newMoney = convertMoneyFromCopper(toCopper);
            return newMoney;
        }
        public static string PrettyMoney(Money m)
        {
            return string.Format("{0:N0}g {1:N0}s {2:N0}c", m.Gold, m.Silver, m.Copper);
        }
        public static Money convertMoneyFromCopper(int copper)
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
        public static int convertMoneyToCopper(Money m)
        {
            int conversionMath = (m.Gold * 10000) + (m.Silver * 100) + m.Copper;
            return conversionMath;
        }
        public static Money addMoney(Money coinPurse, Money newMoney)
        {
            coinPurse.Copper += newMoney.Copper;
            coinPurse.Silver += newMoney.Silver;
            coinPurse.Gold += newMoney.Gold;
            return coinPurse;
        }
        public static Money removeMoney(Money coinPurse, Money newMoney)
        {
            coinPurse.Copper -= newMoney.Copper;
                if (coinPurse.Copper <= 0) { coinPurse.Copper = 0; }
            coinPurse.Silver -= newMoney.Silver;
                if (coinPurse.Silver <= 0) { coinPurse.Silver = 0; }
            coinPurse.Gold -= newMoney.Gold;
                if (coinPurse.Gold <= 0) { coinPurse.Gold = 0; }
            return coinPurse;
        }
    }
}
