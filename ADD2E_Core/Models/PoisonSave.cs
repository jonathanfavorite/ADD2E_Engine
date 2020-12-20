using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Models
{
    public class PoisonSave : ISavingThrow
    {
        public SavingThrowType Type { get; set; } = SavingThrowType.Poison;
        public int Value { get; set; } = 10;
    }
}
