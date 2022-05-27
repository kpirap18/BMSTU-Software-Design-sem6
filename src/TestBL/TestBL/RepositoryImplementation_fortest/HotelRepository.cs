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
    public class HotelRepository : IHotelRepository, IDisposable
    {
        public void Add(Hotel element)
        {
            return;
        }
        public List<Hotel> GetLimit(int limit)
        {
            List<Hotel> a = new List<Hotel>();
            return a;
        }
        public void Update(Hotel element)
        {
            return;
        }
        public void Delete(Hotel element)
        {
            return;
        }
        public Hotel FindHotelByID(int id)
        {
            Hotel a = new Hotel();
            return a;
        }
        public Hotel FindHotelByName(string name)
        {
            Hotel a = new Hotel();
            return a;
        }
        public Hotel FindHotelByVisitor(Visitor visitor)
        {
            Hotel a = new Hotel();
            return a;
        }
        public Hotel FindHotelByManagement(int managementID)
        {
            Hotel a = new Hotel();
            return a;
        }
        public void Dispose()
        {
            return;
        }
    }
}
