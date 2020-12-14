using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ADD2E_Core.Characters;
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
            Console.ReadLine();
        }
        static void CreatePlayer()
        {
            Character Felix = new Character
            {
                Name = "Felix",
                RaceType = ERaces.Human,
                ClassType = EClasses.Fighter,
                Level = 5,
                RandomizeStats = true,
                PrimaryWeapon = AddPrimaryWeapon()
            };
            Felix.CreateCharacter();
           

            Console.WriteLine("-- Player Information --");
            Console.WriteLine("Name:  {0}", Felix.Name);
            Console.WriteLine("Race:  {0}", Felix.Race.Name);
            Console.WriteLine("Class: {0}", Felix.Class.Name);
            Console.WriteLine("Level: {0}", Felix.Level);
            Console.WriteLine("HP:    {0}", Felix.HitPoints);
            Console.WriteLine("AC:    {0}", Felix.ArmorClass);
            Console.WriteLine("Thaco: {0}", Felix.Thaco.Value);
            Console.WriteLine();
            ShowAbilityScores(Felix);
            Console.WriteLine();


            Felix.AddItem(CreateItem(), 20);
            Felix.AddItem(CreateRope(), 2);

            ShowEquipmentForCharacter(Felix);

            Console.WriteLine();

            Felix.RemoveItem(Felix.Equipment[0], 5);
            ShowEquipmentForCharacter(Felix);

            Console.WriteLine();

        }
        static void ShowAbilityScores(Character p)
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
        static void ShowEquipmentForCharacter(Character p)
        {
            Console.WriteLine($"-- {p.Name}'s Equipment --");
            // Group up items by name
            EquipmentManager eManager = new EquipmentManager(p.Equipment);
            eManager.DisplayAllEquipmentByQuantity();
            foreach(string item in eManager.DisplayAllEquipmentByQuantity())
            {
                Console.WriteLine($"{item}");
            }
        }
        static IEquipment CreateItem()
        {
            Equipment Item = new Equipment
            {
                Type = EEquipmentType.Food,
                Name = "Cheese",
                Description = "Some slightly moldy cheese.",
                Price = { Copper = 1 },
                Consumeable = true
            };
            Item.CreateItem();
            return Item;
        }
        static IEquipment CreateRope()
        {
            Equipment Rope = new Equipment
            {
                Type = EEquipmentType.Misc,
                Name = "Rope (50ft)",
                Price = {Silver = 50}
            };
            Rope.CreateItem();
            return Rope;
        }
        static IWeapon AddPrimaryWeapon()
        {
            Weapon Sword = new Weapon
            {
                Name = "Bastard Sword",
                 AttackType = EWeaponAttackType.S,
                 Category = EWeaponCategory.BastardSwordTwoHanded,
                 TwoHanded = true,
                 Price = { Gold = 1},
                 Weight = 10
            };
            return Sword;
        }

    }
}
