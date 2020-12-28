﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Models;
using ADD2E_Core.Enums;

namespace ADD2E_Core.Services
{
    public class EquipmentManager
    {
        private List<IEquipment> equipment;
        public EquipmentManager() { }
        public EquipmentManager(List<IEquipment> e)
        {
            equipment = e;
        }

        public List<string> DisplayAllEquipmentByQuantity()
        {
            List<string> returnString = new List<string>();
            List<IEquipment> distinctItems = equipment.GroupBy(i => i.Name).Select(group => group.First()).ToList();
            foreach (IEquipment item in distinctItems)
            {
                int quantity = CountEquipmentQuantity(item);
                Money addQuantityAmount = FormatMoney(item.Price, quantity);
                Money formattedQuanaityPrice = MoneyManager.CalculateMoney(addQuantityAmount);
                string formattedPrice = MoneyManager.PrettyMoney(formattedQuanaityPrice);
                string formattedItem = string.Format("({0}) {1} ({2})", quantity, item.Name, formattedPrice);
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

            return new Money
            {
                Gold = goldMath,
                Silver = silverMath,
                Copper = copperMath
            };
        }
        public int CountHowManyEquippedBySlotType(EquipmentSlot slot, List<IEquipment> allItems)
        {
            int count = 0;
            foreach (IEquipment item in allItems)
            {
                if (item is IWeapon w)
                {
                    if (w.SlotType == slot)
                    {
                        ++count;
                    }
                }
                if (item is IGear g)
                {
                    if (g.SlotType == slot)
                    {
                        ++count;
                    }
                }
            }
            return count;
        }

    }
}
