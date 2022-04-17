using System;
using System.Collections.Generic;

#nullable disable

namespace ComponentBuisinessLogic
{
    public partial class Management
    {
        public Management(int mid = 1, int aid = 1, int mmid = 1)
        {
            Managementid = mid;
            Analysistid = aid;
            Managerid = mmid;
            //AvailabledealFrommanagements = new HashSet<Availabledeal>();
            //AvailabledealTomanagements = new HashSet<Availabledeal>();
            //InterestVisitors = new HashSet<InterestVisitor>();
            //Hotels = new HashSet<Hotel>();
        }

        public int Managementid { get;  }
        public int Analysistid { get;  }
        public int Managerid { get;  }

        //public virtual Userinfo Analysist { get;  }
        //public virtual Userinfo Manager { get;  }
        //public virtual ICollection<Availabledeal> AvailabledealFrommanagements { get;  }
        //public virtual ICollection<Availabledeal> AvailabledealTomanagements { get;  }
        //public virtual ICollection<InterestVisitor> InterestVisitors { get;  }
        //public virtual ICollection<Hotel> Hotels { get;  }
    }
}
