using System;
using System.Collections.Generic;
using BL;
#nullable disable

namespace DB
{
    public partial class InterestVisitorConv
    {
        public static DB.InterestVisitor BltoDB(BL.InterestVisitor a_bl)
        {
            return new DB.InterestVisitor
            {
                Id = a_bl.Id,
                VisitorID = a_bl.VisitorID,
                HotelID = a_bl.HotelID,
                Managementid = a_bl.Managementid
            };
        }

        public static BL.InterestVisitor DBtoBL(DB.InterestVisitor a_bl)
        {
            return new BL.InterestVisitor
            (
                id: a_bl.Id,
                vid: a_bl.VisitorID,
                hid: a_bl.HotelID,
                mid: a_bl.Managementid
            );
        }
    }
}

