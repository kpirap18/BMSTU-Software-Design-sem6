using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class UserinfoNotFoundException : Exception
    {
        public int UserinfoID;
        public UserinfoNotFoundException(int UserinfoID)
        {
            this.UserinfoID = UserinfoID;
        }
    }
}
