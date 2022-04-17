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
    public class StatisticsRepository : IStatisticsRepository, IDisposable
    {
        private readonly transfersystemContext db;
        private readonly ILogger<StatisticsRepository> _logger;
        public StatisticsRepository(transfersystemContext curDb) //, ILogger<StatisticsRepository> logger)
        {
            db = curDb;
            // _logger = logger;
        }
        public void Add(Statistic element)
        {
            try
            {
                StatisticDB st = StatisticConv.BltoDB(element);
                st.Statisticsid = db.Statistics.Count() + 1;
                db.Statistics.Add(st);
                db.SaveChanges();
                //Console.WriteLine("Statistics {Number} added at {dateTime}", element.Statisticsid, DateTime.UtcNow);
                // _logger.LogInformation("Statistics {Number} added at {dateTime}", element.Statisticsid, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // _logger.LogError(ex.Message);
            }
        }
        public List<Statistic> GetAll()
        {
            IQueryable<StatisticDB> stats = db.Statistics;
            List<StatisticDB> conv = stats.ToList();
            List<Statistic> final = new List<Statistic>();
            foreach (var m in conv)
            {
                final.Add(StatisticConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final : null;
        }
        public void Update(Statistic element)
        {
            try
            {
                StatisticDB st = StatisticConv.BltoDB(element);
                db.Statistics.Update(st);
                db.SaveChanges();
                //Console.WriteLine("Statistics {Number} updated at {dateTime}", element.Statisticsid, DateTime.UtcNow);
                // _logger.LogInformation("Statistics {Number} updated at {dateTime}", element.Statisticsid, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // _logger.LogError(ex.Message);
            }
        }
        public void Delete(Statistic element)
        {
            try
            {
                StatisticDB st = StatisticConv.BltoDB(element);
                db.Statistics.Remove(st);
                db.SaveChanges();
                //Console.WriteLine("Statistics {Number} removed at {dateTime}", element.Statisticsid, DateTime.UtcNow);
                // _logger.LogInformation("Statistics {Number} removed at {dateTime}", element.Statisticsid, DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // _logger.LogError(ex.Message);
            }
        }
        public Statistic GetStatisticByID(int id)
        {
            return StatisticConv.DBtoBL(db.Statistics.Find(id));
        }
        public Statistic GetStatisticsByVisitor(Visitor element)
        {
            VisitorDB v = VisitorConv.BltoDB(element);
            IQueryable<StatisticDB> stats = db.Statistics.Where(needed => needed.Visitors.Contains(v));
            List<StatisticDB> conv = stats.ToList();
            List<Statistic> final = new List<Statistic>();
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
