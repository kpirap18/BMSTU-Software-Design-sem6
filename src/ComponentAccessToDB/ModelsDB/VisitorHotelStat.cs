using Microsoft.EntityFrameworkCore;
using System;
namespace DB
{
    [Keyless]
    public class VisitorHotelStat
    {
        public int visitorid { get; set; }
        public string visitor { get; set; }
        public string hotel { get; set; }
        public int stars { get; set; }
    }

    
}
