using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Models;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;

namespace ADD2E_Core.Services
{
    public class UITestingManager
    {
        public void GetTypeAndDisplayString(object o, string displayName = "")
        {
            Console.WriteLine($"({o.GetType()}) {displayName}");
        }

        public void ShowAbilityScores(PlayerCharacter p)
        {
            Console.WriteLine($"-- Ability Scores --");
            Console.WriteLine($"Strength:     {p.AbilityScores.Strength.Value} ({AbilityAdj(p.AbilityScores.Strength.HitProb)})");
            Console.WriteLine($"Dexterity:    {p.AbilityScores.Dexterity.Value} ({AbilityAdj(p.AbilityScores.Dexterity.ReactionAdjustment)})");
            Console.WriteLine($"Constitution: {p.AbilityScores.Constitution.Value} ({AbilityAdj(p.AbilityScores.Constitution.HitPointAdjustment)})");
            Console.WriteLine($"Intelligence: {p.AbilityScores.Strength.Value}");
            Console.WriteLine($"Widsom:       {p.AbilityScores.Wisdom.Value} ({AbilityAdj(p.AbilityScores.Wisdom.MagicalDefenceAdjustment)})");
            Console.WriteLine($"Charisma:     {p.AbilityScores.Charisma.Value} ({AbilityAdj(p.AbilityScores.Charisma.ReactionAdjustment)})");
        }
        private string AbilityAdj(int adjustment)
        {
            string returnVal = adjustment.ToString();
            if (!adjustment.ToString().Contains("-"))
            {
                if (adjustment != 0)
                {
                    returnVal = "+" + adjustment.ToString();
                }
            }
            return returnVal;
        }



    }
}
