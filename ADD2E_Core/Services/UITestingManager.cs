using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Models;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;

namespace ADD2E_Core.Services
{
    public class UITestingManager
    {
        public void GetTypeAndDisplayString(object o, string displayName = "")
        {
            Console.WriteLine($"\r\n({o.GetType()}) {displayName}");
        }

        public void ShowCharacterInfo(ICharacter p, bool detailed = false)
        {
            Console.WriteLine($" \r\n #############################################");
            Console.WriteLine($" ########### Player Information ##############");
            Console.WriteLine($" #############################################");

            Console.WriteLine($"\r\n Player Name: {p.Name}");
            Console.WriteLine($" Class: {p.Class.Name}");
            Console.WriteLine($" Race: {p.Race.Name}");
            Console.WriteLine($" Level: {p.Level}");
            Console.WriteLine($" Experience: {p.LevelInfo.Experience} / {p.NextLevelInfo.Experience}");
            Console.WriteLine($" HP: {p.HitPoints} / {p.TmpHitPoints}");
            Console.WriteLine($" Thaco: {p.Thaco.Value}");
            Console.WriteLine($" AC: {p.ArmorClass}");

            if (detailed)
            {
                ShowAbilityScores(p);
                ShowEquipmentForCharacter(p);
                ShowTotalVendoredAmount(p);
                ShowCoinPurse(p);
                //ShowPrimaryWeapon(p);
                ShowEquippedGear(p);
            }
        }
        public void ShowAbilityScores(ICharacter p)
        {
            Console.WriteLine($"\r\n-- Ability Scores --");
            Console.WriteLine($" Strength:     {p.AbilityScores.Strength.Value} ({AbilityAdj(p.AbilityScores.Strength.HitProb)})");
            Console.WriteLine($" Dexterity:    {p.AbilityScores.Dexterity.Value} ({AbilityAdj(p.AbilityScores.Dexterity.ReactionAdjustment)})");
            Console.WriteLine($" Constitution: {p.AbilityScores.Constitution.Value} ({AbilityAdj(p.AbilityScores.Constitution.HitPointAdjustment)})");
            Console.WriteLine($" Intelligence: {p.AbilityScores.Strength.Value}");
            Console.WriteLine($" Widsom:       {p.AbilityScores.Wisdom.Value} ({AbilityAdj(p.AbilityScores.Wisdom.MagicalDefenceAdjustment)})");
            Console.WriteLine($" Charisma:     {p.AbilityScores.Charisma.Value} ({AbilityAdj(p.AbilityScores.Charisma.ReactionAdjustment)})");
        }
        private string AbilityAdj(int adjustment)
        {
            string returnVal = adjustment.ToString();
            if (!adjustment.ToString().Contains("-"))
            {
                if (adjustment != 0)
                {
                    returnVal = "+" + adjustment.ToString();
                }
            }
            return returnVal;
        }
        public void ShowEquipmentForCharacter(ICharacter p)
        {
            Console.WriteLine($"\r\n-- {p.Name}'s Equipment --");
            // Group up items by name
            EquipmentManager eManager = new EquipmentManager(p.Equipment);
            eManager.DisplayAllEquipmentByQuantity();
            foreach (string item in eManager.DisplayAllEquipmentByQuantity())
            {
                Console.WriteLine($" {item}");
            }
        }
        public void ShowCoinPurse(ICharacter p)
        {
            Console.WriteLine($"\r\n-- {p.Name}'s Coin Purse --");
            Console.WriteLine(" {0}", MoneyManager.PrettyMoney(p.CoinPurse));
        }
        public void ShowTotalVendoredAmount(ICharacter p)
        {
            Money finalMoney = new Money();
            foreach(IEquipment m in p.Equipment)
            {
                finalMoney.Gold += m.Price.Gold;
                finalMoney.Silver += m.Price.Silver;
                finalMoney.Copper += m.Price.Copper;
            }
            var switchedMoney = MoneyManager.CalculateMoney(finalMoney);

            Console.WriteLine($"\r\n-- {p.Name}'s Equipment Vendor Value --");
            Console.WriteLine(" {0}", MoneyManager.PrettyMoney(switchedMoney));
        }

        public void ShowPrimaryWeapon(ICharacter p)
        {
            Console.WriteLine($"\r\n-- {p.Name}'s Primary Weapon --");
            if (p.PrimaryWeapon == null)
            {
                Console.WriteLine(" No primary weapon equipped.");
            }
            else
            {
                Console.WriteLine($" {p.PrimaryWeapon.Name}");
            }
        }
        public void ShowEquippedGear(ICharacter p)
        {
            Console.WriteLine($"\r\n-- {p.Name}'s Equipped Gear --");
            foreach (IEquipment item in p.EquippedGear)
            {
                if (item is IWeapon w)
                {
                    Console.WriteLine($" -{w.Name} ({w.SlotType})");
                    ShowGearBonus(item.StatMods);
                }
                else if (item is IGear g)
                {
                    Console.WriteLine($" -{g.Name} ({g.SlotType})");
                    ShowGearBonus(item.StatMods);
                }
            }
        }
        private void ShowGearBonus(List<StatModifier> bonus)
        {
            foreach(StatModifier b in bonus)
            {
                Console.WriteLine("\t-{0} ({1})", b.Modifier, AbilityAdj(b.Value));
            }
        }
        



    }
}
