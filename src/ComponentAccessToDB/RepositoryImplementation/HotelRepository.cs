using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;


namespace DB
{
    public class HotelRepository : IHotelRepository, IDisposable
    {
        private readonly transfersystemContext db;
        public HotelRepository(transfersystemContext curDb) 
        {
            db = curDb;
        }
        public void Add(BL.Hotel element)
        {
            DB.Hotel h = HotelConv.BltoDB(element);
            try
            {
                h.HotelID = db.Hotels.Count() + 1;

                db.Hotels.Add(h);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new HotelAddException(h.HotelID, h.Managementid, h.Cost, h.Name, h.Country);
            }
        }
        public List<BL.Hotel> GetLimit(int limit)
        {
            IQueryable<DB.Hotel> Hotels = db.Hotels.OrderBy(z => z.HotelID).Where(z => z.HotelID < limit);
            List<DB.Hotel> conv = Hotels.ToList();
            List<BL.Hotel> final = new List<BL.Hotel>();
            foreach (var m in conv)
            {
                final.Add(HotelConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final: null;
        }
        public void Update(BL.Hotel element)
        {
            DB.Hotel h = HotelConv.BltoDB(element);
            try
            {
                db.Hotels.Update(h);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new HotelUpdateException(h.HotelID, h.Managementid, h.Cost, h.Name, h.Country);
                Console.WriteLine(ex.Message);
            }
        }
        public void Delete(BL.Hotel element)
        {
            DB.Hotel h = HotelConv.BltoDB(element);
            try
            {
                db.Hotels.Remove(h);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new HotelDeleteException(h.HotelID);
                Console.WriteLine(ex.Message);
            }
        }
        public BL.Hotel FindHotelByID(int id)
        {
            DB.Hotel h = db.Hotels.Find(id);
            return h != null ? HotelConv.DBtoBL(h) : null;
        }
        public BL.Hotel FindHotelByName(string name)
        {
            IQueryable<DB.Hotel> hotels = db.Hotels.Where(needed => needed.Name == name);
            List<DB.Hotel> conv = hotels.ToList();
            List<BL.Hotel> final = new List<BL.Hotel>();
            foreach (var m in conv)
            {
                final.Add(HotelConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final.First() : null;
        }
        public BL.Hotel FindHotelByVisitor(BL.Visitor visitor)
        {
            DB.Visitor v = VisitorConv.BltoDB(visitor);
            IQueryable<DB.Hotel> hotels = db.Hotels.Where(needed => needed.Visitors.Contains(v));
            List<DB.Hotel> conv = hotels.ToList();
            List<BL.Hotel> final = new List<BL.Hotel>();
            foreach (var m in conv)
            {
                final.Add(HotelConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final.First() : null;
        }
        public BL.Hotel FindHotelByManagement(int managementID)
        {
            IQueryable<DB.Hotel> hotels = db.Hotels.Where(needed => needed.Managementid == managementID);
            List<DB.Hotel> conv = hotels.ToList();
            List<BL.Hotel> final = new List<BL.Hotel>();
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
