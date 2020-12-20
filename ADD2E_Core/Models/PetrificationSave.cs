using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Models
{
    public class PetrificationSave
    {
        public SavingThrowType Type { get; set; } = SavingThrowType.Petrification;
        public int Value { get; set; } = 10;
    }
}
