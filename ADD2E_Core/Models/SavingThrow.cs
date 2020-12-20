using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Models
{
    public class SavingThrow
    {
        public int Level = 1;
        public ParalyzationSave Paralyzation;
        public PoisonSave Poison;
        public DeathMagicSave DeathMagic;
        public RodSave Rod;
        public StaffSave Staff;
        public WandSave Wand;
        public PetrificationSave Petrification;
        public PolymorphSave Polymorph;
        public BreathWeaponSave BreathWeapon;
        public SpellSave Spell;
    }
}
