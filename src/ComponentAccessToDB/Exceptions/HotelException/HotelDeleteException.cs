using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class HotelDeleteException : Exception
    {
        public int HotelID;
        public HotelDeleteException(int HotelID)
        {
            this.HotelID = HotelID;
        }
    }
}