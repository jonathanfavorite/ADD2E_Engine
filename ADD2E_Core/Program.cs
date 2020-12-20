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
        static void AppStart()
        {
            UIManager = new UITestingManager();
            // IOC Container register here
        }
        static async Task Main(string[] args)
        {

            AppStart();

            #region Testing Player Zone
            /*
            PlayerCharacter Felix = new PlayerCharacter
            {
                Name = "Anduin",
                Level = 10,
                RaceType = RaceType.Human,
                ClassType = ClassType.Fighter,
                CoinPurse = { Gold = 3, Silver = 15, Copper = 55 },
                RandomizeStats = true,
                HitPoints = 100
            };

            IEquipment Cheese = EquipmentFactory.CreateItem(new Equipment
            {
                Name = "Cheese",
                Description = "Some slightly moldy cheese.",
                Price = { Copper = 5 },
                Consumeable = true,
                EquipmentType = EquipmentType.Food
            });
            IWeapon Thunderfury = EquipmentFactory.CreateWeapon(new Weapon
            {
                Name = "Thunderfury, Blessed Blade of the Windseeker",
                AttackType = WeaponAttackType.S,
                Category = WeaponCategory.TwoHandedSword,
                TwoHanded = true,
                Price = { Gold = 500 },
                SlotType = EquipmentSlot.PRIMARY,
                WeaponMods =
                {
                    new WeaponBonus { Modifier = ItemBonusList.DAMAGE, Value = 5}
                }
            });
            IGear LongsleeveShirt = EquipmentFactory.CreateGear(new Gear
            {
                Name = "Long Sleeve Shirt Red",
                SlotType = EquipmentSlot.CHEST,
                Price = {Copper = 50 }
            });
            IGear MagicalRing = EquipmentFactory.CreateGear(new Gear
            {
                Name = "Iridescent Gold Banded Ring",
                SlotType = EquipmentSlot.RING,
                Price = { Gold = 15000 },
                WeaponMods =
                {
                    new WeaponBonus { Modifier = ItemBonusList.INTELLIGENCE, Value = 1}
                }
            });
            IWeapon Shield = EquipmentFactory.CreateWeapon(new Weapon
            {
                Name = "Wooden Shield",
                SlotType = EquipmentSlot.SECONDARY,
                Price = {Gold = 1},
                WeaponMods = {
                    new WeaponBonus { Modifier = ItemBonusList.AC, Value = 2}
                }
            });
            IGear OtherRing = EquipmentFactory.CreateGear(new Gear
            {
                Name = "Soulstained Ring of Empowerment",
                SlotType = EquipmentSlot.RING,
                Price = {Gold = 500},
                WeaponMods =
                {
                    new WeaponBonus { Modifier = ItemBonusList.STRENGTH, Value = 1},
                    new WeaponBonus { Modifier = ItemBonusList.HP, Value = 10}
                }
            });

            Felix.AddItem(Shield);
            Felix.AddItem(Cheese, 25); // 25 pieces of cheese? why not.
            Felix.AddItem(Thunderfury);
            Felix.AddItem(LongsleeveShirt);
            Felix.AddItem(MagicalRing);
            Felix.AddItem(OtherRing);

            //Felix.EquipItem(Shield);
            Felix.EquipItem(LongsleeveShirt);
            Felix.EquipItem(Thunderfury);
            Felix.EquipItem(MagicalRing);
            Felix.EquipItem(OtherRing);
            */
            #endregion
          

            var Felix = CreateMainCharacter("Felix");
            var GoblinGroup = CreateGoblins(0);

            //UIManager.ShowCharacterInfo(Felix, true);

            var iomanager = new IOManager();
           // await iomanager.SaveCharacter(Felix);

            List<ICharacter> allChars = new List<ICharacter>
            {
               Felix
            };

            //UIManager.ShowCharacterInfo(Felix, true);

            for (int i = 0; i <= GoblinGroup.Count - 1; i++)
            {
                allChars.Add(GoblinGroup[i]);
            }

          // UIManager.ShowCharacterInfo(Felix, true);

            if (Felix is IPlayerCharacter c)
            {
               // c.AddExperience(51234235);
            }
          
            UIManager.ShowCharacterInfo(Felix, true);

            // var MeleeAttack = CombatManager.MeleeAttack(Felix, GoblinGroup[0]);
            // Console.WriteLine($"Success:   {MeleeAttack.success}");
            //Console.WriteLine($"Response:  {MeleeAttack.response}");

            Console.ReadLine();
        }

        static ICharacter CreateMainCharacter(string characterName)
        {
            ICharacter Character = CharacterFactory.CreateCharacter(new PlayerCharacter
            {
                Name = characterName,
                Level = 1,
                RaceType = RaceType.Human,
                ClassType = ClassType.Fighter,
                MainCharacter = true,
                RandomizeStats = true,
                OwnerName = "Jonathan Favorite",
                AbilityScores =
                {
                    
                    Constitution = { Value = 8 },
                    Strength = { Value = 8 },
                    Dexterity = { Value = 8 },
                    Charisma = { Value = 8 },
                    Intelligence = { Value = 8 },
                    Wisdom = { Value = 8 }
                }
            });

            IWeapon bastardSword = EquipmentFactory.CreateWeapon(new Weapon
            {
                Name = "Bastard Sword (One hand)",
                AttackType = WeaponAttackType.S,
                Category = WeaponCategory.BastardSwordOneHanded,
                TwoHanded = false,
                Price = { Gold = 1, Silver = 50 },
                Damage = { Amount = 1, SidedDie = 8, Bonus = 1 },
                Weareable = true,
                SlotType = EquipmentSlot.PRIMARY
            });

            IGear chainMailChest = EquipmentFactory.CreateGear(new Gear
            {
                Name = "ChainMail Chest Piece",
                AC = 7,
                EquipmentType = EquipmentType.Clothing,
                Price = { Silver = 50 },
                SlotType = EquipmentSlot.CHEST,
                ArmorType = ArmorTypeList.ChainMail
            });

            IGear WoodenShield = EquipmentFactory.CreateGear(new Gear
            {
                Name = "Wooden Shield",
                ArmorType = ArmorTypeList.Shield,
                SlotType = EquipmentSlot.SECONDARY,
                StatMods = { new StatModifier { Modifier = ItemBonusList.AC, Value = 1} },
                Price = { Silver = 23 }
            });

            IGear MagicRing = EquipmentFactory.CreateGear(new Gear
            {
                Name = "Glowing Magical Ring",
                SlotType = EquipmentSlot.RING,
                StatMods = { new StatModifier { Modifier = ItemBonusList.BreathWeapon, Value = 1} },
                Price = { Gold = 100 }
            });

            Character.AddItem(MagicRing, 1);
            Character.AddItem(bastardSword, 1);
            Character.AddItem(chainMailChest, 1);
            Character.AddItem(WoodenShield, 1);

            Character.EquipItem(MagicRing);
            Character.EquipItem(bastardSword);
            Character.EquipItem(chainMailChest);
            Character.EquipItem(WoodenShield);

            return Character;
        }

        static List<ICharacter> CreateGoblins(int Amount = 1)
        {
            List<ICharacter> returnChars = new List<ICharacter>();
            Random rMoney = new Random();
            for(int i = 0; i < Amount; i++)
            {
                ICharacter goblin = CharacterFactory.CreateCharacter(new PlayerCharacter
                {
                    Name = "Goblin_" + (i + 1),
                    Level = rMoney.Next(1,3),
                    ClassType = ClassType.Fighter,
                    RaceType = RaceType.Human,
                    RandomizeStats = true,
                    CoinPurse = { Gold = rMoney.Next(0,2), Copper = rMoney.Next(0, 100), Silver = rMoney.Next(0, 100), }
                });
                //goblin.CreateCharacter();

                IWeapon sword = EquipmentFactory.CreateWeapon(new Weapon
                {
                    Name = "Rusty Sword",
                    AttackType = WeaponAttackType.S,
                    Category = WeaponCategory.ShortSword,
                    Price = { Silver = 12 },
                    Damage = { SidedDie = 6},
                    SlotType = EquipmentSlot.PRIMARY,
                    Size = WeaponSize.S
                });

                IGear LeatherChest = EquipmentFactory.CreateGear(new Gear
                {
                    Name = "Leather Chest Piece",
                     AC = 9,
                     EquipmentType = EquipmentType.Clothing,
                     Price = { Silver = 50 },
                     SlotType = EquipmentSlot.CHEST
                });

                goblin.AddItem(LeatherChest, 1);
                goblin.AddItem(sword, 1);
                goblin.EquipItem(sword);
                goblin.EquipItem(LeatherChest);
                returnChars.Add(goblin);
            }
            return returnChars;
        }
      
    }
}
