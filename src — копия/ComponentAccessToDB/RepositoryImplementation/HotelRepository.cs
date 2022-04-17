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
    public class HotelRepository : IHotelRepository, IDisposable
    {
        private readonly transfersystemContext db;
        private readonly ILogger<HotelRepository> _logger;
        public HotelRepository(transfersystemContext curDb) //, ILogger<HotelRepository> logger)
        {
            db = curDb;
            //_logger = logger;
        }
        public void Add(Hotel element)
        {
            try
            {
                HotelDB h = HotelConv.BltoDB(element);
                h.HotelID = db.Hotels.Count() + 1;

                db.Hotels.Add(h);
                db.SaveChanges();
                //_logger.LogInformation("Hotel {Name} added at {dateTime}", element.Name, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // _logger.LogError(ex.Message);
            }
        }
        public List<Hotel> GetLimit(int limit)
        {
            IQueryable<HotelDB> Hotels = db.Hotels.OrderBy(z => z.HotelID).Where(z => z.HotelID < limit);
            List<HotelDB> conv = Hotels.ToList();
            List<Hotel> final = new List<Hotel>();
            foreach (var m in conv)
            {
                final.Add(HotelConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final: null;
        }
        public void Update(Hotel element)
        {
            try
            {
                HotelDB h = HotelConv.BltoDB(element);
                db.Hotels.Update(h);
                db.SaveChanges();
                // _logger.LogInformation("Hotel {Name} updated at {dateTime}", element.Name, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // _logger.LogError(ex.Message);
            }
        }
        public void Delete(Hotel element)
        {
            try
            {
                HotelDB h = HotelConv.BltoDB(element);
                db.Hotels.Remove(h);
                db.SaveChanges();
                // _logger.LogInformation("Hotel {Name} removed at {dateTime}", element.Name, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // _logger.LogError(ex.Message);
            }
        }
        public Hotel FindHotelByID(int id)
        {
            HotelDB h = db.Hotels.Find(id);
            return HotelConv.DBtoBL(h);
        }
        public Hotel FindHotelByName(string name)
        {
            IQueryable<HotelDB> hotels = db.Hotels.Where(needed => needed.Name == name);
            List<HotelDB> conv = hotels.ToList();
            List<Hotel> final = new List<Hotel>();
            foreach (var m in conv)
            {
                final.Add(HotelConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final.First() : null;
        }
        public Hotel FindHotelByVisitor(Visitor visitor)
        {
            VisitorDB v = VisitorConv.BltoDB(visitor);
            IQueryable<HotelDB> hotels = db.Hotels.Where(needed => needed.Visitors.Contains(v));
            List<HotelDB> conv = hotels.ToList();
            List<Hotel> final = new List<Hotel>();
            foreach (var m in conv)
            {
                final.Add(HotelConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final.First() : null;
        }
        public Hotel FindHotelByManagement(int managementID)
        {
            IQueryable<HotelDB> hotels = db.Hotels.Where(needed => needed.Managementid == managementID);
            List<HotelDB> conv = hotels.ToList();
            List<Hotel> final = new List<Hotel>();
            foreach (var m in conv)
            {
                final.Add(HotelConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final.First() : null;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
