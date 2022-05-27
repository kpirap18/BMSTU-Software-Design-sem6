using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class UserinfoDeleteException : Exception
    {
        public int UserinfoID;
        public UserinfoDeleteException(int UserinfoID)
        {
            this.UserinfoID = UserinfoID;
        }
    }
}
