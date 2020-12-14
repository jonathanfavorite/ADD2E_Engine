using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ADD2E_Core.Classes
{
    public enum EClasses
    {
        [EnumMember(Value = "All")]
        All,
        [EnumMember(Value = "Fighter")]
        Fighter,
        [EnumMember(Value = "Paladin")]
        Paladin,
        [EnumMember(Value = "Wizard")]
        Wizard,
        [EnumMember(Value = "Thief")]
        Thief,
        [EnumMember(Value = "Ranger")]
        Ranger,
        [EnumMember(Value = "Priest")]
        Priest
    }
}
