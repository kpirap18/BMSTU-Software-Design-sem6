using System;
using System.Collections.Generic;

#nullable disable
namespace DB
{
    public class VisitorDeleteException : Exception
    {
        public int VisitorID;

        public VisitorDeleteException(int VisitorID)
        {
            this.VisitorID = VisitorID;
        }
    }
}