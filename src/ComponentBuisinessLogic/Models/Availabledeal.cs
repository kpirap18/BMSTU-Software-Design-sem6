﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BL
{
    public class Availabledeal
    {
        public Availabledeal(int id = 1, int vid = 1, int tid = 1, int fid = 1, int cost = 1000, int s = 1)
        {
            Id = id;
            VisitorID = vid;
            Tomanagementid = tid;
            Frommanagementid = fid;
            Cost = cost;
            Status = s;
        }

        public int Id { get;  }
        public int VisitorID { get;  }
        public int Tomanagementid { get;  }
        public int Frommanagementid { get;  }
        public int Cost { get;  }
        public int Status { get;  }
    }
}
