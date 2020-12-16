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
                Name = "Felix",
                Level = 10,
                RaceType = RaceType.Human,
                ClassType = ClassType.Fighter,
                CoinPurse = { Gold = 100, Silver = 25, Copper = 10 },
                RandomizeStats = true
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

            UIManager.GetTypeAndDisplayString(Felix, Felix.Name);
            UIManager.GetTypeAndDisplayString(Cheese, Cheese.Name);

            UIManager.ShowAbilityScores(Felix);

            Console.ReadLine();
        }

       
      
    }
}
