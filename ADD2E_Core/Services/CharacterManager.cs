using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
using ADD2E_Core.Models;
using System.Linq;

namespace ADD2E_Core.Services
{
    public class CharacterManager
    {
        public bool CanRacePlayClass(IRace thatRace, ClassType thatClass)
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
        public IRace SetPlayerRace(RaceType rType)
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
        private IRace SetHuman()
        {
            return new Human();
        }
        private IRace SetElf()
        {
            return new Human();
        }
        #endregion

        #region Set Class
        public IClass setCharacterClass(ClassType cType)
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

        #region Set Hitpoints
        public int SetHitPoints(int Level, IClass Class, AbilityScores AbilityScores, int? CurrentHP)
        {
            int returnHP = 0;
            if (CurrentHP == null)
            {
                // Get the class Hit Die
                if (Level == 1)
                {
                    returnHP = Class.HitDie + AbilityScores.Constitution.HitPointAdjustment;
                }
                else
                {
                    for (int i = 0; i <= Level - 1; i++)
                    {
                        int roll = 0;
                        if (i != 0)
                        {
                            DiceManager diceManager = new DiceManager();
                            roll = diceManager.Roll(1, Class.HitDie).Total + AbilityScores.Constitution.HitPointAdjustment;
                        }
                        else
                        {
                            roll = Class.HitDie;
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
        #endregion

        #region Ability Scores
        
        public AbilityScores RandomizeAbilityScores(AbilityScores abilityScores)
        {
            
            DiceManager dr = new DiceManager();
            AbilityScoreManager abilityScoreRules = new AbilityScoreManager();
            abilityScores.Strength = abilityScoreRules.SetStrength(dr.FourDSixDropTheLowest());
            abilityScores.Dexterity = abilityScoreRules.SetDexterity(dr.FourDSixDropTheLowest());
            abilityScores.Constitution = abilityScoreRules.SetConstitution(dr.FourDSixDropTheLowest());
            abilityScores.Intelligence = abilityScoreRules.SetIntelligence(dr.FourDSixDropTheLowest());
            abilityScores.Wisdom = abilityScoreRules.SetWisdom(dr.FourDSixDropTheLowest());
            abilityScores.Charisma = abilityScoreRules.SetCharisma(dr.FourDSixDropTheLowest());
            return abilityScores;
        }
        public AbilityScores UpdateAbilityScores(AbilityScores abilityScores)
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

        #region Thaco and AC
        public ThacoScore SetupThaco(ClassGroup CG, int Level)
        {
            ThacoManager thacoManager = new ThacoManager();
            return thacoManager.getThaco(CG, Level);
        }
        #endregion

        #region Inventory 
        public List<IEquipment> AddItem(IEquipment item, int quantity = 1)
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
        public List<IEquipment> RemoveItem(IEquipment item, int quantity = 1, List<IEquipment> myEquipment = null)
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

        public Money AddMoney(Money coinpurse, Money newMoney)
        {
            MoneyManager mManager = new MoneyManager();
            return mManager.addMoney(coinpurse, newMoney);
        }
        public Money RemoveMoney(Money coinpurse, Money newMoney)
        {
            MoneyManager mManager = new MoneyManager();
            return mManager.removeMoney(coinpurse, newMoney);
        }

        #endregion

        #region Weapons
        public List<IEquipment> NoLongerEquipped(IEquipment item, List<IEquipment> allItems)
        {
            if (item != null)
            {
                allItems.First(x => x == item).Equipped = false;
            }
            return allItems;
        }
        #endregion

    }
}
