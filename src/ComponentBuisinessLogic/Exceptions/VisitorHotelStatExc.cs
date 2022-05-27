using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class VisitorHotelStatException : Exception
    {
        public VisitorHotelStatException() : base() { }
        public VisitorHotelStatException(string message, Exception innerException) 
            : base(message, innerException) { }

        public VisitorHotelStatException(string message)
            : base(message + "VisitorHotelStat") { }
    }
}
