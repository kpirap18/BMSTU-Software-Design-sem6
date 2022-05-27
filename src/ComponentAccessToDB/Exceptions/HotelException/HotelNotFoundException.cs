using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class HotelNotFoundException : Exception
    {
        public int HotelID;
        public HotelNotFoundException(int HotelID)
        {
            this.HotelID = HotelID;
        }
    }
}