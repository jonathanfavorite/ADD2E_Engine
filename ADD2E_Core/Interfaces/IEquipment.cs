using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
using ADD2E_Core.Models;
namespace ADD2E_Core.Interfaces
{
    public interface IEquipment
    {
        string ItemID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        EquipmentType EquipmentType { get; set; }
        Money Price { get; set; }
        bool Weareable { get; set; }
        bool Equipped { get; set; }
        bool Consumeable { get; set; }

        void CreateItem();
    }
}
