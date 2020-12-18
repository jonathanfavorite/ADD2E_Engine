using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Models
{
    public class WeaponBonus
    {
        public ItemBonusList Modifier { get; set; }
        public bool Add { get; set; } = true;
        public int Value { get; set; } = 0;
    }
}
