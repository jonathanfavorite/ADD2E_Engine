using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ADD2E_Core.Models;
using ADD2E_Core.Enums;
using ADD2E_Core.Exceptions;
using ADD2E_Core.Interfaces;
namespace ADD2E_Core.Extensions
{
    public static class CharacterCombatMaths
    {
        public static int TotalHitAdjustments(ICharacter p)
        {
            int hitAdjustments = WeaponHitAdjustments(p);
            int strengthAdjustment = p.AbilityScores.Strength.HitProb;
            int totalBonus = hitAdjustments + strengthAdjustment;
            return totalBonus;
        }
        public static int WeaponHitAdjustments(ICharacter p)
        {
            int totalBonus = 0;
            foreach(IEquipment item in p.EquippedGear)
            {
                foreach(WeaponBonus bonus in item.WeaponMods)
                {
                    if(bonus.Modifier == ItemBonusList.HIT)
                    {
                        totalBonus += bonus.Value;
                    }
                }
            }
            return totalBonus;
        }
    }
}
