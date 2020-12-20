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
using System.Threading;

namespace ADD2E_Core.Services
{
    public class SimulationCombatManager
    {
        private int TurnCount = 0;
        private int CurrentPlayerTurn = 0;
        private int TotalPlayers = 0;
        private Dictionary<int, ICharacter> members = new Dictionary<int, ICharacter>();
        private List<ICharacter> allchars;
        public SimulationCombatManager(List<ICharacter> allChars)
        { 
            allchars = allChars;
            members = RollInitiative(allchars);
            TotalPlayers = members.Count;
        }
        public CombatResponse StartCombat()
        {
            int i = 0;
            
            while (SurvivingPlayers().Item1 > 1)
            {
                TakeTurn();
                //DisplayCombatRealTime();
                Thread.Sleep(100);
                ++i;
            }
            Console.WriteLine("Fight is finished.");
            Console.WriteLine($"{SurvivingPlayers().Item2[0]} Wins");
            // Console.WriteLine(SurvivingPlayers()[0].Name + " is the winner.");
            return new CombatResponse { };
        }

        private CombatResponse TakeTurn()
        {
            
            var atk = DoMeleeAttack();
            if(atk.ResponseType == CombatResponseTypes.KILLED)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("(" + SurvivingPlayers().Item1 + " remain)" + atk.response);
            Console.ForegroundColor = ConsoleColor.White;




            ++CurrentPlayerTurn;
            if (CurrentPlayerTurn >= TotalPlayers)
            {
                CurrentPlayerTurn = 0;
            }
            ++TurnCount;
            return atk;
        }


        private CombatResponse DoMeleeAttack()
        {
            var cResponse = new CombatResponse();
            try
            {
                var victim = SelectRandomPlayer();

                var attackRoll = GetAttackRoll();
                var Damage = GetDamageRoll();

                int victimToHitValue = victim.Thaco.Value - CharacterCombatMaths.CalculateArmorClass(victim.EquippedGear);

                if (attackRoll < victimToHitValue)
                {
                    // Missses
                    cResponse.response = string.Format($"{CurrentPlayer().Name}'s attack misses against {victim.Name}");
                    cResponse.ResponseType = CombatResponseTypes.MISSED;
                }
                else
                {
                    // Hits
                    cResponse.response = string.Format($"{CurrentPlayer().Name} deals {Damage} damage to {victim.Name}");

                    cResponse.ResponseType = CombatResponseTypes.DAMAGED;

                    if (victim.TmpHitPoints - Damage <= 0)
                    {
                        cResponse.response = string.Format($"{CurrentPlayer().Name} kills {victim.Name}");
                        cResponse.ResponseType = CombatResponseTypes.KILLED;
                    }

                    members = DoDamage(victim, Damage);

                }
            }
            catch(InvalidCombatMechanicException ex)
            {
                cResponse.success = false;
                cResponse.response = ex.Message;
            }

            /*
            Console.WriteLine($"-- {CurrentPlayer().Name}'s Turn --");
            Console.WriteLine($" (HP: {CurrentPlayer().TmpHitPoints}/{CurrentPlayer().HitPoints}   AC: {CurrentPlayer().ArmorClass})");
            Console.WriteLine($" Attacking: {victim.Name}");
            Console.WriteLine($" Weapon: {CurrentPlayer().PrimaryWeapon.Name} ({CurrentPlayer().PrimaryWeapon.Damage.Amount}d{CurrentPlayer().PrimaryWeapon.Damage.SidedDie})");
            Console.WriteLine($" Roll: {attackRoll} (need to match or beat {victimToHitValue})");
            Console.WriteLine($" Damage: {Damage}");
            */

            return cResponse;
        }

        private void DisplayCombatRealTime()
        {
            Console.Clear();
            foreach(var character in members.Values)
            {
                if (character.TmpHitPoints < 1)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{character.Name} HP: {character.TmpHitPoints}/{character.HitPoints}");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        private int GetAttackRoll()
        {
            var baseAttackRoll = DiceManager.Roll(1, 21).Total;
            var bonusAttackAdjustment = CharacterCombatMaths.TotalHitAdjustments(CurrentPlayer());
            var attackRoll = baseAttackRoll + bonusAttackAdjustment;
            return attackRoll;
        }
        private int GetDamageRoll()
        {
            var baseDamageRoll = DiceManager.Roll(CurrentPlayer().PrimaryWeapon.Damage.Amount, CurrentPlayer().PrimaryWeapon.Damage.SidedDie).Total;
            var bonusDamageAdjustment = 1;
            var DamageRoll = baseDamageRoll + bonusDamageAdjustment;
            return DamageRoll;

        }
        private Dictionary<int, ICharacter> DoDamage(ICharacter c, int damage)
        {
            foreach(var character in members.Values)
            {
                if(character == c)
                {
                    character.TmpHitPoints -= damage;
                    if(character.TmpHitPoints < 0)
                    {
                        character.TmpHitPoints = 0;
                    }
                }
            }
            return members;
        }
        private ICharacter CurrentPlayer()
        {
            return members.ElementAt(CurrentPlayerTurn).Value;
        }
        private ICharacter SelectRandomPlayer()
        {
            Random r = new Random();
            var notCurrentPlayer = members.Where(x => x.Value.PlayerID != CurrentPlayer().PlayerID && x.Value.TmpHitPoints > 0);
            int count = notCurrentPlayer.Count();
            var randomPlayer = notCurrentPlayer.ElementAt(r.Next(0, count));
            return randomPlayer.Value;
        }
        private Tuple<int, List<string>> SurvivingPlayers()
        {
            var notCurrentPlayer = members.Where(x => x.Value.TmpHitPoints > 0);
            List<string> remainingPlayerIDs = new List<string>();
            for(int i = 0; i <= notCurrentPlayer.Count() - 1; i++)
            {
                remainingPlayerIDs.Add(notCurrentPlayer.ElementAt(i).Value.Name);
            }
            Tuple<int, List<string>> resp = new Tuple<int, List<string>>(notCurrentPlayer.Count(), remainingPlayerIDs);
            return resp;
        }
        private Dictionary<int, ICharacter> RollInitiative(List<ICharacter> allChars)
        {
            Random r = new Random();
            var returnOrder = new Dictionary<int, ICharacter>();
            for(int i = 0; i <= allChars.Count - 1; i++)
            {
                int randNumber = r.Next(1, 1000001);
                if (returnOrder.ContainsKey(randNumber))
                {
                    randNumber = r.Next(1, 1000001);
                }
                returnOrder.Add(randNumber, allChars[i]);
            }
            var orderedList = returnOrder.OrderBy(x => x.Key).ToDictionary(t => t.Key, v => v.Value);
            return orderedList;
        }
        

    }
}
