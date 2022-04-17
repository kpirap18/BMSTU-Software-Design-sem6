using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ComponentBuisinessLogic;

namespace ComponentAccessToDB
{
    [Keyless]
    public class VisitorHotelStatDB 
    {
        public int visitorid { get; set; }
        public string visitor { get; set; }
        public string hotel { get; set; }
        public int stars { get; set; }
    }

    public partial class VisitorHotelStatConv
    {
        public static VisitorHotelStatDB BltoDB(VisitorHotelStat a_bl)
        {
            return new VisitorHotelStatDB
            {
                visitorid = a_bl.visitorid,
                visitor = a_bl.visitor,
                hotel = a_bl.hotel,
                stars = a_bl.stars
            };
        }

        public static VisitorHotelStat DBtoBL(VisitorHotelStatDB a_bl)
        {
            return new VisitorHotelStat
            (
                vid: a_bl.visitorid,
                v: a_bl.visitor,
                h: a_bl.hotel,
                s: a_bl.stars
            );
        }
    }
}
