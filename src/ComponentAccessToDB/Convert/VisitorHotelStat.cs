using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BL;

namespace DB
{
    public partial class VisitorHotelStatConv
    {
        public static DB.VisitorHotelStat BltoDB(BL.VisitorHotelStat a_bl)
        {
            return new DB.VisitorHotelStat
            {
                visitorid = a_bl.visitorid,
                visitor = a_bl.visitor,
                hotel = a_bl.hotel,
                stars = a_bl.stars
            };
        }

        public static BL.VisitorHotelStat DBtoBL(DB.VisitorHotelStat a_bl)
        {
            return new BL.VisitorHotelStat
            (
                vid: a_bl.visitorid,
                v: a_bl.visitor,
                h: a_bl.hotel,
                s: a_bl.stars
            );
        }
    }
}
