using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class VisitorHotelStatAddException : Exception
    {
        public int visitorid;
        public string visitor;
        public string hotel;
        public int stars;

        public VisitorHotelStatAddException(int visitorid,
            string visitor,
            string hotel,
            int stars)
        {
            this.visitorid = visitorid;
            this.visitor = visitor;
            this.hotel = hotel;
            this.stars = stars;
        }
    }
}