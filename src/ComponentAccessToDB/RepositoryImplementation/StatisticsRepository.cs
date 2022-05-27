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
    public class StatisticsRepository : IStatisticsRepository, IDisposable
    {
        private readonly transfersystemContext db;
        public StatisticsRepository(transfersystemContext curDb) 
        {
            db = curDb;
        }
        public void Add(BL.Statistic element)
        {
            DB.Statistic st = StatisticConv.BltoDB(element);
            try
            {
                st.Statisticsid = db.Statistics.Count() + 1;
                db.Statistics.Add(st);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new StatisticAddException(st.Statisticsid, st.NumberOfTrips, st.AverageRating);
                Console.WriteLine(ex.Message);
            }
        }
        public List<BL.Statistic> GetLimit(int limit)
        {
            IQueryable<DB.Statistic> stats = db.Statistics.OrderBy(z => z.Statisticsid).Where(z => z.Statisticsid < limit);
            List<DB.Statistic> conv = stats.ToList();
            List<BL.Statistic> final = new List<BL.Statistic>();
            foreach (var m in conv)
            {
                final.Add(StatisticConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final : null;
        }
        public void Update(BL.Statistic element)
        {
            DB.Statistic st = StatisticConv.BltoDB(element);
            try
            {
                db.Statistics.Update(st);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new StatisticUpdateException(st.Statisticsid, st.NumberOfTrips, st.AverageRating);
                Console.WriteLine(ex.Message);
            }
        }
        public void Delete(BL.Statistic element)
        {
            DB.Statistic st = StatisticConv.BltoDB(element);
            try
            {
                db.Statistics.Remove(st);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new StatisticDeleteException(st.Statisticsid);
                Console.WriteLine(ex.Message);
            }
        }
        public BL.Statistic GetStatisticByID(int id)
        {
            return StatisticConv.DBtoBL(db.Statistics.Find(id));
        }
        public BL.Statistic GetStatisticsByVisitor(BL.Visitor element)
        {
            DB.Visitor v = VisitorConv.BltoDB(element);
            IQueryable<DB.Statistic> stats = db.Statistics.Where(needed => needed.Visitors.Contains(v));
            List<DB.Statistic> conv = stats.ToList();
            List<BL.Statistic> final = new List<BL.Statistic>();
            foreach (var m in conv)
            {
                final.Add(StatisticConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final.First() : null;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
