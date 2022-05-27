using System;
using System.Collections.Generic;
using BL;
#nullable disable

namespace DB
{
    public partial class ManagementConv
    {
        public static DB.Management BltoDB(BL.Management a_bl)
        {
            return new DB.Management
            {
                Managementid = a_bl.Managementid,
                Analysistid = a_bl.Analysistid,
                Managerid = a_bl.Managerid
            };
        }
        public static BL.Management DBtoBL(DB.Management a_bl)
        {
            return new BL.Management
            (
                mid: a_bl.Managementid,
                aid: a_bl.Analysistid,
                mmid: a_bl.Managerid
            );
        }
    }
}
