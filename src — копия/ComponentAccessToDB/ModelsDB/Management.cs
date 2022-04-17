using System;
using System.Collections.Generic;
using ComponentBuisinessLogic;
#nullable disable

namespace ComponentAccessToDB
{
    public partial class ManagementDB
    {
        public int Managementid { get; set; }
        public int Analysistid { get; set; }
        public int Managerid { get; set; }

        public virtual UserinfoDB Analysist { get; set; }
        public virtual UserinfoDB Manager { get; set; }
        public virtual ICollection<AvailabledealDB> AvailabledealFrommanagements { get; set; }
        public virtual ICollection<AvailabledealDB> AvailabledealTomanagements { get; set; }
        public virtual ICollection<InterestVisitorDB> InterestVisitors { get; set; }
        public virtual ICollection<HotelDB> Hotels { get; set; }
    }

    public partial class ManagementConv
    {
        public static ManagementDB BltoDB(Management a_bl)
        {
            return new ManagementDB
            {
                Managementid = a_bl.Managementid,
                Analysistid = a_bl.Analysistid,
                Managerid = a_bl.Managerid
            };
        }
        public static Management DBtoBL(ManagementDB a_bl)
        {
            return new Management
            (
                mid: a_bl.Managementid,
                aid: a_bl.Analysistid,
                mmid: a_bl.Managerid
            );
        }
    }
}
