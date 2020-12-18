using System;
using System.Collections.Generic;
using System.Text;

namespace ADD2E_Core.Exceptions
{
    public class InvalidCharacterCreationException : Exception
    {
        public InvalidCharacterCreationException() { }
        public InvalidCharacterCreationException(string message) : base(message) { }
    }
}
