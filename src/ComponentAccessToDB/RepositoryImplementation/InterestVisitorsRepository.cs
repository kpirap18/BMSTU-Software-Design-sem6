using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                element.Id = db.InterestVisitors.Count() + 1;
                db.InterestVisitors.Add(element);
                db.SaveChanges();
                Console.WriteLine("Desired visitor {Number} added at {dateTime}", element.VisitorID, DateTime.UtcNow);
                // _logger.LogInformation("Desired visitor {Number} added at {dateTime}", element.VisitorID, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // _logger.LogError(ex.Message);
            }
        }
        public List<InterestVisitor> GetAll()
        {
            IQueryable<InterestVisitor> visitors = db.InterestVisitors;
            return visitors.Count() > 0 ? visitors.ToList() : null;
        }
        public void Update(InterestVisitor element)
        {
            try
            {
                db.InterestVisitors.Update(element);
                db.SaveChanges();
                Console.WriteLine("Desired visitor {Number} updated at {dateTime}", element.VisitorID, DateTime.UtcNow);
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
                db.InterestVisitors.Remove(element);
                db.SaveChanges();
                Console.WriteLine("Desired visitor {Number} deleted at {dateTime}", element.VisitorID, DateTime.UtcNow);
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
            return db.InterestVisitors.Find(id);
        }

        public List<InterestVisitor> GetVisitorsByManagement(Management element)
        {
            IQueryable<InterestVisitor> visitors = db.InterestVisitors.Where(needed =>
                needed.Managementid == element.Managementid
            );
            return visitors.Count() > 0 ? visitors.ToList() : null;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
