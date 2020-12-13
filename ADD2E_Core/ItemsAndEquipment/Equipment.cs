using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Currency;

namespace ADD2E_Core.ItemsAndEquipment
{
    public class Equipment : IEquipment
    {
        public EEquipmentType Type { get; set; } = EEquipmentType.Misc;
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public Money Price { get; set; } = new Money();
    }
}
