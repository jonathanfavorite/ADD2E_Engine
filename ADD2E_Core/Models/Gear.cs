using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
using ADD2E_Core.Services;
namespace ADD2E_Core.Models
{
    public class Gear : IGear
    {
        public string ItemID { get; set; } = null;
        public EquipmentType EquipmentType { get; set; } = EquipmentType.Clothing;
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public Money Price { get; set; } = new Money();
        public EquipmentSlot SlotType { get; set; }
        public bool Weareable { get; set; } = true;
        public bool Consumeable { get; set; } = false;
        public bool Equipped { get; set; } = false;
        public int AC { get; set; } = 10;
        public int? ACBonus { get; set; } = null;
        public List<WeaponBonus> WeaponMods { get; set; } = new List<WeaponBonus>();

        public void CreateItem()
        {
            ItemID = "item_" + IDGenerator.nextID();
        }
    }
}
