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
                foreach(StatModifier bonus in item.StatMods)
                {
                    if(bonus.Modifier == ItemBonusList.HIT)
                    {
                        totalBonus += bonus.Value;
                    }
                }
            }
            return totalBonus;
        }
        public static int CalculateArmorClass(List<IEquipment> equipment)
        {
            var ACList = new List<int>();
            var ACBonusFromGear = ArmorClassBonus(equipment);
            foreach(IEquipment item in equipment)
            {
                if(item is IGear g)
                {
                    ACList.Add(g.AC);
                }
            }
            if (ACList.Count > 0)
            {
                var ordered = ACList.OrderBy(x => x).ToList();
                if (ordered.Count() > 0)
                {
                    return ordered.First() - ACBonusFromGear;
                }
                else
                {
                    return 10;
                }
            }
            else
            {
                return 10;
            }
        }
        private static int ArmorClassBonus(List<IEquipment> equipment)
        {
            int totalBonus = 0;
            foreach(IEquipment item in equipment)
            {
                foreach (StatModifier bonus in item.StatMods)
                {
                    if (bonus.Modifier == ItemBonusList.AC)
                    {
                        totalBonus += bonus.Value;
                    }
                }
            }
            return totalBonus;
        }

    }
}
