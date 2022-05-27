using System;
using System.Collections.Generic;
using BL;
#nullable disable

namespace DB
{
    public partial class StatisticConv
    {
        public static DB.Statistic BltoDB(BL.Statistic a_bl)
        {
            return new DB.Statistic
            {
                Statisticsid = a_bl.Statisticsid,
                NumberOfTrips = a_bl.NumberOfTrips,
                AverageRating = a_bl.AverageRating
            };
        }

        public static BL.Statistic DBtoBL(DB.Statistic a_bl)
        {
            return new BL.Statistic
            (
                sid: a_bl.Statisticsid,
                number: a_bl.NumberOfTrips,
                ar: a_bl.AverageRating
            );
        }
    }
}
