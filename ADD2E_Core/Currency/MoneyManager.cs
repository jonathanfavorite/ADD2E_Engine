using System;
using System.Collections.Generic;
using System.Text;

namespace ADD2E_Core.Currency
{
    public class MoneyManager
    {
        // Conversion here (I guess it's not needed though. 3000 copper doesn't
        // just immediately become 30 gold.
        // But its probably needed for an actual game.
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
