using System;
using System.Collections.Generic;
using ComponentBuisinessLogic;
#nullable disable

namespace ComponentAccessToDB
{
    public partial class InterestVisitorDB // Desiredplayer
    {
        public int Id { get; set; }
        public int VisitorID { get; set; }
        public int HotelID { get; set; }
        public int Managementid { get; set; }

        public virtual ManagementDB Management { get; set; }
        public virtual VisitorDB Visitor { get; set; }
        public virtual HotelDB Hotel { get; set; }
    }

    public partial class InterestVisitorConv
    {
        public static InterestVisitorDB BltoDB(InterestVisitor a_bl)
        {
            return new InterestVisitorDB
            {
                Id = a_bl.Id,
                VisitorID = a_bl.VisitorID,
                HotelID = a_bl.HotelID,
                Managementid = a_bl.Managementid,
                //Management = ManagementConv.BltoDB(a_bl.Management),
                //Visitor = VisitorConv.BltoDB(a_bl.Visitor),
                //Hotel = HotelConv.BltoDB(a_bl.Hotel)
            };
        }

        public static InterestVisitor DBtoBL(InterestVisitorDB a_bl)
        {
            return new InterestVisitor
            (
                id: a_bl.Id,
                vid: a_bl.VisitorID,
                hid: a_bl.HotelID,
                mid: a_bl.Managementid
            );
        }
    }
}

