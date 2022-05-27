using System;
using System.Collections.Generic;

#nullable disable

namespace BL
{
    public class Management
    {
        public Management(int mid = 1, int aid = 1, int mmid = 1)
        {
            Managementid = mid;
            Analysistid = aid;
            Managerid = mmid;
        }

        public int Managementid { get;  }
        public int Analysistid { get;  }
        public int Managerid { get;  }
    }
}
