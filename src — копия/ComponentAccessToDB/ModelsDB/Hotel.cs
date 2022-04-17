using System;
using System.Collections.Generic;
using ComponentBuisinessLogic;
#nullable disable

namespace ComponentAccessToDB
{
    public partial class HotelDB 
    {
        public int HotelID { get; set; }
        public int Managementid { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Cost { get; set; }

        public virtual ManagementDB Management { get; set; }
        public virtual ICollection<InterestVisitorDB> InterestVisitors { get; set; }
        public virtual ICollection<VisitorDB> Visitors { get; set; }
    }

    public partial class HotelConv
    {
        public static HotelDB BltoDB(Hotel a_bl)
        {
            return new HotelDB
            {
                HotelID = a_bl.HotelID,
                Managementid = a_bl.Managementid,
                Name = a_bl.Name,
                Country = a_bl.Country,
                Cost = a_bl.Cost
            };
        }

        public static Hotel DBtoBL(HotelDB a_bl)
        {
            return new Hotel
            (
                hid: a_bl.HotelID,
                mid: a_bl.Managementid,
                name: a_bl.Name,
                country: a_bl.Country,
                cost: a_bl.Cost
            );
        }
    }
}
