using System;
using System.Collections.Generic;
using System.Text;

namespace ADD2E_Core.Interfaces
{
    public interface IPlayerCharacter : ICharacter
    {
        string OwnerName { get; set; }
    }
}
