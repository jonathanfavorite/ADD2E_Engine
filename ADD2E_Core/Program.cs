using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ADD2E_Core.PlayerCharacter;
using ADD2E_Core.Races;
using ADD2E_Core.Classes;
using ADD2E_Core.Rules;
using ADD2E_Core.General;
using ADD2E_Core.General.Dice;
using ADD2E_Core.ItemsAndEquipment;
using System.IO;
namespace ADD2E_Core
{
    public class Program
    {
        static void Main(string[] args)
        {
            RollDice(5, 20); // Roll 5 20 sided die
            CreatePlayer();
            CreateItem();
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
                Level = 5,
                RandomizeStats = true
            };
            Felix.CreateCharacter();
            
            Console.WriteLine("Name: {0}", Felix.Name);
            Console.WriteLine("Race: {0}", Felix.Race.Name);
            Console.WriteLine("Class: {0}", Felix.Class.Name);
            Console.WriteLine("Level: {0}", Felix.Level);
            Console.WriteLine("HP: {0}", Felix.HitPoints);
            Console.WriteLine();
            ShowAbilityScores(Felix);
            Console.WriteLine();
        }
        static void ShowAbilityScores(Player p)
        {
            Console.WriteLine($"-- Ability Scores --");
            Console.WriteLine($"Strength:     {p.AbilityScores.Strength.Value} ({AbilityAdj(p.AbilityScores.Strength.HitProb)})");
            Console.WriteLine($"Dexterity:    {p.AbilityScores.Dexterity.Value} ({AbilityAdj(p.AbilityScores.Dexterity.ReactionAdjustment)})");
            Console.WriteLine($"Constitution: {p.AbilityScores.Constitution.Value} ({AbilityAdj(p.AbilityScores.Constitution.HitPointAdjustment)})");
            Console.WriteLine($"Intelligence: {p.AbilityScores.Strength.Value}");
            Console.WriteLine($"Widsom:       {p.AbilityScores.Wisdom.Value} ({AbilityAdj(p.AbilityScores.Wisdom.MagicalDefenceAdjustment)})");
            Console.WriteLine($"Charisma:     {p.AbilityScores.Charisma.Value} ({AbilityAdj(p.AbilityScores.Charisma.ReactionAdjustment)})");
        }
        static string AbilityAdj(int adjustment)
        {
            string returnVal = adjustment.ToString();
            if(!adjustment.ToString().Contains("-"))
            {
                if(adjustment != 0)
                {
                    returnVal = "+" + adjustment.ToString();
                }
            }
            return returnVal;
        }
        static void RollDice(int amount, int sides)
        {
            DiceRoll Dice = new DiceRoll();
            var Response = Dice.Roll(amount, sides);
        }
        static void CreateItem()
        {
            Player Gotrek = new Player
            {
                Name = "Gotrek",
                RaceType = ERaces.Dwarf,
                ClassType = EClasses.Fighter,
                Level = 5,
            };
            Equipment Cheese = new Equipment
            {
                Type = EEquipmentType.Food,
                Name = "Cheese",
                Description = "Some slightly moldy cheese.",
                Price = { Copper = 5 },
                Consumeable = true
            };
            Gotrek.Equipment.Add(Cheese);
        }

        
    }
}
