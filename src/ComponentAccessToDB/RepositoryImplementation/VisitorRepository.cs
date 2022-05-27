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
    public class VisitorRepository : IVisitorRepository, IDisposable
    {
        private readonly transfersystemContext db;
        public VisitorRepository(transfersystemContext curDb)
        {
            db = curDb;
        }
        public void Add(BL.Visitor element)
        {
            DB.Visitor v = VisitorConv.BltoDB(element);
            try
            {
                v.VisitorID = db.Visitors.Count() + 1;
                db.Visitors.Add(v);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new VisitorAddException(v.VisitorID, v.HotelID, v.Statistics, v.Name, v.Age, v.Country, v.Budget);
                Console.WriteLine(ex.Message);
            }
        }
        public List<BL.Visitor> GetLimit(int limit)
        {
            IQueryable<DB.Visitor> visitors = db.Visitors.OrderBy(z => z.VisitorID).Where(z => z.VisitorID < limit);
            List<DB.Visitor> conv = visitors.ToList();
            List<BL.Visitor> final = new List<BL.Visitor>();
            foreach (var m in conv)
            {
                final.Add(VisitorConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final : null;
        }
        public void Update(BL.Visitor element)
        {
            DB.Visitor v = VisitorConv.BltoDB(element);
            try
            {
                db.Visitors.Update(v);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new VisitorUpdateException(v.VisitorID, v.HotelID, v.Statistics, v.Name, v.Age, v.Country, v.Budget);
                Console.WriteLine(ex.Message);
            }
        }
        public void Delete(BL.Visitor element)
        {
            DB.Visitor v = VisitorConv.BltoDB(element);
            try
            {
                db.Visitors.Remove(v);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new VisitorDeleteException(v.VisitorID);
                Console.WriteLine(ex.Message);
            }
        }
        public List<BL.Visitor> GetVisitorsByHotel(BL.Hotel element)
        {
            IQueryable<DB.Visitor> visitors = db.Visitors.Where(needed => needed.Hotel.HotelID == element.HotelID);
            List<DB.Visitor> conv = visitors.ToList();
            List<BL.Visitor> final = new List<BL.Visitor>();
            foreach (var m in conv)
            {
                final.Add(VisitorConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final : null;
        }
        public BL.Visitor FindVisitorByID(int id)
        {
            DB.Visitor h = db.Visitors.Find(id);
            return h != null ? VisitorConv.DBtoBL(h) : null;
        }
        public BL.Visitor FindVisitorByName(string name)
        {
            IQueryable<DB.Visitor> visitors = db.Visitors.Where(needed => needed.Name == name);
            List<DB.Visitor> conv = visitors.ToList();
            List<BL.Visitor> final = new List<BL.Visitor>();
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
