using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentBuisinessLogic

{
    public interface IStatisticsRepository : CrudRepository<Statistic>
    {
        Statistic GetStatisticByID(int id);
        Statistic GetStatisticsByVisitor(Visitor element);
    }
}
