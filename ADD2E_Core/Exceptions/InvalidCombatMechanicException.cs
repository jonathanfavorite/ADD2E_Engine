using System;
using System.Collections.Generic;
using System.Text;

namespace ADD2E_Core.Exceptions
{
    public class InvalidCombatMechanicException : Exception
    {
        public InvalidCombatMechanicException(string message)
        {

        }
        public InvalidCombatMechanicException (string message, Exception inner)
        {

        }
    }
}
