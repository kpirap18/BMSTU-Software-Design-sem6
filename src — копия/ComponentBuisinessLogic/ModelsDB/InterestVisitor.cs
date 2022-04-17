using System;
using System.Collections.Generic;

#nullable disable

namespace ComponentBuisinessLogic
{
    public partial class InterestVisitor // Desiredplayer
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

        //public virtual Management Management { get;  }
        //public virtual Visitor Visitor { get;  }
        //public virtual Hotel Hotel { get;  }
    }
}
