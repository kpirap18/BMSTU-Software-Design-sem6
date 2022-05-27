using System;
using System.Collections.Generic;
using BL;
#nullable disable

namespace DB
{
    public partial class VisitorConv
    {
        public static DB.Visitor BltoDB(BL.Visitor a_bl)
        {
            return new DB.Visitor
            {
                VisitorID = a_bl.VisitorID,
                HotelID = a_bl.HotelID,
                Statistics = a_bl.Statistics,
                Name = a_bl.Name,
                Age = a_bl.Age,
                Country = a_bl.Country,
                Budget = a_bl.Budget
            };
        }

        public static BL.Visitor DBtoBL(DB.Visitor a_bl)
        {
            return new BL.Visitor
            (
                vid: a_bl.VisitorID,
                hid: a_bl.HotelID,
                s: a_bl.Statistics,
                name: a_bl.Name,
                age: a_bl.Age,
                country: a_bl.Country,
                b: a_bl.Budget
            );
        }
    }
}
