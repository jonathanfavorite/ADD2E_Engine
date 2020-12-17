using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
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
        public void CreateItem()
        {
            Random r = new Random();
            ItemID = EquipmentType.ToString() + "_" + r.Next(1, 99999);
        }
    }
}
