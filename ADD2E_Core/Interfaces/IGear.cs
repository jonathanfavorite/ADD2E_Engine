using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Interfaces
{
    public interface IGear : IEquipment
    {
        EquipmentSlot SlotType { get; set; }
        int AC { get; set; }
        int? ACBonus { get; set; }
        ArmorTypeList ArmorType { get; set; }
    }
}
