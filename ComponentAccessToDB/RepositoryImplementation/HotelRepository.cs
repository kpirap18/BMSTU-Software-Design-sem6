using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                element.HotelID = db.Hotels.Count() + 1;
                db.Hotels.Add(element);
                db.SaveChanges();
                Console.WriteLine("Hotel {Name} added at {dateTime}", element.Name, DateTime.UtcNow);
                //_logger.LogInformation("Hotel {Name} added at {dateTime}", element.Name, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // _logger.LogError(ex.Message);
            }
        }
        public List<Hotel> GetAll()
        {
            IQueryable<Hotel> Hotels = db.Hotels;
            return Hotels.Count() > 0 ? Hotels.ToList() : null;
        }
        public void Update(Hotel element)
        {
            try
            {
                db.Hotels.Update(element);
                db.SaveChanges();
                Console.WriteLine("Hotel {Name} updated at {dateTime}", element.Name, DateTime.UtcNow);
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
                db.Hotels.Remove(element);
                db.SaveChanges();
                Console.WriteLine("Hotel {Name} removed at {dateTime}", element.Name, DateTime.UtcNow);
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
            return db.Hotels.Find(id);
        }
        public Hotel FindHotelByName(string name)
        {
            IQueryable<Hotel> hotels = db.Hotels.Where(needed => needed.Name == name);
            return hotels.Count() > 0 ? hotels.First() : null; 
        }
        public Hotel FindHotelByVisitor(Visitor visitor)
        {
            IQueryable<Hotel> hotels = db.Hotels.Where(needed => needed.Visitors.Contains(visitor));
            return hotels.Count() > 0 ? hotels.ToList().First() : null;
        }
        public Hotel FindHotelByManagement(int managementID)
        {
            IQueryable<Hotel> hotels = db.Hotels.Where(needed => needed.Managementid == managementID);
            return hotels.Count() > 0 ? hotels.ToList().First() : null;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
