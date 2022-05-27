using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class VisitorNotFoundException : Exception
    {
        public int VisitorID;

        public VisitorNotFoundException(int VisitorID)
        {
            this.VisitorID = VisitorID;
        }
    }
}