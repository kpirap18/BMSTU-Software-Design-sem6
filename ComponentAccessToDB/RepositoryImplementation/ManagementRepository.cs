using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentAccessToDB
{
    public class ManagementRepository : IManagementRepository, IDisposable
    {
        private readonly transfersystemContext db;
        private readonly ILogger<ManagementRepository> _logger;
        public ManagementRepository(transfersystemContext curDb) //, ILogger<ManagementRepository> logger)
        {
            db = curDb;
            // _logger = logger;
        }
        public void Add(Management element)
        {
            try
            {
                element.Managementid = db.Managements.Count() + 1;
                db.Managements.Add(element);
                db.SaveChanges();
                Console.WriteLine("Management {Number} added at {dateTime}", element.Managementid, DateTime.UtcNow);
                // _logger.LogInformation("Management {Number} added at {dateTime}", element.Managementid, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // _logger.LogError(ex.Message);
            }
        }
        public List<Management> GetAll()
        {
            IQueryable<Management> managament = db.Managements;
            return managament.Count() > 0 ? managament.ToList() : null;
        }
        public void Update(Management element)
        {
            try
            {
                db.Managements.Update(element);
                db.SaveChanges();
                Console.WriteLine("Management {Number} updated at {dateTime}", element.Managementid, DateTime.UtcNow);
                // _logger.LogInformation("Management {Number} updated at {dateTime}", element.Managementid, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // _logger.LogError(ex.Message);
            }
        }
        public void Delete(Management element)
        {
            try
            {
                db.Managements.Remove(element);
                db.SaveChanges();
                Console.WriteLine("Management {Number} deleted at {dateTime}", element.Managementid, DateTime.UtcNow);
                // _logger.LogInformation("Management {Number} deleted at {dateTime}", element.Managementid, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // _logger.LogInformation(ex.Message);
            }
        }
        public Management FindByAnalytic(int id)
        {
            IQueryable<Management> management = db.Managements.Where(needed => needed.Analysistid == id);
            return management.Count() > 0 ? management.First() : null;
        }
        public Management FindByManager(int id)
        {
            IQueryable<Management> management = db.Managements.Where(needed => needed.Managerid == id);
            return management.Count() > 0 ? management.First() : null;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
