using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Models
{
    public class SavingThrow : ISavingThrow
    {
        public List<SavingThrowType>ThrowType { get; set; }
        public int Level { get; set; } 
        public int Value { get; set; }
    }
}
