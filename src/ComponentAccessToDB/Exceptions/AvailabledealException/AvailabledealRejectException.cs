using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class AvailabledealRejectException : Exception
    {
        public int AvailabledealID;
        public AvailabledealRejectException(int AvailabledealID)
        {
            this.AvailabledealID = AvailabledealID;
        }
    }
}


