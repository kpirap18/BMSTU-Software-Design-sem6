using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class StatisticAddException : Exception
    {
        public int Statisticsid;
        public int NumberOfTrips;
        public int AverageRating;
        public StatisticAddException(int Statisticsid,
            int NumberOfTrips,
            int AverageRating)
        {
            this.Statisticsid = Statisticsid;
            this.NumberOfTrips = NumberOfTrips;
            this.AverageRating = AverageRating;
        }
    }
}
