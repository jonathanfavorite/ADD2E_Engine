using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Models;
namespace ADD2E_Core.Services
{
    public static class CharacterFactory
    {
        public static ICharacter CreateCharacter(PlayerCharacter character)
        {
            character.CreateCharacter();
            return character;
        }
    }
}
