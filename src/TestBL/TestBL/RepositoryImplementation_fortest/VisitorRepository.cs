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
    public class VisitorRepository : IVisitorRepository, IDisposable
    {
        public void Add(Visitor element)
        {
            return;
        }
        public List<Visitor> GetLimit(int limit)
        {
            List<Visitor> a = new List<Visitor>();
            return a;
        }
        public void Update(Visitor element)
        {
            return;
        }
        public void Delete(Visitor element)
        {
            return;
        }
        public List<Visitor> GetVisitorsByHotel(Hotel element)
        {
            List<Visitor> a = new List<Visitor>();
            return a;
        }
        public Visitor FindVisitorByID(int id)
        {
            Visitor a = new Visitor();
            return a;
        }
        public Visitor FindVisitorByName(string name)
        {
            Visitor a = new Visitor();
            return a;
        }
        public void Dispose()
        {
            return;
        }
    }
}
