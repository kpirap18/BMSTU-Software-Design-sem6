using System;
using System.Collections.Generic;

#nullable disable

namespace BL
{
    public class InterestVisitor
    {
        public InterestVisitor(int id = 1, int vid = 1, int hid = 1, int mid = 1)
        {
            Id = id;
            VisitorID = vid;
            HotelID = hid;
            Managementid = mid;
        }

        public int Id { get;  }
        public int VisitorID { get;  }
        public int HotelID { get;  }
        public int Managementid { get;  }
    }
}
