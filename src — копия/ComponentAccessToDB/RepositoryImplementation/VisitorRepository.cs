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
                VisitorDB v = VisitorConv.BltoDB(element);
                v.VisitorID = db.Visitors.Count() + 1;
                db.Visitors.Add(v);
                db.SaveChanges();
                // _logger.LogInformation("Visitor {Name} added at {dateTime}", element.Name, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // _logger.LogError(ex.Message);
            }
        }
        public List<Visitor> GetLimit(int limit)
        {
            IQueryable<VisitorDB> visitors = db.Visitors.OrderBy(z => z.VisitorID).Where(z => z.VisitorID < limit);
            List<VisitorDB> conv = visitors.ToList();
            List<Visitor> final = new List<Visitor>();
            foreach (var m in conv)
            {
                final.Add(VisitorConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final : null;
        }
        public void Update(Visitor element)
        {
            try
            {
                VisitorDB v = VisitorConv.BltoDB(element);
                db.Visitors.Update(v);
                db.SaveChanges();
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
                VisitorDB v = VisitorConv.BltoDB(element);
                db.Visitors.Remove(v);
                db.SaveChanges();
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
            IQueryable<VisitorDB> visitors = db.Visitors.Where(needed => needed.Hotel.HotelID == element.HotelID);
            List<VisitorDB> conv = visitors.ToList();
            List<Visitor> final = new List<Visitor>();
            foreach (var m in conv)
            {
                final.Add(VisitorConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final : null;
        }
        public Visitor FindVisitorByID(int id)
        {
            return VisitorConv.DBtoBL(db.Visitors.Find(id));
        }
        public Visitor FindVisitorByName(string name)
        {
            IQueryable<VisitorDB> visitors = db.Visitors.Where(needed => needed.Name == name);
            List<VisitorDB> conv = visitors.ToList();
            List<Visitor> final = new List<Visitor>();
            foreach (var m in conv)
            {
                final.Add(VisitorConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final.First() : null;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
