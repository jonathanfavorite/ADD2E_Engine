using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Models;
using System.Linq;

namespace ADD2E_Core.Services
{
    public static class SavingThrowManager
    {
        private static Dictionary<ClassGroup, List<SavingThrow>> List;
        public static SavingThrow GetSavingThrow(ClassGroup _ClassGroup, int Level = 1)
        {
            List = new Dictionary<ClassGroup, List<SavingThrow>>();
            List.Add(ClassGroup.Warrior, WarriorSaves());
            return List[_ClassGroup].First(l => l.Level == Level);
        }
        private static List<SavingThrow> WarriorSaves()
        {
            return new List<SavingThrow>
            {
                new SavingThrow {
                    Level = 0,
                    Paralyzation =  new ParalyzationSave { Value = 16 },
                    Poison =        new PoisonSave { Value = 16 },
                    DeathMagic =    new DeathMagicSave { Value = 16 },
                    Rod =           new RodSave { Value = 18 },
                    Staff =         new StaffSave { Value = 18 },
                    Wand =          new WandSave { Value = 18},
                    Petrification = new PetrificationSave { Value = 17 },
                    Polymorph =     new PolymorphSave { Value = 17 },
                    BreathWeapon =  new BreathWeaponSave { Value = 20 },
                    Spell =         new SpellSave { Value = 19 }
                },
                new SavingThrow {
                    Level = 1,
                    Paralyzation =  new ParalyzationSave { Value = 14 },
                    Poison =        new PoisonSave { Value = 14 },
                    DeathMagic =    new DeathMagicSave { Value = 14 },
                    Rod =           new RodSave { Value = 16 },
                    Staff =         new StaffSave { Value = 16 },
                    Wand =          new WandSave { Value = 16},
                    Petrification = new PetrificationSave { Value = 15 },
                    Polymorph =     new PolymorphSave { Value = 16 },
                    BreathWeapon =  new BreathWeaponSave { Value = 17 },
                    Spell =         new SpellSave { Value = 17 } 
                },
                new SavingThrow {
                    Level = 2,
                    Paralyzation =  new ParalyzationSave { Value = 14 },
                    Poison =        new PoisonSave { Value = 14 },
                    DeathMagic =    new DeathMagicSave { Value = 14 },
                    Rod =           new RodSave { Value = 16 },
                    Staff =         new StaffSave { Value = 16 },
                    Wand =          new WandSave { Value = 16},
                    Petrification = new PetrificationSave { Value = 15 },
                    Polymorph =     new PolymorphSave { Value = 16 },
                    BreathWeapon =  new BreathWeaponSave { Value = 17 },
                    Spell =         new SpellSave { Value = 17 }
                },
                new SavingThrow {
                    Level = 3,
                    Paralyzation =  new ParalyzationSave { Value = 13 },
                    Poison =        new PoisonSave { Value = 13 },
                    DeathMagic =    new DeathMagicSave { Value = 13 },
                    Rod =           new RodSave { Value = 15 },
                    Staff =         new StaffSave { Value = 15 },
                    Wand =          new WandSave { Value = 15},
                    Petrification = new PetrificationSave { Value = 14 },
                    Polymorph =     new PolymorphSave { Value = 14 },
                    BreathWeapon =  new BreathWeaponSave { Value = 16 },
                    Spell =         new SpellSave { Value = 16 }
                },
                new SavingThrow {
                    Level = 4,
                    Paralyzation =  new ParalyzationSave { Value = 13 },
                    Poison =        new PoisonSave { Value = 13 },
                    DeathMagic =    new DeathMagicSave { Value = 13 },
                    Rod =           new RodSave { Value = 15 },
                    Staff =         new StaffSave { Value = 15 },
                    Wand =          new WandSave { Value = 15},
                    Petrification = new PetrificationSave { Value = 14 },
                    Polymorph =     new PolymorphSave { Value = 14 },
                    BreathWeapon =  new BreathWeaponSave { Value = 16 },
                    Spell =         new SpellSave { Value = 16 }
                },
                new SavingThrow {
                    Level = 5,
                    Paralyzation =  new ParalyzationSave { Value = 11 },
                    Poison =        new PoisonSave { Value = 11 },
                    DeathMagic =    new DeathMagicSave { Value = 11 },
                    Rod =           new RodSave { Value = 13 },
                    Staff =         new StaffSave { Value = 13 },
                    Wand =          new WandSave { Value = 13},
                    Petrification = new PetrificationSave { Value = 12 },
                    Polymorph =     new PolymorphSave { Value = 12 },
                    BreathWeapon =  new BreathWeaponSave { Value = 13 },
                    Spell =         new SpellSave { Value = 14 }
                },
                new SavingThrow {
                    Level = 6,
                    Paralyzation =  new ParalyzationSave { Value = 11 },
                    Poison =        new PoisonSave { Value = 11 },
                    DeathMagic =    new DeathMagicSave { Value = 11 },
                    Rod =           new RodSave { Value = 13 },
                    Staff =         new StaffSave { Value = 13 },
                    Wand =          new WandSave { Value = 13},
                    Petrification = new PetrificationSave { Value = 12 },
                    Polymorph =     new PolymorphSave { Value = 12 },
                    BreathWeapon =  new BreathWeaponSave { Value = 13 },
                    Spell =         new SpellSave { Value = 14 }
                },
                new SavingThrow {
                    Level = 7,
                    Paralyzation =  new ParalyzationSave { Value = 10 },
                    Poison =        new PoisonSave { Value = 10 },
                    DeathMagic =    new DeathMagicSave { Value = 10 },
                    Rod =           new RodSave { Value = 12 },
                    Staff =         new StaffSave { Value = 12 },
                    Wand =          new WandSave { Value = 12},
                    Petrification = new PetrificationSave { Value = 11 },
                    Polymorph =     new PolymorphSave { Value = 11 },
                    BreathWeapon =  new BreathWeaponSave { Value = 12 },
                    Spell =         new SpellSave { Value = 13 }
                },
                new SavingThrow {
                    Level = 8,
                    Paralyzation =  new ParalyzationSave { Value = 10 },
                    Poison =        new PoisonSave { Value = 10 },
                    DeathMagic =    new DeathMagicSave { Value = 10 },
                    Rod =           new RodSave { Value = 12 },
                    Staff =         new StaffSave { Value = 12 },
                    Wand =          new WandSave { Value = 12},
                    Petrification = new PetrificationSave { Value = 11 },
                    Polymorph =     new PolymorphSave { Value = 11 },
                    BreathWeapon =  new BreathWeaponSave { Value = 12 },
                    Spell =         new SpellSave { Value = 13 }
                },
                new SavingThrow {
                    Level = 9,
                    Paralyzation =  new ParalyzationSave { Value = 8 },
                    Poison =        new PoisonSave { Value = 8 },
                    DeathMagic =    new DeathMagicSave { Value = 8 },
                    Rod =           new RodSave { Value = 10 },
                    Staff =         new StaffSave { Value = 10 },
                    Wand =          new WandSave { Value = 10},
                    Petrification = new PetrificationSave { Value = 9 },
                    Polymorph =     new PolymorphSave { Value = 9 },
                    BreathWeapon =  new BreathWeaponSave { Value = 9 },
                    Spell =         new SpellSave { Value = 11 }
                },
                new SavingThrow {
                    Level = 10,
                    Paralyzation =  new ParalyzationSave { Value = 8 },
                    Poison =        new PoisonSave { Value = 8 },
                    DeathMagic =    new DeathMagicSave { Value = 8 },
                    Rod =           new RodSave { Value = 10 },
                    Staff =         new StaffSave { Value = 10 },
                    Wand =          new WandSave { Value = 10},
                    Petrification = new PetrificationSave { Value = 9 },
                    Polymorph =     new PolymorphSave { Value = 9 },
                    BreathWeapon =  new BreathWeaponSave { Value = 9 },
                    Spell =         new SpellSave { Value = 11 }
                },
                new SavingThrow {
                    Level = 11,
                    Paralyzation =  new ParalyzationSave { Value = 7 },
                    Poison =        new PoisonSave { Value = 7 },
                    DeathMagic =    new DeathMagicSave { Value = 7 },
                    Rod =           new RodSave { Value = 9 },
                    Staff =         new StaffSave { Value = 9 },
                    Wand =          new WandSave { Value = 9},
                    Petrification = new PetrificationSave { Value = 8 },
                    Polymorph =     new PolymorphSave { Value = 8 },
                    BreathWeapon =  new BreathWeaponSave { Value = 8 },
                    Spell =         new SpellSave { Value = 10 }
                },
                new SavingThrow {
                    Level = 12,
                    Paralyzation =  new ParalyzationSave { Value = 7 },
                    Poison =        new PoisonSave { Value = 7 },
                    DeathMagic =    new DeathMagicSave { Value = 7 },
                    Rod =           new RodSave { Value = 9 },
                    Staff =         new StaffSave { Value = 9 },
                    Wand =          new WandSave { Value = 9},
                    Petrification = new PetrificationSave { Value = 8 },
                    Polymorph =     new PolymorphSave { Value = 8 },
                    BreathWeapon =  new BreathWeaponSave { Value = 8 },
                    Spell =         new SpellSave { Value = 10 }
                },
                new SavingThrow {
                    Level = 13,
                    Paralyzation =  new ParalyzationSave { Value = 5 },
                    Poison =        new PoisonSave { Value = 5 },
                    DeathMagic =    new DeathMagicSave { Value = 5 },
                    Rod =           new RodSave { Value = 7 },
                    Staff =         new StaffSave { Value = 7 },
                    Wand =          new WandSave { Value = 7},
                    Petrification = new PetrificationSave { Value = 6 },
                    Polymorph =     new PolymorphSave { Value = 6 },
                    BreathWeapon =  new BreathWeaponSave { Value = 5 },
                    Spell =         new SpellSave { Value = 8 }
                },
                new SavingThrow {
                    Level = 14,
                    Paralyzation =  new ParalyzationSave { Value = 5 },
                    Poison =        new PoisonSave { Value = 5 },
                    DeathMagic =    new DeathMagicSave { Value = 5 },
                    Rod =           new RodSave { Value = 7 },
                    Staff =         new StaffSave { Value = 7 },
                    Wand =          new WandSave { Value = 7},
                    Petrification = new PetrificationSave { Value = 6 },
                    Polymorph =     new PolymorphSave { Value = 6 },
                    BreathWeapon =  new BreathWeaponSave { Value = 5 },
                    Spell =         new SpellSave { Value = 8 }
                },
                new SavingThrow {
                    Level = 15,
                    Paralyzation =  new ParalyzationSave { Value = 4 },
                    Poison =        new PoisonSave { Value = 4 },
                    DeathMagic =    new DeathMagicSave { Value = 4 },
                    Rod =           new RodSave { Value = 6 },
                    Staff =         new StaffSave { Value = 6 },
                    Wand =          new WandSave { Value = 6},
                    Petrification = new PetrificationSave { Value = 5 },
                    Polymorph =     new PolymorphSave { Value = 5 },
                    BreathWeapon =  new BreathWeaponSave { Value = 4 },
                    Spell =         new SpellSave { Value = 7 }
                },
                new SavingThrow {
                    Level = 16,
                    Paralyzation =  new ParalyzationSave { Value = 4 },
                    Poison =        new PoisonSave { Value = 4 },
                    DeathMagic =    new DeathMagicSave { Value = 4 },
                    Rod =           new RodSave { Value = 6 },
                    Staff =         new StaffSave { Value = 6 },
                    Wand =          new WandSave { Value = 6},
                    Petrification = new PetrificationSave { Value = 5 },
                    Polymorph =     new PolymorphSave { Value = 5 },
                    BreathWeapon =  new BreathWeaponSave { Value = 4 },
                    Spell =         new SpellSave { Value = 7 }
                },
                new SavingThrow {
                    Level = 17,
                    Paralyzation =  new ParalyzationSave { Value = 3 },
                    Poison =        new PoisonSave { Value = 3 },
                    DeathMagic =    new DeathMagicSave { Value = 3 },
                    Rod =           new RodSave { Value = 5 },
                    Staff =         new StaffSave { Value = 5 },
                    Wand =          new WandSave { Value = 5},
                    Petrification = new PetrificationSave { Value = 4 },
                    Polymorph =     new PolymorphSave { Value = 4 },
                    BreathWeapon =  new BreathWeaponSave { Value = 4 },
                    Spell =         new SpellSave { Value = 6 }
                }
            };
        }

    }
   
}
