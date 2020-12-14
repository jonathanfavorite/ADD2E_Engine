using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Races;
using ADD2E_Core.Classes;
using ADD2E_Core.Classes.List;
using ADD2E_Core.Rules;
using ADD2E_Core.Races.List;
using ADD2E_Core.General;
using ADD2E_Core.General.Dice;
using ADD2E_Core.ItemsAndEquipment;
using ADD2E_Core.Combat;
namespace ADD2E_Core.Characters
{
    public class Character
    {
        #region Setup Base Variables
        public int? PlayerID { get; set; } = null;
        public string Name { get; set; }
        public ERaces RaceType { get; set; }
        public IRace Race { get; set; }
        public EClasses ClassType { get; set; }
        public IClass Class { get; set; }

        public bool RandomizeStats = false;
        public int HitPoints { get; set; } = 0;
        public int ArmorClass { get; set; } = 10;
        public List<IEquipment> Equipment { get; private set; } = new List<IEquipment>();
        public AbilityScores AbilityScores { get; set; } = new AbilityScores();
        public int Level { get; set; } = 1;
        public ThacoScore Thaco { get; set; }

        private CharacterRules characterRules = new CharacterRules();

        private AbilityScoreRules abilityScoreRules = new AbilityScoreRules();
        #endregion
        public Character()
        {

        }

        public void CreateCharacter()
        {
            SetPlayerRace();
            setPlayerClass();
            SetupHitPoints();
            SetupThaco();
            if(RandomizeStats)
            {
                RandomizeAbilityScores();
            }
            else
            {
                UpdateAbilityScores();
            }
        }

        #region HitPoints
        public void SetupHitPoints()
        {
            HitPoints = SetHitPoints();
        }
        public int SetHitPoints()
        {
            int returnHP = 0;
            // Get the class Hit  Die
            if(Level == 1)
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
                        DiceRoll Dice = new DiceRoll();
                        roll = Dice.Roll(1, Class.HitDie).Total + AbilityScores.Constitution.HitPointAdjustment;
                    }
                    else
                    {
                        roll = Class.HitDie;
                    }
                    returnHP += roll;
                }
            }
            return returnHP;
        }
        #endregion

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
                IClass newClass = null;
                switch(ClassType)
                {
                    case EClasses.Fighter:
                        newClass = new Fighter();
                        break;
                }
                return new Fighter();
            }
            else
            {
                throw new Exception(string.Format("{0} cannot be a {1}.", Race.Name, ClassType.ToString()));
            }
        }
        #endregion

        #region Set & Update Ability Scores
        public void RandomizeAbilityScores()
        {
            DiceRoll dr = new DiceRoll();
            AbilityScores.Strength = abilityScoreRules.SetStrength(dr.FourDSixDropTheLowest());
            AbilityScores.Dexterity = abilityScoreRules.SetDexterity(dr.FourDSixDropTheLowest());
            AbilityScores.Constitution = abilityScoreRules.SetConstitution(dr.FourDSixDropTheLowest());
            AbilityScores.Intelligence = abilityScoreRules.SetIntelligence(dr.FourDSixDropTheLowest());
            AbilityScores.Wisdom = abilityScoreRules.SetWisdom(dr.FourDSixDropTheLowest());
            AbilityScores.Charisma = abilityScoreRules.SetCharisma(dr.FourDSixDropTheLowest());
        }
        public void UpdateAbilityScores()
        {
            AbilityScores.Strength = abilityScoreRules.SetStrength(AbilityScores.Strength.Value);
            AbilityScores.Dexterity = abilityScoreRules.SetDexterity(AbilityScores.Dexterity.Value);
            AbilityScores.Constitution = abilityScoreRules.SetConstitution(AbilityScores.Constitution.Value);
            AbilityScores.Intelligence = abilityScoreRules.SetIntelligence(AbilityScores.Intelligence.Value);
            AbilityScores.Wisdom = abilityScoreRules.SetWisdom(AbilityScores.Wisdom.Value);
            AbilityScores.Charisma = abilityScoreRules.SetCharisma(AbilityScores.Charisma.Value);
        }
        #endregion

        #region Thaco and AC
        public void SetupThaco()
        {
            Thaco = new ThacoScore { ClassGroup = Class.ClassGroup, Level = Level, Value = 20 };
        }
        #endregion

        #region Inventory 
        public void AddItem(IEquipment item, int quantity)
        {
            for(int i = 0; i <= quantity - 1; i++)
            {
                Equipment.Add(item);
            }
        }
        #endregion

    }
}
