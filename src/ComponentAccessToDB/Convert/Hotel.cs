using System;
using System.Collections.Generic;
using BL;
#nullable disable

namespace DB
{
    public partial class HotelConv
    {
        public static DB.Hotel BltoDB(BL.Hotel a_bl)
        {
            return new DB.Hotel
            {
                HotelID = a_bl.HotelID,
                Managementid = a_bl.Managementid,
                Name = a_bl.Name,
                Country = a_bl.Country,
                Cost = a_bl.Cost,
                Stars = a_bl.Stars
            };
        }

        public static BL.Hotel DBtoBL(DB.Hotel a_bl)
        {
            return new BL.Hotel
            (
                hid: a_bl.HotelID,
                mid: a_bl.Managementid,
                name: a_bl.Name,
                country: a_bl.Country,
                cost: a_bl.Cost, 
                stars: a_bl.Stars
            );
        }
    }
}
