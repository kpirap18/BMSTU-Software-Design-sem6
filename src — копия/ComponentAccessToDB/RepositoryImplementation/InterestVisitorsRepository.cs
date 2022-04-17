using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentBuisinessLogic;

namespace ComponentAccessToDB
{
    public class InterestVisitorsRepository : IInterestVisitorsRepository, IDisposable
    {
        private readonly transfersystemContext db;
        private readonly ILogger<InterestVisitorsRepository> _logger;
        public InterestVisitorsRepository(transfersystemContext curDb) //, ILogger<InterestVisitorsRepository> logger)
        {
            db = curDb;
            // _logger = logger;
        }
        public void Add(InterestVisitor element)
        {
            try
            {
                InterestVisitorDB iv = InterestVisitorConv.BltoDB(element);
                iv.Id = db.InterestVisitors.Count() + 1;
                db.InterestVisitors.Add(iv);
                db.SaveChanges();
                // _logger.LogInformation("Desired visitor {Number} added at {dateTime}", element.VisitorID, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // _logger.LogError(ex.Message);
            }
        }
        public List<InterestVisitor> GetLimit(int limit)
        {
            IQueryable<InterestVisitorDB> visitors = db.InterestVisitors.OrderBy(z => z.Id).Where(z => z.Id < limit);
            List<InterestVisitorDB> conv = visitors.ToList();
            List<InterestVisitor> final = new List<InterestVisitor>();
            foreach (var m in conv)
            {
                final.Add(InterestVisitorConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final : null;
        }
        public void Update(InterestVisitor element)
        {
            try
            {
                InterestVisitorDB iv = InterestVisitorConv.BltoDB(element);
                db.InterestVisitors.Update(iv);
                db.SaveChanges();
                // _logger.LogInformation("Desired visitor {Number} updated at {dateTime}", element.VisitorID, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // _logger.LogError(ex.Message);
            }
        }
        public void Delete(InterestVisitor element)
        {
            try
            {
                InterestVisitorDB iv = InterestVisitorConv.BltoDB(element);
                db.InterestVisitors.Remove(iv);
                db.SaveChanges();
                // _logger.LogInformation("Desired visitor {Number} deleted at {dateTime}", element.VisitorID, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // _logger.LogError(ex.Message);
            }
        }
        public InterestVisitor GetVisitorByID(int id)
        {
            InterestVisitorDB iv = db.InterestVisitors.Find(id);
            if (iv == null)
            {
                return null;
            }
            return InterestVisitorConv.DBtoBL(iv);
        }

        public List<InterestVisitor> GetVisitorsByManagement(Management element)
        {
            IQueryable<InterestVisitorDB> visitors = db.InterestVisitors.Where(n => n.Managementid == element.Managementid);
            List<InterestVisitorDB> conv = visitors.ToList();
            List<InterestVisitor> final = new List<InterestVisitor>();
            foreach (var m in conv)
            {
                final.Add(InterestVisitorConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final : null;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
