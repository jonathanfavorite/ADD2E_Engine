using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ADD2E_Core.Models;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
namespace ADD2E_Core
{
    public class Program
    {
        static async Task Main(string[] args)
        {

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

            GetTypeAndString(Felix, Felix.Name);

            Console.ReadLine();
        }

        static void GetTypeAndString(object o, string displayName = "")
        {
            Console.WriteLine($"({o.GetType()}) {displayName}");
        }
      
    }
}
