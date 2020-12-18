using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
using ADD2E_Core.Services;
namespace ADD2E_Core.Models
{
    public class Weapon : IWeapon
    {
        public string Name { get; set; }
        public WeaponCategory Category { get; set; }
        public Money Price { get; set; } = new Money();
        public int Weight { get; set; }
        public WeaponAttackType AttackType { get; set; }
        public WeaponSize Size { get; set; }
        public int SpeedFactor { get; set; }
        public string ItemID { get; set; } = null;
        public EquipmentType EquipmentType { get; set; } = EquipmentType.Misc;
        public EquipmentSlot SlotType { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool Weareable { get; set; } = true;
        public bool Consumeable { get; set; } = false;
        public bool Equipped { get; set; } = false;
        public bool TwoHanded { get; set; } = false;
        public List<WeaponBonus> WeaponMods { get; set; } = new List<WeaponBonus>();
        public WeaponDamage Damage { get; set; } = new WeaponDamage();

        public void CreateItem()
        {
            ItemID = "item_" + IDGenerator.nextID();
        }
    }
}
