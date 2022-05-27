using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;


namespace DB
{
    public class FunctionRepository : IFunctionsRepository, IDisposable
    {
        private readonly transfersystemContext db;
        public FunctionRepository(transfersystemContext curDb)
        {
            db = curDb;
        }
        public List<BL.VisitorHotelStat> GetVisitorHotelStat()
        {
            IQueryable<DB.VisitorHotelStat> visitors = db.getvisitors();
            List<DB.VisitorHotelStat> conv = visitors.ToList();
            List<BL.VisitorHotelStat> final = new List<BL.VisitorHotelStat>();
            foreach (var m in conv)
            {
                final.Add(VisitorHotelStatConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final.ToList() : null;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
