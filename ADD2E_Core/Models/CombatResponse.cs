using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Models
{
    public class CombatResponse
    {
        public bool success = false;
        public string response = "CombatResponse Initialized";
        public CombatResponseTypes ResponseType = CombatResponseTypes.NULL;
    }
}
