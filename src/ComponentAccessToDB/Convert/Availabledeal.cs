using System;
using System.Collections.Generic;
using BL;
#nullable disable

namespace DB
{
    public partial class AvailabledealConv
    {
        public static DB.Availabledeal BltoDB(BL.Availabledeal a_bl)
        {
            return new DB.Availabledeal
            {
                Id = a_bl.Id,
                VisitorID = a_bl.VisitorID,
                Tomanagementid = a_bl.Tomanagementid,
                Frommanagementid = a_bl.Frommanagementid,
                Cost = a_bl.Cost,
                Status = a_bl.Status
            };
        }

        public static BL.Availabledeal DBtoBL(DB.Availabledeal a_bl)
        {
            return new BL.Availabledeal
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
