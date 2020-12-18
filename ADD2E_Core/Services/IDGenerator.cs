using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ADD2E_Core.Services
{
    public static class IDGenerator
    {
        static int nextId;
        public static int nextID()
        {
            Interlocked.Increment(ref nextId);
            return nextId;
        }
    }
}
