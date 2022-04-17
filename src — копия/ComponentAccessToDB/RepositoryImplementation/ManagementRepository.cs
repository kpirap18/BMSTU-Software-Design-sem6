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
                ManagementDB e = ManagementConv.BltoDB(element);
                e.Managementid = db.Managements.Count() + 1;
                db.Managements.Add(e);
                db.SaveChanges();
                // _logger.LogInformation("Management {Number} added at {dateTime}", element.Managementid, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // _logger.LogError(ex.Message);
            }
        }
        public List<Management> GetLimit(int limit)
        {
            IQueryable<ManagementDB> managament = db.Managements.OrderBy(z => z.Managementid).Where(z => z.Managementid < limit);
            List<ManagementDB> conv = managament.ToList();
            List<Management> final = new List<Management>();
            foreach (var m in conv)
            {
                final.Add(ManagementConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final : null;
        }
        public void Update(Management element)
        {
            try
            {
                ManagementDB e = ManagementConv.BltoDB(element);
                db.Managements.Update(e);
                db.SaveChanges();
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
                ManagementDB e = ManagementConv.BltoDB(element);
                db.Managements.Remove(e);
                db.SaveChanges();
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
            IQueryable<ManagementDB> management = db.Managements.Where(needed => needed.Analysistid == id);
            List<ManagementDB> conv = management.ToList();
            List<Management> final = new List<Management>();
            foreach (var m in conv)
            {
                final.Add(ManagementConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final.First() : null;
        }
        public Management FindByManager(int id)
        {
            IQueryable<ManagementDB> management = db.Managements.Where(needed => needed.Managerid == id);
            List<ManagementDB> conv = management.ToList();
            List<Management> final = new List<Management>();
            foreach (var m in conv)
            {
                final.Add(ManagementConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final.First() : null;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
