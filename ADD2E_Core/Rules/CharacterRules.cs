using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Characters;
using ADD2E_Core.Classes;
using ADD2E_Core.Races;
using System.Linq;
namespace ADD2E_Core.Rules
{
    public class CharacterRules : Rules
    {

        public bool CanRacePlayClass(IRace thatRace, EClasses thatClass)
        {
            if (thatRace.PlayableClasses.Contains(thatClass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
        public bool CanRaceBeClass(List<EClasses> thoseClasses, ERaces thatRace)
        {
            if(thoseClasses.Contains(thatRace))
            return false;
        }
        */
    }
}
