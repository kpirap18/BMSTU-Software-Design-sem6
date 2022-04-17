using System;
using System.Collections.Generic;
using ComponentBuisinessLogic;
#nullable disable

namespace ComponentAccessToDB
{
    public partial class VisitorDB // Player
    {
        public int VisitorID { get; set; }
        public int HotelID { get; set; }
        public int Statistics { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public int Budget { get; set; }

        public virtual StatisticDB StatisticsNavigation { get; set; }
        public virtual HotelDB Hotel { get; set; }
        public virtual ICollection<AvailabledealDB> Availabledeals { get; set; }
        public virtual ICollection<InterestVisitorDB> InterestVisitors { get; set; }
    }

    public partial class VisitorConv
    {
        public static VisitorDB BltoDB(Visitor a_bl)
        {
            return new VisitorDB
            {
                VisitorID = a_bl.VisitorID,
                HotelID = a_bl.HotelID,
                Statistics = a_bl.Statistics,
                Name = a_bl.Name,
                Age = a_bl.Age,
                Country = a_bl.Country,
                Budget = a_bl.Budget,
                //StatisticsNavigation = StatisticConv.BltoDB(a_bl.StatisticsNavigation),
                //Hotel = HotelConv.BltoDB(a_bl.Hotel)
            };
        }

        public static Visitor DBtoBL(VisitorDB a_bl)
        {
            return new Visitor
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
