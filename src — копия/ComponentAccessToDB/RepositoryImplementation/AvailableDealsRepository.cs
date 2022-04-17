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
    public enum Status
    {
        Confirmed = 0,
        Rejected = 1,
        NotSeen = 2
    }
    public class AvailableDealsRepository : IAvailableDealsRepository, IDisposable
    {
        private readonly transfersystemContext db;
        //private ILogger<AvailableDealsRepository> _logger;

        public AvailableDealsRepository(transfersystemContext curDb) //, ILogger<AvailableDealsRepository> logger)
        {
            db = curDb;
            //_logger = logger;
        }

        public void Add(Availabledeal element)
        {
            try
            {
                AvailabledealDB a = AvailabledealConv.BltoDB(element);
                a.Id = db.Availabledeals.Count() + 1;
                db.Availabledeals.Add(a);
                db.SaveChanges();
                //_logger.LogInformation("Deal {Number} added at {dateTime}", element.Id, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // _logger.LogError(ex.Message);
            }
        }
        public List<Availabledeal> GetLimit(int limit)
        {
            IQueryable<AvailabledealDB> deals = db.Availabledeals.OrderBy(z => z.Id).Where(z => z.Id < limit);
            List<AvailabledealDB> conv = deals.ToList();
            List<Availabledeal> final = new List<Availabledeal>();
            foreach (var m in conv)
            {
                final.Add(AvailabledealConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final : null;
        }
        public void Update(Availabledeal element)
        {
            try
            {
                AvailabledealDB a = AvailabledealConv.BltoDB(element);
                db.Availabledeals.Update(a);
                db.SaveChanges();
                //_logger.LogInformation("Deal {Number} updated at {dateTime}", element.Id, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //_logger.LogError(ex.Message);
            }
        }
        public void Delete(Availabledeal element)
        {
            try
            {
                AvailabledealDB a = AvailabledealConv.BltoDB(element);
                db.Availabledeals.Remove(a);
                db.SaveChanges();
                //_logger.LogInformation("Deal {Number} removed at {dateTime}", element.Id, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //_logger.LogError(ex.Message);
            }
        }
        public Availabledeal GetDealByID(int id)
        {
            AvailabledealDB a = db.Availabledeals.Find(id);
            return AvailabledealConv.DBtoBL(a);
        }
        public void ConfirmDeal(Availabledeal element)
        {
            try
            {
                AvailabledealDB a = AvailabledealConv.BltoDB(element);
                a.Status = (int)Status.Confirmed;
                db.Availabledeals.Update(a);
                db.SaveChanges();
                //_logger.LogInformation("Deal {Number} confirmed at {dateTime}", element.Id, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //_logger.LogError(ex.Message);
            }
        }
        public void RejectDeal(Availabledeal element)
        {
            try
            {
                AvailabledealDB a = AvailabledealConv.BltoDB(element);
                a.Status = (int)Status.Rejected;
                db.Availabledeals.Update(a);
                db.SaveChanges();
                //_logger.LogInformation("Deal {Number} rejected at {dateTime}", element.Id, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //_logger.LogError(ex.Message);
            }
        }
        public List<Availabledeal> GetIncomingDeals(Management element)
        {
            if (element == null)
            {
                return null;
            }
            IQueryable<AvailabledealDB> deals = db.Availabledeals.Where(needed => needed.Tomanagementid == element.Managementid);
            List<AvailabledealDB> conv = deals.ToList();
            List<Availabledeal> final = new List<Availabledeal>();
            foreach (var m in conv)
            {
                final.Add(AvailabledealConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final : null;
        }
        public List<Availabledeal> GetOutgoaingDeals(Management element)
        {
            if (element == null)
            {
                return null;
            }
            IQueryable<AvailabledealDB> deals = db.Availabledeals.Where(needed => needed.Frommanagementid == element.Managementid);
            List<AvailabledealDB> conv = deals.ToList();
            List<Availabledeal> final = new List<Availabledeal>();
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
