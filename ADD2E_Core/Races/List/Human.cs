using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Classes;
namespace ADD2E_Core.Races.List
{
    public class Human : IHuman
    {
        public string Name { get; set; } = "Human";
        public List<EClasses> PlayableClasses { get; set; } = new List<EClasses>
        { 
          EClasses.Fighter,
          EClasses.Priest,
          EClasses.Ranger,
          EClasses.Wizard
        };
    }
}
