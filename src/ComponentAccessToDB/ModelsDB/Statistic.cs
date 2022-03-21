using System;
using System.Collections.Generic;

#nullable disable

namespace ComponentAccessToDB
{
    public partial class Statistic
    {
        public Statistic()
        {
            Visitors = new HashSet<Visitor>();
        }

        public int Statisticsid { get; set; }
        public int NumberOfTrips { get; set; }
        public int AverageRating { get; set; }

        public virtual ICollection<Visitor> Visitors { get; set; }
    }
}
