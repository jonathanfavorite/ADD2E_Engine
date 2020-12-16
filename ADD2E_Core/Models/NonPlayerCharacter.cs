using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
namespace ADD2E_Core.Models
{
    public class NonPlayerCharacter : ICharacter
    {
        public int? PlayerID { get; set; } = null;
        public string Name { get; set; }
        public int Level { get; set; } = 1;
        public int HitPoints { get; set; } = 0;
        public int ArmorClass { get; set; } = 10;
        public bool RandomizeStats { get; set; } = false;

        //public IRace Race { get; set; }
        //public IClass Class { get; set; }
        //public ThacoScore Thaco { get; set; }
        //public AbilityScores AbilityScores { get; set; } = new AbilityScores();
        //public List<IEquipment> Equipment { get; private set; } = new List<IEquipment>();
        //public IWeapon PrimaryWeapon { get; set; }
        //private CharacterRules characterRules = new CharacterRules();
        //private AbilityScoreRules abilityScoreRules = new AbilityScoreRules();
        //public ERaces RaceType { get; set; }
        //public EClasses ClassType { get; set; }

        public void CreateCharacter()
        {

        }
    }
}
