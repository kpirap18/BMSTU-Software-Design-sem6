using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                element.Statisticsid = db.Statistics.Count() + 1;
                db.Statistics.Add(element);
                db.SaveChanges();
                Console.WriteLine("Statistics {Number} added at {dateTime}", element.Statisticsid, DateTime.UtcNow);
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
            IQueryable<Statistic> stats = db.Statistics;
            return stats.Count() > 0 ? stats.ToList() : null;
        }
        public void Update(Statistic element)
        {
            try
            {
                db.Statistics.Update(element);
                db.SaveChanges();
                Console.WriteLine("Statistics {Number} updated at {dateTime}", element.Statisticsid, DateTime.UtcNow);
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
                db.Statistics.Remove(element);
                db.SaveChanges();
                Console.WriteLine("Statistics {Number} removed at {dateTime}", element.Statisticsid, DateTime.UtcNow);
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
            return db.Statistics.Find(id);
        }
        public Statistic GetStatisticsByVisitor(Visitor element)
        {

            IQueryable<Statistic> stats = db.Statistics.Where(needed => needed.Visitors.Contains(element));
            return stats.Count() > 0 ? stats.First() : null;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
