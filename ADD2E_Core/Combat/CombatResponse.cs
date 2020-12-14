using System;
using System.Collections.Generic;
using System.Text;

namespace ADD2E_Core.Combat
{
    public class CombatResponse
    {
        public ECombatResponse responseType { get; set; } = ECombatResponse.INITIALIZED;
        public string responseText { get; set; }
    }
}
