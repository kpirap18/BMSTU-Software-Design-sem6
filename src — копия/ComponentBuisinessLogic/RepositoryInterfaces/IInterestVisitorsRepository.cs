using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentBuisinessLogic
{
    public interface IInterestVisitorsRepository : CrudRepository<InterestVisitor> // Desiredplayer
    {
        InterestVisitor GetVisitorByID(int id);
        List<InterestVisitor> GetVisitorsByManagement(Management element);
    }
}
