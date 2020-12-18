using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ADD2E_Core.Models;
using ADD2E_Core.Enums;
using ADD2E_Core.Exceptions;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Extensions;
namespace ADD2E_Core.Services
{
    public class CombatManager
    {
        private int TurnCount = 0;
        private int CurrentPlayerTurn = 0;
        private int TotalPlayers = 0;
        private Dictionary<int, ICharacter> members = new Dictionary<int, ICharacter>();
        private List<ICharacter> allchars;
        public CombatManager(List<ICharacter> allChars)
        { 
            allchars = allChars;
            members = RollInitiative(allchars);
            TotalPlayers = members.Count;
        }
        public CombatResponse StartCombat()
        {
            for (int i = 0; i < 10; i++)
            {
                TakeTurn();
            }
            return new CombatResponse { };
        }
        private CombatResponse TakeTurn()
        {
            var atk = Attack();


            ++CurrentPlayerTurn;
            if (CurrentPlayerTurn >= TotalPlayers)
            {
                CurrentPlayerTurn = 0;
            }
            ++TurnCount;
            return atk;
        }
        private CombatResponse Attack()
        {
            //Console.WriteLine("CurrentPlayerTurn: " + CurrentPlayerTurn + " (" + CurrentPlayer().Name + ")");
            var currentPlayer = CurrentPlayer();
            var victim = SelectRandomPlayer();

            //var weaponDamageRoll = DiceManager.Roll(currentPlayer.PrimaryWeapon.Damage.Amount, currentPlayer.PrimaryWeapon.Damage.SidedDie).Total;
            var baseAttackRoll = DiceManager.Roll(1, 21).Total;
            var bonusAttackAdjustment = CharacterCombatMaths.TotalHitAdjustments(CurrentPlayer());
            var attackRoll = baseAttackRoll + bonusAttackAdjustment;

            Console.WriteLine($"-- {CurrentPlayer().Name}'s Turn --");
            Console.WriteLine($" Attacking: {victim.Name}");
            Console.WriteLine($" Weapon: {currentPlayer.PrimaryWeapon.Name} ({currentPlayer.PrimaryWeapon.Damage.Amount}d{currentPlayer.PrimaryWeapon.Damage.SidedDie})");
            Console.WriteLine($" Roll: {attackRoll}");
            Console.WriteLine($" Base Roll: ({baseAttackRoll})");
            Console.WriteLine($" Adjustments: {bonusAttackAdjustment}");
            //Console.WriteLine($"{currentPlayer.Name} rolls a {attackRoll} against {victim.Name} using {currentPlayer.PrimaryWeapon.Name}: {attackRoll} damage. {} {}");
            Console.WriteLine();
            return new CombatResponse { };
        }
        private ICharacter CurrentPlayer()
        {
            return members.ElementAt(CurrentPlayerTurn).Value;
        }
        private ICharacter SelectRandomPlayer()
        {
            Random r = new Random();
            var notCurrentPlayer = members.Where(x => x.Value.PlayerID != CurrentPlayer().PlayerID);
            int count = notCurrentPlayer.Count();
            var randomPlayer = notCurrentPlayer.ElementAt(r.Next(0, count));
            return randomPlayer.Value;
        }
        private Dictionary<int, ICharacter> RollInitiative(List<ICharacter> allChars)
        {
            Random r = new Random();
            var returnOrder = new Dictionary<int, ICharacter>();
            for(int i = 0; i <= allChars.Count - 1; i++)
            {
                int randNumber = r.Next(1, 101);
                if (returnOrder.ContainsKey(randNumber))
                {
                    randNumber = r.Next(1, 101);
                }
                returnOrder.Add(randNumber, allChars[i]);
            }
            var orderedList = returnOrder.OrderBy(x => x.Key).ToDictionary(t => t.Key, v => v.Value);
            return orderedList;
        }
        

    }
}
