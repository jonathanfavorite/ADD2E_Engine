using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ADD2E_Core.Models;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
using ADD2E_Core.Services;
namespace ADD2E_Core
{
    public class Program
    {
        private static UITestingManager UIManager;
        static async Task Main(string[] args)
        {
            UIManager = new UITestingManager();

            PlayerCharacter Felix = new PlayerCharacter
            {
                Name = "Anduin",
                Level = 10,
                RaceType = RaceType.Human,
                ClassType = ClassType.Fighter,
                CoinPurse = { Gold = 100, Silver = 200, Copper = 410 },
                AbilityScores =
                {
                    Strength = { Value = 18 },
                    Intelligence = { Value = 10 },
                    Constitution = { Value = 18 },
                    Charisma = { Value = 11 },
                    Dexterity = { Value = 16 },
                    Wisdom = { Value = 10 }
                },
                HitPoints = 100
            };

            Felix.CreateCharacter();

            Equipment Cheese = new Equipment
            {
                Name = "Cheese",
                Description = "Some slightly moldy cheese.",
                Price = { Copper = 5 },
                Consumeable = true,
                EquipmentType = EquipmentType.Food
            };

            Felix.AddItem(Cheese, 15);

            Weapon bastardSword = new Weapon
            {
                 Name = "Bastard Sword (One hand)",
                 AttackType = WeaponAttackType.S,
                 Category = WeaponCategory.BastardSwordOneHanded,
                 TwoHanded = false,
                 Price = { Gold = 1, Silver = 50 },
                 Weareable = true,
                 SlotType = EquipmentSlot.PRIMARY
            };

            Gear LongsleeveShirt = new Gear
            {
                Name = "Long Sleeve Shirt (Red)",
                SlotType = EquipmentSlot.CHEST,
                Price = {Copper = 50 }
            };
            Gear MagicalRing = new Gear
            {
                Name = "Iridescent Gold Banded Ring",
                SlotType = EquipmentSlot.RING,
                Price = { Gold = 15000 }

            };

            Felix.AddItem(bastardSword);
            Felix.AddItem(LongsleeveShirt);
            Felix.AddItem(MagicalRing);

            Felix.EquipItem(LongsleeveShirt);
            Felix.EquipItem(bastardSword);
            Felix.EquipItem(MagicalRing);

            UIManager.ShowCharacterInfo(Felix, true);

            /*
            UIManager.ShowAbilityScores(Felix);
            UIManager.ShowEquipmentForCharacter(Felix);
            UIManager.ShowCoinPurse(Felix);
            UIManager.ShowPrimaryWeapon(Felix);
            UIManager.ShowEquippedGear(Felix);
            */

            Console.ReadLine();
        }

       
      
    }
}
