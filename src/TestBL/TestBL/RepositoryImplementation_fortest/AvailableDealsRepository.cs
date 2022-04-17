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
    public class AvailableDealsRepository : IAvailableDealsRepository, IDisposable
    {
        public void Add(Availabledeal element)
        {
            return;
        }
        public List<Availabledeal> GetLimit(int limit)
        {
            List<Availabledeal> a = new List<Availabledeal>();
            return a;
        }
        public void Update(Availabledeal element)
        {
            return;
        }
        public void Delete(Availabledeal element)
        {
            return;
        }
        public Availabledeal GetDealByID(int id)
        {
            Availabledeal a = new Availabledeal();
            return a;
        }
        public void ConfirmDeal(Availabledeal element)
        {
            return;
        }
        public void RejectDeal(Availabledeal element)
        {
            return;
        }
        public List<Availabledeal> GetIncomingDeals(Management element)
        {
            List<Availabledeal> a = new List<Availabledeal>();
            return a;
        }
        public List<Availabledeal> GetOutgoaingDeals(Management element)
        {
            List<Availabledeal> a = new List<Availabledeal>();
            return a;
        }
        public void Dispose()
        {
            return;
        }
    }
}
