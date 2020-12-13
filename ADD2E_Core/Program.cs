using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ADD2E_Core.PlayerCharacter;
using ADD2E_Core.Races;
using ADD2E_Core.Classes;
using ADD2E_Core.Rules;
using ADD2E_Core.General;
using ADD2E_Core.General.Dice;
namespace ADD2E_Core
{
    public class Program
    {
        static void Main(string[] args)
        {
            RollDice(5, 20); // Roll 5 20 sided die
            CreatePlayer();
            Console.ReadLine();
        }
        static void CreatePlayer()
        {
            Player Felix = new Player
            {
                Name = "Felix",
                RaceType = ERaces.Human,
                OwnerName = "Jonathan",
                ClassType = EClasses.Fighter,
                Level = 1,
            };

            Felix.CreateCharacter();

            Console.WriteLine("Created Player:");
            Console.WriteLine("\tName: {0}", Felix.Name);
            Console.WriteLine("\tRace: {0}", Felix.Race.Name);
            Console.WriteLine("\tClass: {0}", Felix.Class.Name);
            Console.WriteLine("\tLevel: {0}", Felix.Level);
        }
        static void RollDice(int amount, int sides)
        {
            DiceRoll Dice = new DiceRoll();
            var Response = Dice.Roll(amount, sides);
            var y = 0;
        }
        
    }
}
