using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class InterestVisitorUpdateException : Exception
    {
        public int InterestVisitorID;
        public int VisitorID;
        public int HotelID;
        public int Managementid;
        public InterestVisitorUpdateException(int InterestVisitorID,
            int VisitorID,
            int HotelID,
            int Managementid)
        {
            this.InterestVisitorID = InterestVisitorID;
            this.VisitorID = VisitorID;
            this.HotelID = HotelID;
            this.Managementid = Managementid;
        }
    }
}

