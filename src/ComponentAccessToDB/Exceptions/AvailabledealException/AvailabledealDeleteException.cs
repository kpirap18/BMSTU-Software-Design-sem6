using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class AvailabledealDeleteException : Exception
    {
        public int AvailabledealID;
        public AvailabledealDeleteException(int AvailabledealID)
        {
            this.AvailabledealID = AvailabledealID;
        }
    }
}

