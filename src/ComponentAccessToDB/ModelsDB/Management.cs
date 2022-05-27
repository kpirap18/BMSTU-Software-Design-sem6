using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class Management
    {
        public int Managementid { get; set; }
        public int Analysistid { get; set; }
        public int Managerid { get; set; }

        public virtual DB.Userinfo Analysist { get; set; }
        public virtual DB.Userinfo Manager { get; set; }
        public virtual ICollection<DB.Availabledeal> AvailabledealFrommanagements { get; set; }
        public virtual ICollection<DB.Availabledeal> AvailabledealTomanagements { get; set; }
        public virtual ICollection<DB.InterestVisitor> InterestVisitors { get; set; }
        public virtual ICollection<DB.Hotel> Hotels { get; set; }
    }

    
}
