using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Classes;
namespace ADD2E_Core.Races
{
    public interface IRace
    {
        string Name { get; set; }
        List<EClasses> PlayableClasses { get; set; }
    }
}
