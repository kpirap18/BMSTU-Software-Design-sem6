using System;
using System.Collections.Generic;
using BL;
#nullable disable

namespace DB
{
    public partial class CategHotelConv
    {
        public static DB.CategHotel BltoDB(BL.CategHotel a_bl)
        {
            return new DB.CategHotel
            {
                CategoryID = a_bl.CategoryID,
                TypeCateg = a_bl.TypeCateg
            };
        }

        public static BL.CategHotel DBtoBL(DB.CategHotel a_bl)
        {
            return new BL.CategHotel
            (
                cid: a_bl.CategoryID,
                type: a_bl.TypeCateg
            );
        }
    }
}
