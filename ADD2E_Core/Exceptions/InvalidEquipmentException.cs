using System;
using System.Collections.Generic;
using System.Text;

namespace ADD2E_Core.Exceptions
{
    public class InvalidEquipmentException : Exception
    {
        public InvalidEquipmentException(string message) : base(message) {}
    }
}
