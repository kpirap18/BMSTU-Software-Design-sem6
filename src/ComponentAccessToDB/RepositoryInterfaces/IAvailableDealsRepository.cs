using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentAccessToDB
{
    public interface IAvailableDealsRepository : CrudRepository<Availabledeal>
    {
        Availabledeal GetDealByID(int id);
        void ConfirmDeal(Availabledeal element);
        void RejectDeal(Availabledeal element);
        List<Availabledeal> GetIncomingDeals(Management element);
        List<Availabledeal> GetOutgoaingDeals(Management element);
    }
}
