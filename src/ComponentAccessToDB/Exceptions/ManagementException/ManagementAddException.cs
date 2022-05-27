using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class ManagementAddException : Exception
    {
        public int Managementid;
        public int Analysistid;
        public int Managerid;
        public ManagementAddException(int Managementid,
            int Analysistid,
            int Managerid)
        {
            this.Managementid = Managementid;
            this.Analysistid = Analysistid;
            this.Managerid = Managerid;
        }
    }
}

