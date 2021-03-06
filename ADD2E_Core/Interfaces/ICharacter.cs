﻿using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Models;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Interfaces
{
    public interface ICharacter
    {
        int PlayerID { get; set; }
        string Name { get; set; }
        int Level { get; set; }
        bool MainCharacter { get; set; }
        int? HitPoints { get; set; }
        int TmpHitPoints { get; set; }
        int ArmorClass { get; set; }
        AlignmentList Alignment { get; set; }
        bool RandomizeStats { get; set; }
        IRace Race { get; set; }
        Money CoinPurse { get; set; }
        IClass Class { get; set; }
        ThacoScore Thaco { get; set; }
        AbilityScores AbilityScores { get; set; }
        SavingThrow SavingThrows { get; set; }
        List<IEquipment> Equipment { get; set; } 
        IWeapon PrimaryWeapon { get; set; }
        ClassExperienceLevel LevelInfo { get; set; }
        ClassExperienceLevel NextLevelInfo { get; set; }
        public int Experience { get; set; } 
        RaceType RaceType { get; set; }
        ClassType ClassType { get; set; }
        IWeapon SecondaryWeapon { get; set; }
        List<IEquipment> EquippedGear { get; set; }
        List<ISpell> SpellBook { get; set; }
        void CreateCharacter();
        void AddItem(IEquipment item, int quantity);
        void RemoveItem(IEquipment item, int quantity);
        void AddMoney(Money m);
        void RemoveMoney(Money m);
        void EquipItem(IEquipment item);
        void AddSpell(ISpell spell);
    }
}
