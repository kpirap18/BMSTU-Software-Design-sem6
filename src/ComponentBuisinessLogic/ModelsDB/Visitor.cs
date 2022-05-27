using System;
using System.Collections.Generic;

#nullable disable

namespace ComponentBuisinessLogic
{
    public partial class Visitor // Player
    {
        public Visitor(int vid = 1, int hid = 1, int s = 1, string name = "name", int age = 1, string country = "country", int b = 1)
        {
            VisitorID = vid;
            HotelID = hid;
            Statistics = s;
            Name = name;
            Age = age;
            Country = country;
            Budget = b;
        }

        public int VisitorID { get;  }
        public int HotelID { get;  }
        public int Statistics { get;  }
        public string Name { get;  }
        public int Age { get;  }
        public string Country { get;  }
        public int Budget { get;  }
    }
}
