using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Races;
using ADD2E_Core.Classes;
using ADD2E_Core.Classes.List;
using ADD2E_Core.Rules;
using ADD2E_Core.Races.List;
using ADD2E_Core.General;
using ADD2E_Core.ItemsAndEquipment;

namespace ADD2E_Core.PlayerCharacter
{
    public class Player
    {
        public Player()
        {
            SetupAbilityScores();
        }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public ERaces RaceType { get; set; }
        public IRace Race { get; set; }
        public EClasses ClassType { get; set; }
        public IClass Class { get; set; }
        public List<IEquipment> Equipment { get; set; } = new List<IEquipment>();
        public AbilityScores AbilityScores { get; set; } = new AbilityScores();
        public int Level { get; set; } = 1;
        private CharacterRules characterRules = new CharacterRules();
        public void CreateCharacter()
        {
            SetPlayerRace();
            setPlayerClass();
        }
        public void SetupAbilityScores()
        {
            
        }

        #region set Race
        private void SetPlayerRace()
        {
            if (RaceType == ERaces.Human)
                Race = SetHuman();
            if (RaceType == ERaces.Elf)
                Race = SetElf();
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
        private void setPlayerClass()
        {
            Class = SetClass();
        }
        private IClass SetClass()
        {
            if (characterRules.CanRacePlayClass(Race, ClassType))
            {
                return new Fighter();
            }
            else
            {
                throw new Exception(string.Format("{0} cannot be a {1}.", Race.Name, ClassType.ToString()));
            }
        }
        #endregion


    }
}
