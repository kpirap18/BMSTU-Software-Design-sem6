using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentBuisinessLogic;


namespace ComponentAccessToDB
{
    public class FunctionRepository : IFunctionsRepository, IDisposable
    {
        private readonly transfersystemContext db;
        private readonly ILogger<FunctionRepository> _logger;
        public FunctionRepository(transfersystemContext curDb) //, ILogger<FunctionRepository> logger)
        {
            db = curDb;
            //_logger = logger;
        }
        public List<VisitorHotelStat> GetVisitorHotelStat()
        {
            IQueryable<VisitorHotelStatDB> visitors = db.getvisitors();
            List<VisitorHotelStatDB> conv = visitors.ToList();
            List<VisitorHotelStat> final = new List<VisitorHotelStat>();
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
