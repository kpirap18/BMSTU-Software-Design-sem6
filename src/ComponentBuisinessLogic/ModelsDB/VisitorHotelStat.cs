using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentBuisinessLogic
{
    [Keyless]
    public class VisitorHotelStat // PlayersTeamStat
    {
        public int visitorid { get; set; }
        public string visitor { get; set; }
        public string hotel { get; set; }
        public int stars { get; set; }
    }
}
