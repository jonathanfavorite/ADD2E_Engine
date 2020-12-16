using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Models
{
    public class Human : IHuman
    {
        public string Name { get; set; } = "Human";
        public List<ClassType> PlayableClasses { get; set; } = new List<ClassType>
        {
          ClassType.Fighter,
          ClassType.Priest,
          ClassType.Ranger,
          ClassType.Wizard
        };
    }
}
