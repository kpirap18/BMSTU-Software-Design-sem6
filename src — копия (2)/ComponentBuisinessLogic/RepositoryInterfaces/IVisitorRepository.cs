using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentBuisinessLogic
{
    public interface IVisitorRepository : CrudRepository<Visitor>
    {
        List<Visitor> GetVisitorsByHotel(Hotel element);
        Visitor FindVisitorByID(int id);
        Visitor FindVisitorByName(string name); 
    }
}
