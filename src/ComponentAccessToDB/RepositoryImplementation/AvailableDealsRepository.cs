using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                element.Id = db.Availabledeals.Count() + 1;
                db.Availabledeals.Add(element);
                db.SaveChanges();
                Console.WriteLine("Deal");
                //_logger.LogInformation("Deal {Number} added at {dateTime}", element.Id, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // _logger.LogError(ex.Message);
            }
        }
        public List<Availabledeal> GetAll()
        {
            IQueryable<Availabledeal> deals = db.Availabledeals;
            return deals.Count() > 0 ? deals.ToList() : null;
        }
        public void Update(Availabledeal element)
        {
            try
            {
                db.Availabledeals.Update(element);
                db.SaveChanges();
                Console.WriteLine("Deal {Number} updated at {dateTime}", element.Id, DateTime.UtcNow);
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
                db.Availabledeals.Remove(element);
                db.SaveChanges();
                Console.WriteLine("Deal {Number} removed at {dateTime}", element.Id, DateTime.UtcNow);
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
            return db.Availabledeals.Find(id);
        }
        public void ConfirmDeal(Availabledeal element)
        {
            try
            {
                element.Status = (int)Status.Confirmed;
                db.Availabledeals.Update(element);
                db.SaveChanges();
                Console.WriteLine("Deal {Number} confirmed at {dateTime}", element.Id, DateTime.UtcNow);
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
                element.Status = (int)Status.Rejected;
                db.Availabledeals.Update(element);
                db.SaveChanges();
                Console.WriteLine("Deal {Number} rejected at {dateTime}", element.Id, DateTime.UtcNow);
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
            IQueryable<Availabledeal> deals = db.Availabledeals.Where(needed => needed.Tomanagementid == element.Managementid);
            return deals != null ? deals.ToList() : null;
        }
        public List<Availabledeal> GetOutgoaingDeals(Management element)
        {
            if (element == null)
            {
                return null;
            }
            IQueryable<Availabledeal> deals = db.Availabledeals.Where(needed => needed.Frommanagementid == element.Managementid);
            return deals != null ? deals.ToList() : null;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
