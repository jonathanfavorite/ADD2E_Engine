﻿using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
using ADD2E_Core.Services;
using ADD2E_Core.Exceptions;
namespace ADD2E_Core.Models
{
    public class PlayerCharacter : IPlayerCharacter
    {
        public int PlayerID { get; set; }
        public string OwnerName { get; set; }
        public bool MainCharacter { get; set; } = false;
        public string Name { get; set; }
        public int Level { get; set; } = 1;
        public int? HitPoints { get; set; } = null;
        public int TmpHitPoints { get; set; }
        public int ArmorClass { get; set; } = 10;
        public AlignmentList Alignment { get; set; } = AlignmentList.TRUENEUTRAL;
        public bool RandomizeStats { get; set; } = false;
        public IRace Race { get; set; }
        public Money CoinPurse { get; set; } = new Money();
        public IClass Class { get; set; }
        public ThacoScore Thaco { get; set; }
        public AbilityScores AbilityScores { get; set; } = new AbilityScores();
        public SavingThrow SavingThrows { get; set; }
        public List<IEquipment> Equipment { get; set; } = new List<IEquipment>();
        public IWeapon PrimaryWeapon { get; set; } = null;
        public IWeapon SecondaryWeapon { get; set; } = null;
        public List<IEquipment> EquippedGear { get; set; } = new List<IEquipment>();
        public ClassExperienceLevel LevelInfo { get; set; }
        public ClassExperienceLevel NextLevelInfo { get; set; }
        public int Experience { get; set; } = 0;
        public double CurrentLevelProgressExp { get; set; } = 0.00;
        public RaceType RaceType { get; set; }
        public ClassType ClassType { get; set; }

        public void CreateCharacter()
        {
            Console.WriteLine("Created Char");
            PlayerID = IDGenerator.nextID();
            Race = CharacterManager.SetPlayerRace(RaceType);
            if(CharacterManager.CanRacePlayClass(Race, ClassType))
            {
                Class = CharacterManager.setCharacterClass(ClassType);
                if (RandomizeStats)
                {
                    AbilityScores = CharacterManager.RandomizeAbilityScores(AbilityScores);
                }
                else
                {
                    AbilityScores = CharacterManager.UpdateAbilityScores(AbilityScores);
                }
                HitPoints = CharacterManager.SetInitialHitPoints(Level, Class, AbilityScores, HitPoints);
                RefreshCharacter();
            }
            else
            {
                string expMessage = string.Format("{0} cannot be a {1}", Race.ToString(), ClassType.ToString());
                throw new InvalidCharacterCreationException(expMessage);
            }
        }
        private void RefreshCharacter()
        {
            LevelInfo = ClassManager.getExperienceLevels(ClassType, Level);
            if (Level > 1)
            {
                Experience = LevelInfo.Experience;
            }
            NextLevelInfo = ClassManager.getExperienceLevels(ClassType, Level + 1);
            TmpHitPoints = Convert.ToInt32(HitPoints);
            Thaco = CharacterManager.SetupThaco(Class.ClassGroup, Level);
            SavingThrows = ClassManager.SetupSavingThrows(Class.ClassGroup, Level);
            CurrentLevelProgressExp = CharacterManager.CurrentLevelCompletedPercentage(Experience, NextLevelInfo.Experience);
        }
        public void AddItem(IEquipment Item, int Quantity = 1)
        {
            var addedItems = CharacterManager.AddItem(Item, Quantity);
            foreach(IEquipment item in addedItems)
            {
                Equipment.Add(item);
            }
        }
        public void RemoveItem(IEquipment Item, int Quantity = 1)
        {
            Equipment = CharacterManager.RemoveItem(Item, Quantity, Equipment);
        }
        public void AddMoney(Money m)
        {
            CoinPurse = CharacterManager.AddMoney(CoinPurse, m);
        }
        public void RemoveMoney(Money m)
        {
            CoinPurse = CharacterManager.RemoveMoney(CoinPurse, m);
        }
        public void AddExperience(int exp)
        {
            Console.WriteLine($"Adding {exp} to {Name}");
            Console.WriteLine($"Current Level: {Level}");
            ExperienceResponse addExp = CharacterManager.AddEXP(Experience, NextLevelInfo.Experience, ClassType, exp);
            Experience = addExp.ExperienceTotal;
            if(addExp.ResponseType == CharacterResponseTypes.LEVELEDUP)
            {
                
                LevelInfo = addExp.NewExperienceLevel;
                int levelDifference = addExp.NewExperienceLevel.Level - Level;
                NextLevelInfo = addExp.NextExperienceLevel;
                Level = LevelInfo.Level;

                var currentHitPointMax = HitPoints;
                HitPoints = CharacterManager.UpdateHitPoints(Class, AbilityScores, Convert.ToInt32(currentHitPointMax), levelDifference);
                RefreshCharacter();
                Console.WriteLine($"{Name} leveled up from {Level} to {addExp.NewExperienceLevel.Level}");
                Console.WriteLine($"New Level: {addExp.NewExperienceLevel.Level}");
            }
            else
            {
                CurrentLevelProgressExp = CharacterManager.CurrentLevelCompletedPercentage(Experience, NextLevelInfo.Experience);
            }
            Console.WriteLine($"Added {exp} experience. ({Experience} / {NextLevelInfo.Experience})\r\n");
        }
        public void EquipItem(IEquipment item)
        {
            if (item.Weareable)
            {
                if (item is IWeapon weapon)
                {
                    if (weapon.SlotType == EquipmentSlot.PRIMARY)
                    {
                        EquipPrimary(weapon);
                    }
                    else
                    {
                        EquipSecondary(weapon);
                    }
                }
                else if (item is IGear gear)
                {
                    EquipGear(gear);
                }
                ArmorClass = CharacterManager.SetupAC(EquippedGear);
            }
            else
            {
                string exceptionMsg = string.Format($"{item.Name} is not a weapon or piece of gear.");
                throw new InvalidEquipmentException(exceptionMsg);
            }
        }
        private void EquipPrimary(IWeapon item)
        {
            if (item.SlotType == EquipmentSlot.PRIMARY)
            { 
                EquippedGear = CharacterManager.NoLongerEquippedBySlotType(EquipmentSlot.PRIMARY, EquippedGear);
                PrimaryWeapon = item;
                EquippedGear.Add(item);
                PrimaryWeapon.Equipped = true;
            }
            else
            {
                string exceptionMsg = string.Format($"{item.Name} is not a primary weapon.");
                throw new InvalidEquipmentException(exceptionMsg);
            }
        }
        private void EquipSecondary(IWeapon item)
        {
            if (item.SlotType == EquipmentSlot.SECONDARY)
            {
                EquippedGear = CharacterManager.NoLongerEquippedBySlotType(EquipmentSlot.PRIMARY, EquippedGear);
                SecondaryWeapon = item;
                EquippedGear.Add(item);
                SecondaryWeapon.Equipped = true;
            }
            else
            {
                string exceptionMsg = string.Format($"{item.Name} is not a secondary weapon.");
                throw new InvalidEquipmentException(exceptionMsg);
            }
        }
        private void EquipGear(IGear item)
        {
            item.Equipped = true;
            EquippedGear.Add(item);
        }


    }
}
