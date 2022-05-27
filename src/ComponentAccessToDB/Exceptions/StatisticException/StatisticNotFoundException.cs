using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class StatisticNotFoundException : Exception
    {
        public int Statisticsid;
        public StatisticNotFoundException(int Statisticsid,
            int NumberOfTrips,
            int AverageRating)
        {
            this.Statisticsid = Statisticsid;
        }
    }
}
