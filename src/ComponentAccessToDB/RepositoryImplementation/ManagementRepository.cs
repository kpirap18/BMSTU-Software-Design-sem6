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
    public class ManagementRepository : IManagementRepository, IDisposable
    {
        private readonly transfersystemContext db;
        public ManagementRepository(transfersystemContext curDb)
        {
            db = curDb;
        }
        public void Add(BL.Management element)
        {
            DB.Management e = ManagementConv.BltoDB(element);
            try
            {
                e.Managementid = db.Managements.Count() + 1;
                db.Managements.Add(e);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ManagementAddException(e.Managementid, e.Analysistid, e.Managerid);
                Console.WriteLine(ex.Message);
            }
        }
        public List<BL.Management> GetLimit(int limit)
        {
            IQueryable<DB.Management> managament = db.Managements.OrderBy(z => z.Managementid).Where(z => z.Managementid < limit);
            List<DB.Management> conv = managament.ToList();
            List<BL.Management> final = new List<BL.Management>();
            foreach (var m in conv)
            {
                final.Add(ManagementConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final : null;
        }
        public void Update(BL.Management element)
        {
            DB.Management e = ManagementConv.BltoDB(element);
            try
            {
                db.Managements.Update(e);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ManagementUpdateException(e.Managementid, e.Analysistid, e.Managerid);
                Console.WriteLine(ex.Message);
            }
        }
        public void Delete(BL.Management element)
        {
            DB.Management e = ManagementConv.BltoDB(element);
            try
            {
                db.Managements.Remove(e);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ManagementDeleteException(e.Managementid);
                Console.WriteLine(ex.Message);
            }
        }
        public BL.Management FindByAnalytic(int id)
        {
            IQueryable<DB.Management> management = db.Managements.Where(needed => needed.Analysistid == id);
            List<DB.Management> conv = management.ToList();
            List<BL.Management> final = new List<BL.Management>();
            foreach (var m in conv)
            {
                final.Add(ManagementConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final.First() : null;
        }
        public BL.Management FindByManager(int id)
        {
            IQueryable<DB.Management> management = db.Managements.Where(needed => needed.Managerid == id);
            List<DB.Management> conv = management.ToList();
            List<BL.Management> final = new List<BL.Management>();
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
