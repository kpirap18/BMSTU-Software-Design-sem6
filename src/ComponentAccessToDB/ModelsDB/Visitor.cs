using System;
using System.Collections.Generic;

#nullable disable

namespace ComponentAccessToDB
{
    public partial class Visitor // Player
    {
        public Visitor()
        {
            Availabledeals = new HashSet<Availabledeal>();
            InterestVisitors = new HashSet<InterestVisitor>();
        }

        public int VisitorID { get; set; }
        public int? HotelID { get; set; }
        public int? Statistics { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public int Budget { get; set; }

        public virtual Statistic StatisticsNavigation { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual ICollection<Availabledeal> Availabledeals { get; set; }
        public virtual ICollection<InterestVisitor> InterestVisitors { get; set; }
    }
}
