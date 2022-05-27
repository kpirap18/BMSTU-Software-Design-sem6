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
    public class InterestVisitorsRepository : IInterestVisitorsRepository, IDisposable
    {
        private readonly transfersystemContext db;
        public InterestVisitorsRepository(transfersystemContext curDb) 
        {
            db = curDb;
        }
        public void Add(BL.InterestVisitor element)
        {
            DB.InterestVisitor iv = InterestVisitorConv.BltoDB(element);
            try
            {
                iv.Id = db.InterestVisitors.Count() + 1;
                db.InterestVisitors.Add(iv);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InterestVisitorAddException(iv.Id, iv.VisitorID, iv.HotelID, iv.Managementid);
                Console.WriteLine(ex.Message);
            }
        }
        public List<BL.InterestVisitor> GetLimit(int limit)
        {
            IQueryable<DB.InterestVisitor> visitors = db.InterestVisitors.OrderBy(z => z.Id).Where(z => z.Id < limit);
            List<DB.InterestVisitor> conv = visitors.ToList();
            List<BL.InterestVisitor> final = new List<BL.InterestVisitor>();
            foreach (var m in conv)
            {
                final.Add(InterestVisitorConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final : null;
        }
        public void Update(BL.InterestVisitor element)
        {
            DB.InterestVisitor iv = InterestVisitorConv.BltoDB(element);
            try
            {
                db.InterestVisitors.Update(iv);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InterestVisitorUpdateException(iv.Id, iv.VisitorID, iv.HotelID, iv.Managementid);
                Console.WriteLine(ex.Message);
            }
        }
        public void Delete(BL.InterestVisitor element)
        {
            DB.InterestVisitor iv = InterestVisitorConv.BltoDB(element);
            try
            {
                db.InterestVisitors.Remove(iv);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InterestVisitorDeleteException(iv.Id);

                Console.WriteLine(ex.Message);
            }
        }
        public BL.InterestVisitor GetVisitorByID(int id)
        {
            DB.InterestVisitor iv = db.InterestVisitors.Find(id);
            if (iv == null)
            {
                return null;
            }
            return InterestVisitorConv.DBtoBL(iv);
        }

        public List<BL.InterestVisitor> GetVisitorsByManagement(BL.Management element)
        {
            IQueryable<DB.InterestVisitor> visitors = db.InterestVisitors.Where(n => n.Managementid == element.Managementid);
            List<DB.InterestVisitor> conv = visitors.ToList();
            List<BL.InterestVisitor> final = new List<BL.InterestVisitor>();
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
