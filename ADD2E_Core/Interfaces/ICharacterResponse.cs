using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Interfaces
{
    public interface ICharacterResponse
    {
        CharacterResponseTypes ResponseType { get; set; }
    }
}
