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
        }
        static async Task Main(string[] args)
        {
            AppStart();

            var Felix = CreateMainCharacter("Felix");
            var GoblinGroup = CreateGoblins(0);

            var iomanager = new IOManager();
            List<ICharacter> allChars = new List<ICharacter>
            {
               Felix
            };

            for (int i = 0; i <= GoblinGroup.Count - 1; i++)
            {
                //allChars.Add(GoblinGroup[i]);
            }

         //  UIManager.ShowCharacterInfo(Felix, true);

            
            for(int i = 0; i <= 5000; i++)
            {
                if (Felix is IPlayerCharacter c)
                {
                    c.AddExperience(DiceManager.Roll(1, 2000, 1000).Total);
                }
                UIManager.ShowCharacterInfo(Felix, false);
                UIManager.ShowSavingThrows(Felix);
                System.Threading.Thread.Sleep(100);
                if(Felix.Level == 30)
                {
                    break;
                }
                Console.Clear();
            }
            
            

           
          
           


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
                OwnerName = "Jonathan Favorite"
            });

            IWeapon Sword = EquipmentFactory.CreateWeapon(new Weapon
            {
                Name = "Testing Sword (One hand)",
                AttackType = WeaponAttackType.S,
                Category = WeaponCategory.BastardSwordOneHanded,
                TwoHanded = false,
                Price = { Gold = 1, Silver = 50 },
                Damage = { Amount = 1, SidedDie = 8, Bonus = 1 },
                Weareable = true,
                SlotType = EquipmentSlot.PRIMARY
            });

            IGear Shield = EquipmentFactory.CreateGear(new Gear
            {
                Name = "Testing Shield",
                ArmorType = ArmorTypeList.Shield,
                SlotType = EquipmentSlot.SECONDARY,
                AC = 0,
                StatMods = { new StatModifier { Modifier = ItemBonusList.AC, Value = 2 } }
            });

            IGear Head = EquipmentFactory.CreateGear(new Gear
            {
                Name = "Testing Head",
                AC = 6,
                EquipmentType = EquipmentType.Clothing,
                Price = { Silver = 50 },
                SlotType = EquipmentSlot.HEAD,
                ArmorType = ArmorTypeList.ChainMail,
            });

            IGear NewHead = EquipmentFactory.CreateGear(new Gear
            {
                Name = "Testing Head #1",
                AC = 1,
                EquipmentType = EquipmentType.Clothing,
                Price = { Silver = 50 },
                SlotType = EquipmentSlot.HEAD,
                ArmorType = ArmorTypeList.PlateMail,
            });

            IGear Shoulder = EquipmentFactory.CreateGear(new Gear
            {
                Name = "Testing Shoulder",
                AC = 6,
                EquipmentType = EquipmentType.Clothing,
                Price = { Gold = 123 },
                SlotType = EquipmentSlot.SHOULDER,
                ArmorType = ArmorTypeList.Leather
            });
            IGear Chest = EquipmentFactory.CreateGear(new Gear
            {
                Name = "Testing Chest",
                AC = 6,
                EquipmentType = EquipmentType.Clothing,
                Price = { Gold = 123 },
                SlotType = EquipmentSlot.CHEST,
                ArmorType = ArmorTypeList.Leather
            });
            IGear Wrists = EquipmentFactory.CreateGear(new Gear
            {
                Name = "Testing Wrist",
                AC = 6,
                EquipmentType = EquipmentType.Clothing,
                Price = { Gold = 123 },
                SlotType = EquipmentSlot.WRIST,
                ArmorType = ArmorTypeList.Leather
            });
            IGear Hands = EquipmentFactory.CreateGear(new Gear
            {
                Name = "Testing Hands",
                AC = 6,
                EquipmentType = EquipmentType.Clothing,
                Price = { Gold = 123 },
                SlotType = EquipmentSlot.HANDS,
                ArmorType = ArmorTypeList.Leather
            });
            IGear Legs = EquipmentFactory.CreateGear(new Gear
            {
                Name = "Testing Legs",
                AC = 6,
                EquipmentType = EquipmentType.Clothing,
                Price = { Gold = 123 },
                SlotType = EquipmentSlot.LEGS,
                ArmorType = ArmorTypeList.Leather
            });
            IGear Feet = EquipmentFactory.CreateGear(new Gear
            {
                Name = "Testing Feet",
                AC = 6,
                EquipmentType = EquipmentType.Clothing,
                Price = { Gold = 123 },
                SlotType = EquipmentSlot.FEET,
                ArmorType = ArmorTypeList.Leather
            });

            Character.AddItem(Head, 1);
            Character.AddItem(NewHead, 1);
            Character.AddItem(Shoulder, 1);
            Character.AddItem(Chest, 1);
            Character.AddItem(Wrists, 1);
            Character.AddItem(Hands, 1);
            Character.AddItem(Legs, 1);
            Character.AddItem(Feet, 1);
            Character.AddItem(Sword, 1);
            Character.AddItem(Shield, 1);

            Character.EquipItem(Head);
            Character.EquipItem(NewHead);
            Character.EquipItem(Shoulder);
            Character.EquipItem(Chest);
            Character.EquipItem(Wrists);
            Character.EquipItem(Hands);
            Character.EquipItem(Legs);
            Character.EquipItem(Feet);
            Character.EquipItem(Sword);
            Character.EquipItem(Shield);


            
            ISpell MagicMissle = SpellFactory.CreateSpell(new Spell
            {
                SpellID = "magic_missles_level_1",
                Name = "Magic Missle",
                Level = 1,
                School = {
                    SpellSchool.Evocation
                },
                Range = { RangeType = SpellRangeType.Yards, yards = 60 },
                Compontents = { SpellCompontents.V, SpellCompontents.S },
                Duration = new SpellDurationInfo { DurationType = SpellDurationType.Instantaneous },
                CastingTime = 1,
                Classes =
                {
                    ClassType.Wizard
                },
                AOE = new AreaOfEffect
                {
                    Type = AOETypes.CUBE,
                    AOESize = 10,
                    Ruler = RulerTypes.Feet
                },
                SavingThrows =
                {
                    SavingThrowType.None
                },
                Description = "Use of magic missles spell creates up to five missles of magical energy that dart forth from the wizard's fingertip and unerringly strike their target. This includes enemy creatures in a melee."
            });

            Character.AddSpell(MagicMissle);

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
