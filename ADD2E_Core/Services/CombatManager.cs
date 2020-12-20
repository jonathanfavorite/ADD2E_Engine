using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ADD2E_Core.Models;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
using ADD2E_Core.Exceptions;
using ADD2E_Core.Extensions;

namespace ADD2E_Core.Services
{
    public static class CombatManager
    {
        private static ICharacter _person;
        private static ICharacter _target;
        private static IWeapon _specificWeapon;
        public static CombatResponse MeleeAttack(ICharacter person, ICharacter target, IWeapon specificWeapon = null)
        {
            CombatResponse resp = new CombatResponse();
            try
            {
                _person = person;
                _target = target;
                if(specificWeapon != null)
                {
                    _specificWeapon = specificWeapon;
                }

                int attackRoll = GetAttackRoll();
                int targetToHitValue = target.Thaco.Value - CharacterCombatMaths.CalculateArmorClass(target.EquippedGear);
                
                if(attackRoll < targetToHitValue)
                {
                    // Attack missed
                    resp.response = string.Format($"{person.Name}'s attack misses against {target.Name}");
                    resp.ResponseType = CombatResponseTypes.MISSED;
                }
                else
                {
                    // Attack Hit
                    int Damage = GetMeleeDamageTotal();
                    resp.response = string.Format($"{person.Name} deals {Damage} damage to {target.Name}");
                    resp.ResponseType = CombatResponseTypes.DAMAGED;
                    if(target.TmpHitPoints <= 0)
                    {
                        resp.response = string.Format($"{person.Name} deals {Damage} and kills {target.Name}");
                        resp.ResponseType = CombatResponseTypes.KILLED;
                    }
                    target = DoDamageToTarget(Damage);
                }
                resp.success = true;
            }
            catch(InvalidCombatMechanicException ex)
            {
                resp.success = false;
                resp.response = ex.Message;
            }
            return resp;
        }
        private static int GetAttackRoll()
        {
            var baseAttackRoll = DiceManager.Roll(1, 21).Total;
            var bonusAttackAdjustment = CharacterCombatMaths.TotalHitAdjustments(_person);
            var attackRoll = baseAttackRoll + bonusAttackAdjustment;
            return attackRoll;
        }
        private static int GetMeleeDamageTotal()
        {
            int baseDamageRoll;
            if(_specificWeapon != null)
            {
                baseDamageRoll = DiceManager.Roll(_person.PrimaryWeapon.Damage.Amount, _specificWeapon.Damage.SidedDie).Total;
            }
            else
            {
                baseDamageRoll = DiceManager.Roll(_person.PrimaryWeapon.Damage.Amount, _person.PrimaryWeapon.Damage.SidedDie).Total;
            }
            var bonusDamageAdjustment = 1;
            var DamageRoll = baseDamageRoll + bonusDamageAdjustment;
            return DamageRoll;
        }
        private static ICharacter DoDamageToTarget(int damage)
        {
            _target.TmpHitPoints -= damage;
            if(_target.TmpHitPoints < 0)
            {
                _target.TmpHitPoints = 0;
            }
            return _target;
        }
        private static Dictionary<int, ICharacter> RollInitiative(List<ICharacter> allCharacters)
        {
            Random r = new Random();
            var returnOrder = new Dictionary<int, ICharacter>();
            for (int i = 0; i <= allCharacters.Count - 1; i++)
            {
                int randNumber = r.Next(1, 1000001);
                if (returnOrder.ContainsKey(randNumber))
                {
                    randNumber = r.Next(1, 1000001);
                }
                returnOrder.Add(randNumber, allCharacters[i]);
            }
            var orderedList = returnOrder.OrderBy(x => x.Key).ToDictionary(t => t.Key, v => v.Value);
            return orderedList;
        }
    }
}
