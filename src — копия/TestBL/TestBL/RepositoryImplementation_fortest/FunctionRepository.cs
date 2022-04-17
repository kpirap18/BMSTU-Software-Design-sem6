using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentBuisinessLogic;

namespace TestBL
{
    public class FunctionRepository : IFunctionsRepository, IDisposable
    {
        public List<VisitorHotelStat> GetVisitorHotelStat()
        {
            List<VisitorHotelStat> a = new List<VisitorHotelStat>();
            return a;
        }
        public void Dispose()
        {
            return;
        }
    }
}
