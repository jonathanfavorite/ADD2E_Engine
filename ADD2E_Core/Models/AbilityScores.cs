using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
namespace ADD2E_Core.Models
{
    public class AbilityScores
    {
        public Strength Strength = new Strength();
        public Dexterity Dexterity = new Dexterity();
        public Constitution Constitution = new Constitution();
        public Intelligence Intelligence = new Intelligence();
        public Wisdom Wisdom = new Wisdom();
        public Charisma Charisma = new Charisma();
    }
}
