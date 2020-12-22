using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Models;
using ADD2E_Core.Enums;
namespace ADD2E_Core.Models
{
    public class AreaOfEffect
    {
        public string AOEID = "";
        public bool singleTarget = false;
        public AOETypes Type;
        public RulerTypes Ruler;
        public int AOESize { get; set; } = 10;
    }
}
