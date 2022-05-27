using System;
using System.Collections.Generic;

#nullable disable


namespace DB
{
    public class ManagementDeleteException : Exception
    {
        public int Managementid;
        public ManagementDeleteException(int Managementid)
        {
            this.Managementid = Managementid;
        }
    }
}
