using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
using ADD2E_Core.Models;
using ADD2E_Core.Extensions;
using ADD2E_Core.Exceptions;
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
        
        public static AbilityScores RandomizeAbilityScores(AbilityScores abilityScores, IClass _char = null)
        {
            AbilityScoreManager abilityScoreRules = new AbilityScoreManager();

            List<int> allRolls = new List<int>();
            allRolls.Add(DiceManager.FourDSixDropTheLowest());
            allRolls.Add(DiceManager.FourDSixDropTheLowest());
            allRolls.Add(DiceManager.FourDSixDropTheLowest());
            allRolls.Add(DiceManager.FourDSixDropTheLowest());
            allRolls.Add(DiceManager.FourDSixDropTheLowest());
            allRolls.Add(DiceManager.FourDSixDropTheLowest());

            var orderedList = allRolls.OrderByDescending(x => x);

            List<AbilityScoreType> primeAdded = new List<AbilityScoreType>();

            int orderedI = 0;

            foreach (var minIndi in _char.MinimumAbilityScoreRequirements)
            {
                var thisRoll = orderedList.ElementAt(orderedI);
                switch(minIndi.Key)
                {
                    case AbilityScoreType.Strength:
                        abilityScores.Strength = abilityScoreRules.SetStrength(thisRoll);
                        primeAdded.Add(AbilityScoreType.Strength);
                        ++orderedI;
                        break;
                    case AbilityScoreType.Dextarity:
                        abilityScores.Dexterity = abilityScoreRules.SetDexterity(thisRoll);
                        primeAdded.Add(AbilityScoreType.Strength);
                        ++orderedI;
                        break;
                    case AbilityScoreType.Constitution:
                        abilityScores.Constitution = abilityScoreRules.SetConstitution(thisRoll);
                        primeAdded.Add(AbilityScoreType.Strength);
                        ++orderedI;
                        break;
                    case AbilityScoreType.Intelligence:
                        abilityScores.Intelligence = abilityScoreRules.SetIntelligence(thisRoll);
                        primeAdded.Add(AbilityScoreType.Intelligence);
                        ++orderedI;
                        break;
                    case AbilityScoreType.Wisdom:
                        abilityScores.Wisdom = abilityScoreRules.SetWisdom(thisRoll);
                        primeAdded.Add(AbilityScoreType.Wisdom);
                        ++orderedI;
                        break;
                    case AbilityScoreType.Charisma:
                        abilityScores.Charisma = abilityScoreRules.SetCharisma(thisRoll);
                        primeAdded.Add(AbilityScoreType.Charisma);
                        ++orderedI;
                        break;
                }
            }

            List<AbilityScoreType> AllAbilityScores = new List<AbilityScoreType>
            {
                AbilityScoreType.Strength,
                AbilityScoreType.Dextarity,
                AbilityScoreType.Constitution,
                AbilityScoreType.Intelligence,
                AbilityScoreType.Wisdom,
                AbilityScoreType.Charisma
            };

            foreach(var this_ability in AllAbilityScores)
            {
                var thisRoll = orderedList.ElementAt(orderedI);
                if (!primeAdded.Contains(this_ability))
                {
                    switch (this_ability)
                    {
                        case AbilityScoreType.Strength:
                            abilityScores.Strength = abilityScoreRules.SetStrength(thisRoll);
                            ++orderedI;
                            break;
                        case AbilityScoreType.Dextarity:
                            abilityScores.Dexterity = abilityScoreRules.SetDexterity(thisRoll);
                            ++orderedI;
                            break;
                        case AbilityScoreType.Constitution:
                            abilityScores.Constitution = abilityScoreRules.SetConstitution(thisRoll);
                            ++orderedI;
                            break;
                        case AbilityScoreType.Intelligence:
                            abilityScores.Intelligence = abilityScoreRules.SetIntelligence(thisRoll);
                            ++orderedI;
                            break;
                        case AbilityScoreType.Wisdom:
                            abilityScores.Wisdom = abilityScoreRules.SetWisdom(thisRoll);
                            ++orderedI;
                            break;
                        case AbilityScoreType.Charisma:
                            abilityScores.Charisma = abilityScoreRules.SetCharisma(thisRoll);
                            ++orderedI;
                            break;
                    }
                }
            }

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

        #region Character Requirements

        public static bool DoesCharacterMeetRequirements(AbilityScores _abilityScores, IClass _class, IRace _race)
        {
            bool doesMeetRequirements = true;
            string problemAbilityScore = "";
            foreach(var _req in _class.MinimumAbilityScoreRequirements)
            {
                if(_req.Key == AbilityScoreType.Strength)
                {
                    problemAbilityScore = _req.Key.ToString() + string.Format($"({_abilityScores.Strength.Value})");
                    if (_abilityScores.Strength.Value < _req.Value) { doesMeetRequirements = false; break; }
                }
                if (_req.Key == AbilityScoreType.Constitution)
                {
                    problemAbilityScore = _req.Key.ToString() + string.Format($"({_abilityScores.Constitution.Value})");
                    if (_abilityScores.Constitution.Value < _req.Value) { doesMeetRequirements = false; break; }
                }
                if (_req.Key == AbilityScoreType.Charisma)
                {
                    problemAbilityScore = _req.Key.ToString() + string.Format($"({_abilityScores.Charisma.Value})");
                    if (_abilityScores.Charisma.Value < _req.Value) { doesMeetRequirements = false; break; }
                }
                if (_req.Key == AbilityScoreType.Dextarity)
                {
                    problemAbilityScore = _req.Key.ToString() + string.Format($"({_abilityScores.Dexterity.Value})");
                    if (_abilityScores.Dexterity.Value < _req.Value) { doesMeetRequirements = false; break; } 
                }
                if (_req.Key == AbilityScoreType.Wisdom)
                {
                    problemAbilityScore = _req.Key.ToString() + string.Format($"({_abilityScores.Wisdom.Value})");
                    if (_abilityScores.Wisdom.Value < _req.Value) { doesMeetRequirements = false; break; } 
                }
                if (_req.Key == AbilityScoreType.Intelligence)
                {
                    problemAbilityScore = _req.Key.ToString() + string.Format($"({_abilityScores.Intelligence.Value})");
                    if (_abilityScores.Intelligence.Value < _req.Value) { doesMeetRequirements = false; break; }
                    
                }

            }
            if(doesMeetRequirements == false)
            {
                string errorMessage = string.Format($"Ability Score Requirement Error: {problemAbilityScore} is too low.");
                throw new InvalidCharacterCreationException(errorMessage);
            }
            return doesMeetRequirements;
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
        public static double CurrentLevelCompletedPercentage(int currentExp, int thisLevelExpBase, int nextLevelExp)
        {
            int first = currentExp - thisLevelExpBase;
            int next = nextLevelExp - thisLevelExpBase;
            return Convert.ToDouble(Math.Round(((decimal)first / (decimal)next) * 100, 2));
           // return Convert.ToDouble(Math.Round(((((decimal)currentExp) - thisLevelExpBase) / (decimal)nextLevelExp) * 100, 2));
        }
        #endregion

        #region Equipping

        #region Inventory 

        public static List<EquipmentSlot> UniqueSlots = new List<EquipmentSlot> {
                EquipmentSlot.HEAD,
                EquipmentSlot.CHEST,
                EquipmentSlot.WRIST,
                EquipmentSlot.HANDS,
                EquipmentSlot.LEGS,
                EquipmentSlot.FEET
        };

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
        #endregion
    }
}
