using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class AvailabledealNotFoundException : Exception
    {
        public int AvailabledealID;
        public AvailabledealNotFoundException(int AvailabledealID)
        {
            this.AvailabledealID = AvailabledealID;
        }
    }
}

