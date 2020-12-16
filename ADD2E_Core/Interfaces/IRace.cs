using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Interfaces
{
    public interface IRace
    {
        string Name { get; set; }
        List<ClassType> PlayableClasses { get; set; }
    }
}
