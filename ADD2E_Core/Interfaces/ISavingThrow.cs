﻿using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Interfaces
{
    public interface ISavingThrow
    {
        SavingThrowType Type { get; set; }
        int Value { get; set; }
    }
}
