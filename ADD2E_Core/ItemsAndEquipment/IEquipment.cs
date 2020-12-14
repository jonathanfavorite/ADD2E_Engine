using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Currency;
namespace ADD2E_Core.ItemsAndEquipment
{
    public interface IEquipment
    {
        string ItemID { get; set; }
        EEquipmentType Type { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        Money Price { get; set; }
        bool Weareable { get; set; }
        bool Consumeable { get; set; }
        void CreateItem();
    }
}
