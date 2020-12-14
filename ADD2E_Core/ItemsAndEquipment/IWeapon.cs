using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Currency;
namespace ADD2E_Core.ItemsAndEquipment
{
    public interface IWeapon : IEquipment
    {
        EWeaponCategory Category { get; set; }
        int Weight { get; set; }
        EWeaponAttackType AttackType { get; set; }
        EWeasponSize Size { get; set; }
        int SpeedFactor { get; set; }
        bool TwoHanded { get; set; }

    }
}
