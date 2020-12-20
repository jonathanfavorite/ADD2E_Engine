﻿using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
using ADD2E_Core.Models;
using ADD2E_Core.Extensions;
using System.Linq;

namespace ADD2E_Core.Services
{
    public static class CharacterManager
    {
        public static bool CanRacePlayClass(IRace thatRace, ClassType thatClass)
        {
            if (thatRace.PlayableClasses.Contains(thatClass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Set/Get Race
        public static IRace SetPlayerRace(RaceType rType)
        {
            if (rType == RaceType.Human)
            {
                return SetHuman();
            }
            if (rType == RaceType.Elf)
            {
                return SetElf();
            }
            else
            {
                return null;
            }
        }
        private static IRace SetHuman()
        {
            return new Human();
        }
        private static IRace SetElf()
        {
            return new Human();
        }
        #endregion

        #region Set Class
        public static IClass setCharacterClass(ClassType cType)
        {
            if(cType == ClassType.Fighter)
            {
                return new Fighter();
            }
            else
            {
                throw new Exception("Could not locate class: " + cType.ToString());
            }
        }
        #endregion

        #region Set Hitpoints / Update HitPoints
        public static int SetInitialHitPoints(int Level, IClass Class, AbilityScores AbilityScores, int? CurrentHP)
        {
            int returnHP = 0;
            if (CurrentHP == null)
            {
                if (Level == 1)
                {
                    returnHP = Class.HitDie + AbilityScores.Constitution.HitPointAdjustment;
                }
                else
                {
                    for (int i = 0; i <= Level - 1; i++)
                    {
                        int roll = 0;
                        if (i == 0)
                        {
                            roll = Class.HitDie;
                        }
                        else
                        {
                            roll = DiceManager.Roll(1, Class.HitDie).Total + AbilityScores.Constitution.HitPointAdjustment;
                        }
                        returnHP += roll;
                    }
                }
            }
            else
            {
                returnHP = Convert.ToInt32(CurrentHP);
            }
            return returnHP;
        }

        public static int UpdateHitPoints(IClass Class, AbilityScores AbilityScores, int CurrentHP, int newLevels = 1)
        {
            int newRoll = CurrentHP;
            for(int i = 0; i <= newLevels - 1; i++)
            {
                newRoll += DiceManager.Roll(1, Class.HitDie).Total + AbilityScores.Constitution.HitPointAdjustment;
            }
            return newRoll;
        }
        #endregion

        #region Ability Scores
        
        public static AbilityScores RandomizeAbilityScores(AbilityScores abilityScores)
        {
            AbilityScoreManager abilityScoreRules = new AbilityScoreManager();
            abilityScores.Strength = abilityScoreRules.SetStrength(DiceManager.FourDSixDropTheLowest());
            abilityScores.Dexterity = abilityScoreRules.SetDexterity(DiceManager.FourDSixDropTheLowest());
            abilityScores.Constitution = abilityScoreRules.SetConstitution(DiceManager.FourDSixDropTheLowest());
            abilityScores.Intelligence = abilityScoreRules.SetIntelligence(DiceManager.FourDSixDropTheLowest());
            abilityScores.Wisdom = abilityScoreRules.SetWisdom(DiceManager.FourDSixDropTheLowest());
            abilityScores.Charisma = abilityScoreRules.SetCharisma(DiceManager.FourDSixDropTheLowest());
            return abilityScores;
        }
        public static AbilityScores UpdateAbilityScores(AbilityScores abilityScores)
        {
            AbilityScoreManager abilityScoreRules = new AbilityScoreManager();
            abilityScores.Strength = abilityScoreRules.SetStrength(abilityScores.Strength.Value);
            abilityScores.Dexterity = abilityScoreRules.SetDexterity(abilityScores.Dexterity.Value);
            abilityScores.Constitution = abilityScoreRules.SetConstitution(abilityScores.Constitution.Value);
            abilityScores.Intelligence = abilityScoreRules.SetIntelligence(abilityScores.Intelligence.Value);
            abilityScores.Wisdom = abilityScoreRules.SetWisdom(abilityScores.Wisdom.Value);
            abilityScores.Charisma = abilityScoreRules.SetCharisma(abilityScores.Charisma.Value);
            return abilityScores;
        }

        #endregion

        #region Thaco, AC & Saving Throws
        public static ThacoScore SetupThaco(ClassGroup CG, int Level)
        {
            ThacoManager thacoManager = new ThacoManager();
            return thacoManager.getThaco(CG, Level);
        }
        public static int SetupAC(List<IEquipment> equipment)
        {
            return CharacterCombatMaths.CalculateArmorClass(equipment);
        }
        #endregion

        #region Adding Experience
        public static ExperienceResponse AddEXP(int currentExp, int nextLevelExp, ClassType t, int newExp)
        {
            ExperienceResponse r = new ExperienceResponse();
            int addedExp = currentExp + newExp;
            if(currentExp + newExp >= nextLevelExp)
            {
                // Character Leveled Up
                r.ResponseType = CharacterResponseTypes.LEVELEDUP;
                ClassExperienceLevel newLevel = ClassManager.GetLevelByExperience(t, addedExp);
                ClassExperienceLevel nextLevel = ClassManager.getExperienceLevels(t, newLevel.Level);
                r.NewExperienceLevel = newLevel;
                r.NextExperienceLevel = nextLevel;
            }
            r.ExperienceTotal = addedExp;
            return r;
        }
        public static double CurrentLevelCompletedPercentage(int currentExp, int nextLevelExp)
        {
            return Convert.ToDouble(Math.Round(((decimal)currentExp / (decimal)nextLevelExp) * 100, 2));
        }
        #endregion

        #region Inventory 
        public static List<IEquipment> AddItem(IEquipment item, int quantity = 1)
        {
            List<IEquipment> returnEquipment = new List<IEquipment>();
            for(int i = 0; i <= quantity - 1; i++)
            {
                Random r = new Random();
                IEquipment thisItem = item;
                thisItem.ItemID = item.ToString() + "_" + r.Next(1, 99999);
                returnEquipment.Add(thisItem);
            }
            return returnEquipment;
        }
        public static List<IEquipment> RemoveItem(IEquipment item, int quantity = 1, List<IEquipment> myEquipment = null)
        {
            // Search to see if it exists
            var searchItem = myEquipment.FindAll(x => x.Name == item.Name).ToList();
            if(searchItem.Count() <= quantity) { quantity = searchItem.Count();  }
            for (int i = 0; i <= quantity - 1; i++)
            {
                myEquipment.Remove(searchItem[i]);
            }
            return myEquipment;
        }

        public static Money AddMoney(Money coinpurse, Money newMoney)
        {
            return MoneyManager.addMoney(coinpurse, newMoney);
        }
        public static Money RemoveMoney(Money coinpurse, Money newMoney)
        {
            return MoneyManager.removeMoney(coinpurse, newMoney);
        }

        #endregion

        #region Weapons
        public static List<IEquipment> NoLongerEquipped(IEquipment item, List<IEquipment> allItems)
        {
            var searchItem = allItems.First(x => x == item);
            if (searchItem != null)
            {
                searchItem.Equipped = false;
            }
            return allItems;
        }
        
        public static List<IEquipment> NoLongerEquippedBySlotType(EquipmentSlot slot, List<IEquipment> allItems)
        {
            List<IEquipment> retItems = new List<IEquipment>();
            foreach(IEquipment item in allItems)
            {
                
                if(item is IWeapon weapon)
                {
                    if(weapon.SlotType == slot)
                    {
                    }
                    else
                    {
                        retItems.Add(item);
                    }
                }
                else if(item is IGear gear)
                {
                    if (gear.SlotType == slot)
                    {
                    }
                    else
                    {
                        retItems.Add(item);
                    }
                }
                else
                {
                   // retItems.Add(item);
                }
            }
            return retItems;
        }
        #endregion

    }
}
