using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class InterestVisitorDeleteException : Exception
    {
        public int InterestVisitorID;
        public InterestVisitorDeleteException(int InterestVisitorID)
        {
            this.InterestVisitorID = InterestVisitorID;
        }
    }
}

