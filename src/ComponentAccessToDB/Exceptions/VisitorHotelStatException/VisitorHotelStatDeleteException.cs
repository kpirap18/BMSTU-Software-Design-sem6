using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class VisitorHotelStatDeleteException : Exception
    {
        public int visitorid;
        public VisitorHotelStatDeleteException(int visitorid)
        {
            this.visitorid = visitorid;
        }
    }
}