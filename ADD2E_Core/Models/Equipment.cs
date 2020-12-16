using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Models;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Models
{
    public class Equipment : IEquipment
    {
        public string ItemID { get; set; } = null;
        public EquipmentType Type { get; set; } = EquipmentType.Misc;
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public Money Price { get; set; } = new Money();
        public bool Weareable { get; set; } = false;
        public bool Consumeable { get; set; } = false;

        public void CreateItem()
        {
            Random r = new Random();
            ItemID = Type.ToString() + "_" + r.Next(1, 99999);
        }
    }
}
