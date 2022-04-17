using System;
using System.Collections.Generic;
using ComponentBuisinessLogic;
#nullable disable

namespace ComponentAccessToDB
{
    public partial class AvailabledealDB
    {
        public int Id { get; set; }
        public int VisitorID { get; set; }
        public int Tomanagementid { get; set; }
        public int Frommanagementid { get; set; }
        public int Cost { get; set; }
        public int Status { get; set; }

        public virtual ManagementDB Frommanagement { get; set; }
        public virtual VisitorDB Visitor { get; set; }
        public virtual ManagementDB Tomanagement { get; set; }
    }

    public partial class AvailabledealConv
    {
        public static AvailabledealDB BltoDB(Availabledeal a_bl)
        {
            return new AvailabledealDB
            {
                Id = a_bl.Id,
                VisitorID = a_bl.VisitorID,
                Tomanagementid = a_bl.Tomanagementid,
                Frommanagementid = a_bl.Frommanagementid,
                Cost = a_bl.Cost,
                Status = a_bl.Status
            };
        }

        public static Availabledeal DBtoBL(AvailabledealDB a_bl)
        {
            return new Availabledeal
            (
                id: a_bl.Id,
                vid: a_bl.VisitorID,
                tid: a_bl.Tomanagementid,
                fid: a_bl.Frommanagementid,
                cost: a_bl.Cost,
                s: a_bl.Status
            );
        }
    }
}
