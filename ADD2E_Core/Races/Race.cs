using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Classes;
namespace ADD2E_Core.Races
{
    public class Race : IRace
    {
        public string Name { get; set; }
        public List<EClasses> PlayableClasses { get; set; } = new List<EClasses>();
    }
}
