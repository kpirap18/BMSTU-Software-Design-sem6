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
    public class InterestVisitorsRepository : IInterestVisitorsRepository, IDisposable
    {
        public void Add(InterestVisitor element)
        {
            return;
        }
        public List<InterestVisitor> GetLimit(int limit)
        {
            List<InterestVisitor> a = new List<InterestVisitor>();
            return a;
        }

        public void Update(InterestVisitor element)
        {
            return;
        }
        public void Delete(InterestVisitor element)
        {
            return;
        }
        public InterestVisitor GetVisitorByID(int id)
        {
            InterestVisitor a = new InterestVisitor();
            return a;
        }

        public List<InterestVisitor> GetVisitorsByManagement(Management element)
        {
            List<InterestVisitor> a = new List<InterestVisitor>();
            return a;
        }
        public void Dispose()
        {
            return;
        }
    }
}
