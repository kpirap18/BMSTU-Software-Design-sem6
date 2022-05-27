using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class HotelUpdateException : Exception
    {
        public int HotelID;
        public int Managementid;
        public int Cost;
        public string Name;
        public string Country;
        public HotelUpdateException(int HotelID,
            int Managementid,
            int Cost,
            string Name,
            string Country)
        {
            this.HotelID = HotelID;
            this.Managementid = Managementid;
            this.Cost = Cost;
            this.Name = Name;
            this.Country = Country;
        }
    }
}