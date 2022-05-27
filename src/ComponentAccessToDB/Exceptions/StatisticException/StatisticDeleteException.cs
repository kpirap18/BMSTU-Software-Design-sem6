using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class StatisticDeleteException : Exception
    {
        public int Statisticsid;
        public StatisticDeleteException(int Statisticsid)
        {
            this.Statisticsid = Statisticsid;
        }
    }
}
