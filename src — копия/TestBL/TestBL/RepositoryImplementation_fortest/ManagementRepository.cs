using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentBuisinessLogic;

namespace TestBL
{
    public class ManagementRepository : IManagementRepository, IDisposable
    {
        public void Add(Management element)
        {
            return;
        }
        public List<Management> GetLimit(int limit)
        {
            List<Management> a = new List<Management>();
            return a;
        }
        public void Update(Management element)
        {
            return;
        }
        public void Delete(Management element)
        {
            return;
        }
        public Management FindByAnalytic(int id)
        {
            Management a = new Management();
            return a;
        }
        public Management FindByManager(int id)
        {
            Management a = new Management();
            return a;
        }
        public void Dispose()
        {
            return;
        }
    }
}
