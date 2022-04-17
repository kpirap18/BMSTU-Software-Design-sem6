using System;
using System.Collections.Generic;

#nullable disable

namespace ComponentBuisinessLogic
{
    public partial class Hotel // Team
    {
        public Hotel()
        {
            InterestVisitors = new HashSet<InterestVisitor>();
            Visitors = new HashSet<Visitor>();
        }

        public int HotelID { get; set; }
        public int Managementid { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Cost { get; set; }

        public virtual Management Management { get; set; }
        public virtual ICollection<InterestVisitor> InterestVisitors { get; set; }
        public virtual ICollection<Visitor> Visitors { get; set; }
    }
}
