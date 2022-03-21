using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentAccessToDB
{
    public class VisitorRepository : IVisitorRepository, IDisposable
    {
        private readonly transfersystemContext db;
        private readonly ILogger<VisitorRepository>  _logger;
        public VisitorRepository(transfersystemContext curDb) //, ILogger<VisitorRepository> logger)
        {
            db = curDb;
            // _logger = logger;
        }
        public void Add(Visitor element)
        {
            try
            {
                element.VisitorID = db.Visitors.Count() + 1;
                db.Visitors.Add(element);
                db.SaveChanges();
                Console.WriteLine("Visitor {Name} added at {dateTime}", element.Name, DateTime.UtcNow);
                // _logger.LogInformation("Visitor {Name} added at {dateTime}", element.Name, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // _logger.LogError(ex.Message);
            }
        }
        public List<Visitor> GetAll()
        {
            IQueryable<Visitor> visitors = db.Visitors;
            return visitors.Count() > 0 ? visitors.ToList() : null;
        }
        public void Update(Visitor element)
        {
            try
            {
                db.Visitors.Update(element);
                db.SaveChanges();
                Console.WriteLine("Visitor {Name} updated at {dateTime}", element.Name, DateTime.UtcNow);
                // _logger.LogInformation("Visitor {Name} updated at {dateTime}", element.Name, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // _logger.LogError(ex.Message);
            }
        }
        public void Delete(Visitor element)
        {
            try
            {
                db.Visitors.Remove(element);
                db.SaveChanges();
                Console.WriteLine("Visitor {Name} removed at {dateTime}", element.Name, DateTime.UtcNow);
                // _logger.LogInformation("Visitor {Name} removed at {dateTime}", element.Name, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // _logger.LogError(ex.Message);
            }
        }
        public List<Visitor> GetVisitorsByHotel(Hotel element)
        {
            IQueryable<Visitor> visitors = db.Visitors.Where(needed => needed.Hotel.HotelID == element.HotelID);
            return visitors.Count() > 0 ? visitors.ToList() : null;
        }
        public Visitor FindVisitorByID(int id)
        {
            return db.Visitors.Find(id);
        }
        public Visitor FindVisitorByName(string name)
        {
            IQueryable<Visitor> visitors = db.Visitors.Where(needed => needed.Name == name);
            return visitors.Count() > 0 ? visitors.First() : null;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
