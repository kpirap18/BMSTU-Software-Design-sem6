using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IHotelRepository : CrudRepository<Hotel>
    {
        Hotel FindHotelByID(int id);
        Hotel FindHotelByName(string name);
        Hotel FindHotelByVisitor(Visitor visitor);
        Hotel FindHotelByManagement(int managementID);
    }
}
