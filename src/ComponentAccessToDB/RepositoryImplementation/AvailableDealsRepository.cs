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
    public enum Status
    {
        Confirmed = 0,
        Rejected = 1,
        NotSeen = 2
    }
    public class AvailableDealsRepository : IAvailableDealsRepository, IDisposable
    {
        private readonly transfersystemContext db;

        public AvailableDealsRepository(transfersystemContext curDb) 
        {
            db = curDb;
        }

        public void Add(BL.Availabledeal element)
        {
            DB.Availabledeal a = AvailabledealConv.BltoDB(element);
            try
            {
                a.Id = db.Availabledeals.Count() + 1;
                db.Availabledeals.Add(a);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AvailabledealAddException(a.Id, a.VisitorID, a.Tomanagementid, 
                                                    a.Frommanagementid, a.Cost, a.Status);
            }
        }
        public List<BL.Availabledeal> GetLimit(int limit)
        {
            IQueryable<DB.Availabledeal> deals = db.Availabledeals.OrderBy(z => z.Id).Where(z => z.Id < limit);
            List<DB.Availabledeal> conv = deals.ToList();
            List<BL.Availabledeal> final = new List<BL.Availabledeal>();
            foreach (var m in conv)
            {
                final.Add(AvailabledealConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final : null;
        }
        public void Update(BL.Availabledeal element)
        {
            DB.Availabledeal a = AvailabledealConv.BltoDB(element);
            try
            {
                db.Availabledeals.Update(a);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AvailabledealUpdateException(a.Id, a.VisitorID, a.Tomanagementid,
                                                    a.Frommanagementid, a.Cost, a.Status);

            }
        }
        public void Delete(BL.Availabledeal element)
        {
            DB.Availabledeal a = AvailabledealConv.BltoDB(element);
            try
            {
                db.Availabledeals.Remove(a);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AvailabledealDeleteException(a.Id);

            }
        }
        public BL.Availabledeal GetDealByID(int id)
        {
            DB.Availabledeal a = db.Availabledeals.Find(id);
            return AvailabledealConv.DBtoBL(a);
        }
        public void ConfirmDeal(BL.Availabledeal element)
        {
            DB.Availabledeal a = AvailabledealConv.BltoDB(element);
            try
            {
                a.Status = (int)Status.Confirmed;
                db.Availabledeals.Update(a);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AvailabledealNotFoundException(a.Id);

            }
        }
        public void RejectDeal(BL.Availabledeal element)
        {
            DB.Availabledeal a = AvailabledealConv.BltoDB(element);
            try
            {
                a.Status = (int)Status.Rejected;
                db.Availabledeals.Update(a);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AvailabledealRejectException(a.Id);

            }
        }
        public List<BL.Availabledeal> GetIncomingDeals(BL.Management element)
        {
            if (element == null)
            {
                return null;
            }
            IQueryable<DB.Availabledeal> deals = db.Availabledeals.Where(needed => needed.Tomanagementid == element.Managementid);
            List<DB.Availabledeal> conv = deals.ToList();
            List<BL.Availabledeal> final = new List<BL.Availabledeal>();
            foreach (var m in conv)
            {
                final.Add(AvailabledealConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final : null;
        }
        public List<BL.Availabledeal> GetOutgoaingDeals(BL.Management element)
        {
            if (element == null)
            {
                return null;
            }
            IQueryable<DB.Availabledeal> deals = db.Availabledeals.Where(needed => needed.Frommanagementid == element.Managementid);
            List<DB.Availabledeal> conv = deals.ToList();
            List<BL.Availabledeal> final = new List<BL.Availabledeal>();
            foreach (var m in conv)
            {
                final.Add(AvailabledealConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final : null;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
