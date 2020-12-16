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
                CoinPurse = { Gold = 100, Silver = 2005, Copper = 410 },
                AbilityScores =
                {
                    Strength = { Value = 18 },
                    Intelligence = { Value = 18 },
                    Constitution = { Value = 18 },
                    Charisma = { Value = 18 },
                    Dexterity = { Value = 18 },
                    Wisdom = { Value = 18 }
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
                Type = EquipmentType.Food
            };

            Felix.AddItem(Cheese,50);

            UIManager.ShowAbilityScores(Felix);
            UIManager.ShowEquipmentForCharacter(Felix);
            UIManager.ShowCoinPurse(Felix);


            Console.ReadLine();
        }

       
      
    }
}
