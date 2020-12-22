using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Models;
namespace ADD2E_Core.Services
{
    public static class SpellFactory
    {
        public static ISpell CreateSpell(ISpell spell)
        {
            return spell;
        }
    }
}
