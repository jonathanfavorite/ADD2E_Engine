using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Currency;
namespace ADD2E_Core.ItemsAndEquipment
{
    public class Weapon : IWeapon
    {
        public string Name { get; set; }
        public EWeaponCategory Category { get; set; }
        public Money Price { get; set; } = new Money();
        public int Weight { get; set; }
        public EWeaponAttackType AttackType { get; set; }
        public EWeasponSize Size { get; set; }
        public int SpeedFactor { get; set; }
        public string ItemID { get; set; } = null;
        public EEquipmentType Type { get; set; } = EEquipmentType.Misc;
        public string Description { get; set; } = string.Empty;
        public bool Weareable { get; set; } = false;
        public bool Consumeable { get; set; } = false;

        public bool TwoHanded { get; set; } = false;

        public void CreateItem()
        {
            Random r = new Random();
            ItemID = Type.ToString() + "_" + r.Next(1, 99999);
        }
    }
}
