using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IManagementRepository : CrudRepository<Management>
    {
        Management FindByAnalytic(int id);
        Management FindByManager(int id);
    }
}
