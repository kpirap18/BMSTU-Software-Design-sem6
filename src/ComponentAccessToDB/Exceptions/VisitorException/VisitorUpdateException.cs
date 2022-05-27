using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class VisitorUpdateException : Exception
    {
        public int VisitorID;
        public int HotelID;
        public int Statistics;
        public string Name;
        public int Age;
        public string Country;
        public int Budget;

        public VisitorUpdateException(int VisitorID,
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