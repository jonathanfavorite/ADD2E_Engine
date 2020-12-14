using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.PlayerCharacter;
using ADD2E_Core.General.Dice;
namespace ADD2E_Core.Combat
{
    public class CombatManager
    {
        public CombatResponse MeleeCombat(Player player, Player target)
        {
            var cResponse = new CombatResponse();

            int dmgAdjustment = player.AbilityScores.Strength.DamageAdjustment;
            int hitProbAdjustment = player.AbilityScores.Strength.HitProb;

            DiceRoll diceRoller = new DiceRoll();
            int myRoll = diceRoller.RollOnce(20) + hitProbAdjustment;

            int thacoMath = 0;

            return cResponse;
        }
       
    }
}
