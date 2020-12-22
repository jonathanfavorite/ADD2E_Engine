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
            // Get the average of all gear
            var ACList = new List<int>();
            var ACBonusFromGear = ArmorClassBonus(equipment);
            int acTotal = 0;
           
            List<EquipmentSlot> GearSlots = new List<EquipmentSlot>
            {
                EquipmentSlot.HEAD,
                EquipmentSlot.SHOULDER,
                EquipmentSlot.CHEST,
                EquipmentSlot.WRIST,
                EquipmentSlot.HANDS,
                EquipmentSlot.LEGS,
                EquipmentSlot.FEET
            };

            int defaultAC = 10;
            int slottedCount = 0;
            foreach (IEquipment item in equipment)
            {
                if (item is IGear g)
                {
                    if (GearSlots.Contains(g.SlotType))
                    {
                        acTotal += g.AC;
                        ++slottedCount;
                    }
                }
            }

            if(slottedCount < GearSlots.Count())
            {
                int findDifference = GearSlots.Count() - slottedCount;
                acTotal += findDifference * defaultAC;
            }

            acTotal -= ACBonusFromGear;

            if(slottedCount > 0)
            {
                double acAverageMath = ((double)acTotal / GearSlots.Count());
                if(acAverageMath > 10) { acAverageMath = defaultAC;  }
                int acAverageFinal = Convert.ToInt32(Math.Round(acAverageMath));
                return acAverageFinal;
            }
            else
            {
                return defaultAC;
            }

        }
        //private static bool 
        private static int ArmorClassBonus(List<IEquipment> equipment)
        {
            int totalBonus = 0;
            foreach(IEquipment item in equipment)
            {
                if (item is IGear g)
                {
                    //totalBonus += g.AC;
                    foreach (StatModifier bonus in item.StatMods)
                    {
                        if (bonus.Modifier == ItemBonusList.AC)
                        {
                            totalBonus += bonus.Value;
                        }
                    }
                }
            }
            return totalBonus;
        }

    }
}
