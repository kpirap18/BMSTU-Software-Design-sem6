using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class InterestVisitorNotFoundException : Exception
    {
        public int InterestVisitorID;
        public InterestVisitorNotFoundException(int InterestVisitorID)
        {
            this.InterestVisitorID = InterestVisitorID;
        }
    }
}