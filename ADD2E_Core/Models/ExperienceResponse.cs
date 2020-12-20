using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Models
{
    public class ExperienceResponse : ICharacterResponse
    {
        public CharacterResponseTypes ResponseType { get; set; } = CharacterResponseTypes.ADDED_EXP;
        public int ExperienceTotal { get; set; } = 0;
        public ClassExperienceLevel NewExperienceLevel { get; set; } = null;
        public ClassExperienceLevel NextExperienceLevel { get; set; } = null;

    }
}
