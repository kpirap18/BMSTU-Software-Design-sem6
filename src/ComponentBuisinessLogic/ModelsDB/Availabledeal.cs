using System;
using System.Collections.Generic;

#nullable disable

namespace ComponentBuisinessLogic
{
    public partial class Availabledeal
    {
        public int Id { get; set; }
        public int VisitorID { get; set; }
        public int Tomanagementid { get; set; }
        public int Frommanagementid { get; set; }
        public int Cost { get; set; }
        public int Status { get; set; }

        public virtual Management Frommanagement { get; set; }
        public virtual Visitor Visitor { get; set; }
        public virtual Management Tomanagement { get; set; }
    }
}
