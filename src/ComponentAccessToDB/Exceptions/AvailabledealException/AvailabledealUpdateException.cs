using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class AvailabledealUpdateException : Exception
    {
        public int AvailabledealID;
        public int VisitorID;
        public int Tomanagementid;
        public int Frommanagementid;
        public int Cost;
        public int Status;
        public AvailabledealUpdateException(int AvailabledealID,
            int VisitorID,
            int Tomanagementid,
            int Frommanagementid,
            int Cost,
            int Status_)
        {
            this.AvailabledealID = AvailabledealID;
            this.VisitorID = VisitorID;
            this.Tomanagementid = Tomanagementid;
            this.Frommanagementid = Frommanagementid;
            this.Cost = Cost;
            this.Status = Status_;
        }
    }
}

