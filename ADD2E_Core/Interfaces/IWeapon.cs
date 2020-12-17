using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Interfaces
{
    public interface IWeapon : IEquipment
    {
        WeaponCategory Category { get; set; }
        int Weight { get; set; }
        WeaponAttackType AttackType { get; set; }
        EquipmentSlot SlotType { get; set; }
        WeaponSize Size { get; set; }
        int SpeedFactor { get; set; }
        bool TwoHanded { get; set; }
    }
}
