using System;
using System.Collections.Generic;

#nullable disable

namespace ComponentAccessToDB
{
    public partial class Management
    {
        public Management()
        {
            AvailabledealFrommanagements = new HashSet<Availabledeal>();
            AvailabledealTomanagements = new HashSet<Availabledeal>();
            InterestVisitors = new HashSet<InterestVisitor>();
            Hotels = new HashSet<Hotel>();
        }

        public int Managementid { get; set; }
        public int? Analysistid { get; set; }
        public int? Managerid { get; set; }

        public virtual Userinfo Analysist { get; set; }
        public virtual Userinfo Manager { get; set; }
        public virtual ICollection<Availabledeal> AvailabledealFrommanagements { get; set; }
        public virtual ICollection<Availabledeal> AvailabledealTomanagements { get; set; }
        public virtual ICollection<InterestVisitor> InterestVisitors { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
