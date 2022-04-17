using System;
using System.Collections.Generic;

#nullable disable

namespace ComponentBuisinessLogic
{
    public partial class Hotel // Team
    {
        public Hotel(int hid = 1, int mid = 1, string name = "name", string country = "country", int cost = 1000)
        {
            HotelID = hid;
            Managementid = mid;
            Name = name;
            Country = country;
            Cost = cost;
            //InterestVisitors = new HashSet<InterestVisitor>();
            //Visitors = new HashSet<Visitor>();
        }

        public int HotelID { get;  }
        public int Managementid { get;  }
        public string Name { get;  }
        public string Country { get;  }
        public int Cost { get;  }

        public virtual Management Management { get;  }
        //public virtual ICollection<InterestVisitor> InterestVisitors { get;  }
        //public virtual ICollection<Visitor> Visitors { get;  }
    }
}
