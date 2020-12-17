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
            Console.WriteLine($" HP: {p.HitPoints}");

            if (detailed)
            {
                ShowAbilityScores(p);
                ShowEquipmentForCharacter(p);
                ShowTotalVendoredAmount(p);
                ShowCoinPurse(p);
                ShowPrimaryWeapon(p);
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
        public void ShowCoinPurse(ICharacter p, bool formatted = false)
        {
            Console.WriteLine($"\r\n-- {p.Name}'s Coin Purse --");
            if (formatted)
            {
                MoneyManager mManager = new MoneyManager();
                Money FMoney = mManager.CalculateMoney(p.CoinPurse);
                Console.WriteLine($" {FMoney.Gold}g {FMoney.Silver}s {FMoney.Copper}c");
            }
            else
            {
                Console.WriteLine($" {p.CoinPurse.Gold}g {p.CoinPurse.Silver}s {p.CoinPurse.Copper}c");
            }
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
            MoneyManager mManager = new MoneyManager();
            var switchedMoney = mManager.CalculateMoney(finalMoney);

            Console.WriteLine($"\r\n-- {p.Name}'s Equipment Vendor Value --");
            Console.WriteLine($" {switchedMoney.Gold}s {switchedMoney.Silver}s {switchedMoney.Copper}c");
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
            foreach (IGear gear in p.EquippedGear)
            {
                Console.WriteLine($" {gear.Name} ({gear.SlotType.ToString()})");
            }
        }
        



    }
}
