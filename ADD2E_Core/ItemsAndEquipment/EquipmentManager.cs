using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ADD2E_Core.Currency;
namespace ADD2E_Core.ItemsAndEquipment
{
    public class EquipmentManager
    {
        private MoneyManager moneyManager = new MoneyManager();
        public EquipmentManager() { }
        public EquipmentManager(List<IEquipment> e)
        {
            this.equipment = e;
        }
        private List<IEquipment> equipment;

        public List<string> DisplayAllEquipment()
        {
            return null;
        }
        public List<string> DisplayAllEquipmentByQuantity()
        {
            List<string> returnString = new List<string>();
            // Get distinct equipment pieces
            List<IEquipment> distinctItems = equipment.GroupBy(i => i.Name).Select(group => group.First()).ToList();
            foreach(IEquipment item in distinctItems)
            {
                int quantity = CountEquipmentQuantity(item);
                Money addQuantityAmount = FormatMoney(item.Price, quantity);
                Money formattedQuanaityPrice = moneyManager.CalculateMoney(addQuantityAmount);
                    string formattedPrice = string.Format("{0}g {1}s {2}c", formattedQuanaityPrice.Gold, formattedQuanaityPrice.Silver, formattedQuanaityPrice.Copper);
                string formattedItem = string.Format("({0}) {1}      {2}", quantity, item.Name, formattedPrice);
                returnString.Add(formattedItem);
            }
            return returnString;
        }
        public int CountEquipmentQuantity(IEquipment thisItem)
        {
            var amountFound = equipment.Where(x => x.Name == thisItem.Name).ToList();
            return amountFound.Count();
        }
        public Money FormatMoney(Money m, int quantity = 1)
        {
            int goldMath = m.Gold * quantity;
            int silverMath = m.Silver * quantity;
            int copperMath = m.Copper * quantity;

            Money newMoney = new Money
            {
                Gold = goldMath,
                Silver = silverMath,
                Copper = copperMath
            };
           // string retMoney = string.Format("{0}g {1}s {2}c", goldMath, silverMath, copperMath);
            return newMoney;
        }

    }
}
