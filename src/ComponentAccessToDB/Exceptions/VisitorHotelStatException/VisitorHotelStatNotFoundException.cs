using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class VisitorHotelStatNotFoundException : Exception
    {
        public int visitorid;
        public VisitorHotelStatNotFoundException(int visitorid)
        {
            this.visitorid = visitorid;
        }
    }
}