﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class VisitorHotelStat 
    {
        public VisitorHotelStat(int vid = 1, string v = "v", string h = "h", int s = 1)
        {
            visitorid = vid;
            visitor = v;
            hotel = h;
            stars = s;
        }
        public int visitorid { get;  }
        public string visitor { get;  }
        public string hotel { get;  }
        public int stars { get;  }
    }
}
