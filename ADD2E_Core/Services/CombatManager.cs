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
            int i = 0;
            
            while (SurvivingPlayers() > 1)
            {
                TakeTurn();
                DisplayCombatRealTime();
                Thread.Sleep(100);
                ++i;
            }
            Console.WriteLine("Fight is finished.");
           // Console.WriteLine(SelectRandomPlayer().Name + " is the winner.");
            return new CombatResponse { };
        }
        private CombatResponse TakeTurn()
        {
            
            var atk = MeleeAttack();


            ++CurrentPlayerTurn;
            if (CurrentPlayerTurn >= TotalPlayers)
            {
                CurrentPlayerTurn = 0;
            }
            ++TurnCount;
            return atk;
        }
        private CombatResponse MeleeAttack()
        {
            //Console.WriteLine("CurrentPlayerTurn: " + CurrentPlayerTurn + " (" + CurrentPlayer().Name + ")");
            var victim = SelectRandomPlayer();
            if (victim.TmpHitPoints > 0)
            {
                var attackRoll = GetAttackRoll();
                var Damage = GetDamageRoll();

                bool misses = false;
                int victimToHitValue = victim.Thaco.Value - CharacterCombatMaths.CalculateArmorClass(victim.EquippedGear);

                if (attackRoll < victimToHitValue)
                {

                }
                else
                {
                    misses = false;
                }
                /*
                Console.WriteLine($"-- {CurrentPlayer().Name}'s Turn --");
                Console.WriteLine($" (HP: {CurrentPlayer().TmpHitPoints}/{CurrentPlayer().HitPoints}   AC: {CurrentPlayer().ArmorClass})");
                Console.WriteLine($" Attacking: {victim.Name}");
                Console.WriteLine($" Weapon: {CurrentPlayer().PrimaryWeapon.Name} ({CurrentPlayer().PrimaryWeapon.Damage.Amount}d{CurrentPlayer().PrimaryWeapon.Damage.SidedDie})");
                Console.WriteLine($" Roll: {attackRoll} (need to match or beat {victimToHitValue})");
                Console.WriteLine($" Damage: {Damage}");
                */
                if (misses)
                {
                   // Console.WriteLine($" {CurrentPlayer().Name} rolls a {attackRoll} against {victim.Name} using {CurrentPlayer().PrimaryWeapon.Name}. Misses.");
                }
                else
                {
                    members = DoDamage(victim, Damage);
                    //Console.WriteLine($" {CurrentPlayer().Name} rolls a {attackRoll} against {victim.Name} using {CurrentPlayer().PrimaryWeapon.Name}. Does {Damage} Damage.");
                }

                //Console.WriteLine();
            }
            else
            {
                MeleeAttack();
            }

            return new CombatResponse { };
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
                Console.WriteLine($"{character.Name} HP: {character.TmpHitPoints}");
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
        private int SurvivingPlayers()
        {
            var notCurrentPlayer = members.Where(x => x.Value.TmpHitPoints > 0);
            return notCurrentPlayer.Count();
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
