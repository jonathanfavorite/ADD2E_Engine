using System;
using System.Collections.Generic;
using System.Text;

namespace ADD2E_Core.Interfaces
{
    public interface ICharacter
    {
        int? PlayerID { get; set; }
        string Name { get; set; }
        int Level { get; set; }
        int HitPoints { get; set; }
        int ArmorClass { get; set; }
        bool RandomizeStats { get; set; }
        void CreateCharacter();
    }
}
