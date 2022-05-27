using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class Statistic
    {
        public int Statisticsid { get; set; }
        public int NumberOfTrips { get; set; }
        public int AverageRating { get; set; }

        public virtual ICollection<DB.Visitor> Visitors { get; set; }
    }

    
}
