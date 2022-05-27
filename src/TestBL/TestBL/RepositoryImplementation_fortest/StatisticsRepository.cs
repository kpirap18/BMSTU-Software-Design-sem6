using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace TestBL
{
    public class StatisticsRepository : IStatisticsRepository, IDisposable
    {
        public void Add(Statistic element)
        {
            return;
        }
        public List<Statistic> GetLimit(int limit)
        {
            List<Statistic> a = new List<Statistic>();
            return a;
        }
        public void Update(Statistic element)
        {
            return;
        }
        public void Delete(Statistic element)
        {
            return;
        }
        public Statistic GetStatisticByID(int id)
        {
            Statistic a = new Statistic();
            return a;
        }
        public Statistic GetStatisticsByVisitor(Visitor element)
        {
            Statistic a = new Statistic();
            return a;
        }
        public void Dispose()
        {
            return;
        }
    }
}
