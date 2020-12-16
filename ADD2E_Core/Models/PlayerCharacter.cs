using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
using ADD2E_Core.Services;
namespace ADD2E_Core.Models
{
    public class PlayerCharacter : ICharacter
    {
        public int? PlayerID { get; set; } = null;
        public string Name { get; set; }
        public int Level { get; set; } = 1;
        public int HitPoints { get; set; } = 0;
        public int ArmorClass { get; set; } = 10;
        public bool RandomizeStats { get; set; } = false;
        public IRace Race { get; set; }
        public Money CoinPurse { get; set; } = new Money();
        public IClass Class { get; set; }
        public ThacoScore Thaco { get; set; }
        public AbilityScores AbilityScores { get; set; } = new AbilityScores();
        public List<IEquipment> Equipment { get; private set; } = new List<IEquipment>();
        public IWeapon PrimaryWeapon { get; set; }
        public ClassExperienceLevel LevelInfo { get; set; }
        public ClassExperienceLevel NextLevelInfo { get; set; }
        public int Experience { get; set; } = 0;

        public RaceType RaceType { get; set; }
        public ClassType ClassType { get; set; }

        public void CreateCharacter()
        {
            CharacterManager characterManager = new CharacterManager();
            ClassManager classManager = new ClassManager();

            Race = characterManager.SetPlayerRace(RaceType);
            if(characterManager.CanRacePlayClass(Race, ClassType))
            {
                Class = characterManager.setCharacterClass(ClassType);
                LevelInfo = classManager.getExperienceLevels(ClassType, Level);
                NextLevelInfo = classManager.getExperienceLevels(ClassType, Level + 1);
                HitPoints = characterManager.SetHitPoints(Level, Class, AbilityScores);
                if(RandomizeStats)
                {
                    AbilityScores = characterManager.RandomizeAbilityScores(AbilityScores);
                }
                else
                {
                    AbilityScores = characterManager.UpdateAbilityScores(AbilityScores);
                }
            }
            else
            {
                string expMessage = string.Format("{0} cannot be a {1}", Race.ToString(), ClassType.ToString());
                throw new Exception(expMessage);
            }
           
            /*
             * 
             *
             *
            SetupThaco();
            Equipment.Add(PrimaryWeapon);
             */
        }

        /*
      
        #region Thaco and AC
        public void SetupThaco()
        {
            Thaco = new ThacoScore { ClassGroup = Class.ClassGroup, Level = Level, Value = 20 };
        }
        #endregion

        #region Inventory 
        public void AddItem(IEquipment item, int quantity = 1)
        {
            for(int i = 0; i <= quantity - 1; i++)
            {
                Random r = new Random();
                IEquipment thisItem = item;
                thisItem.ItemID = item.Type.ToString() + "_" + r.Next(1, 99999);
                Equipment.Add(thisItem);
            }
        }
        public void RemoveItem(IEquipment item, int quantity = 1)
        {
            // Search to see if it exists
            var searchItem = Equipment.FindAll(x => x.Name == item.Name).ToList();
            if(searchItem.Count() <= quantity) { quantity = searchItem.Count();  }
            for (int i = 0; i <= quantity - 1; i++)
            {
                Equipment.Remove(searchItem[i]);
            }
        }
        #endregion
        */

    }
}
