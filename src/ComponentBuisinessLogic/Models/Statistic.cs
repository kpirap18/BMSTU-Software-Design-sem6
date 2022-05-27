using System;
using System.Collections.Generic;

#nullable disable

namespace BL
{
    public class Statistic
    {
        public Statistic(int sid = 1, int number = 1, int ar = 1)
        {
            Statisticsid = sid;
            NumberOfTrips = number;
            AverageRating = ar;
        }

        public int Statisticsid { get;  }
        public int NumberOfTrips { get;  }
        public int AverageRating { get;  }
    }
}
