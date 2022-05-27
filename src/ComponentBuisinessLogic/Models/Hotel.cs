using System;
using System.Collections.Generic;

#nullable disable

namespace BL
{
    public class Hotel
    {
        public Hotel(int hid = 1, int mid = 1, string name = "name", string country = "country", int cost = 1000, int stars = 1)
        {
            HotelID = hid;
            Managementid = mid;
            Name = name;
            Country = country;
            Cost = cost;
            Stars = stars;
        }

        public int HotelID { get;  }
        public int Managementid { get;  }
        public string Name { get;  }
        public string Country { get;  }
        public int Cost { get;  }
        public int Stars { get; }
    }
}
