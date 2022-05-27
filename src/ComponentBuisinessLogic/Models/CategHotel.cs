using System;
using System.Collections.Generic;

#nullable disable

namespace BL
{
    public class CategHotel
    {
        public CategHotel(int cid = 1, string type = "simple")
        {
            CategoryID = cid;
            TypeCateg = type;
        }

        public int CategoryID { get;  }
        public string TypeCateg { get;  }
    }
}
