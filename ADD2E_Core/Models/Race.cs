using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
using ADD2E_Core.Interfaces;
namespace ADD2E_Core.Models
{
    public class Race : IRace
    {
        public string Name { get; set; }
        public List<ClassType> PlayableClasses { get; set; } = new List<ClassType>();
    }
}
