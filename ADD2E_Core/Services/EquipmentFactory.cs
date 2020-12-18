using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
namespace ADD2E_Core.Services
{
    public static class EquipmentFactory
    {
        public static IEquipment CreateItem(IEquipment item)
        {
            item.CreateItem();
            return item;
        }
        public static IGear CreateGear(IGear gear)
        {
            gear.CreateItem();
            return gear;
        }
        public static IWeapon CreateWeapon(IWeapon weapon)
        {
            weapon.CreateItem();
            return weapon;
        }
    }
}
