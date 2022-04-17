using System;
using System.Collections.Generic;
using ComponentBuisinessLogic;
#nullable disable

namespace ComponentAccessToDB
{
    public partial class StatisticDB
    {
        public int Statisticsid { get; set; }
        public int NumberOfTrips { get; set; }
        public int AverageRating { get; set; }

        public virtual ICollection<VisitorDB> Visitors { get; set; }
    }

    public partial class StatisticConv
    {
        public static StatisticDB BltoDB(Statistic a_bl)
        {
            return new StatisticDB
            {
                Statisticsid = a_bl.Statisticsid,
                NumberOfTrips = a_bl.NumberOfTrips,
                AverageRating = a_bl.AverageRating
            };
        }

        public static Statistic DBtoBL(StatisticDB a_bl)
        {
            return new Statistic
            (
                sid: a_bl.Statisticsid,
                number: a_bl.NumberOfTrips,
                ar: a_bl.AverageRating
            );
        }
    }
}
