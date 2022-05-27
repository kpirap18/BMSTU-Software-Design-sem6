using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class VisitorAddException : Exception
    {
        public int VisitorID;
        public int HotelID;
        public int Statistics;
        public string Name;
        public int Age;
        public string Country;
        public int Budget;

        public VisitorAddException(int VisitorID,
            int HotelID,
            int Statistics,
            string Name, 
            int Age, 
            string Country, 
            int Budget)
        {
            this.VisitorID = VisitorID;
            this.HotelID = HotelID;
            this.Statistics = Statistics;
            this.Name = Name;
            this.Age = Age;
            this.Country = Country;
            this.Budget = Budget;
        }
    }
}