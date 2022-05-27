using System;
using System.Collections.Generic;

#nullable disable


namespace DB
{
    public class ManagementNotFoundException : Exception
    {
        public int Managementid;
        public ManagementNotFoundException(int Managementid)
        {
            this.Managementid = Managementid;
        }
    }
}

