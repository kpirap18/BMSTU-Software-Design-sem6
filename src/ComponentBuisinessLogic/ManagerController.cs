using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentAccessToDB;
using Microsoft.Extensions.Logging;

namespace ComponentBuisinessLogic
{
    public class ManagerController : UserController
    {
        AvailableDealsRepository dealsRepository;
        public ManagerController(Userinfo user, 
                                 FunctionRepository funcRep, 
                                 AvailableDealsRepository dealsRep, 
                                 VisitorRepository visitorRep, 
                                 HotelRepository hotelRep, 
                                 ManagementRepository managementRep,
                                 InterestVisitorsRepository interestVisitorRep,
                                 StatisticsRepository statRep) :
            base(user, funcRep, visitorRep, hotelRep, managementRep, interestVisitorRep, statRep)
        {
            dealsRepository = dealsRep;
        }
        public List<InterestVisitor> GetAllInterestVisitors()
        {
            Management management = managementRepository.FindByManager(_user.Id);
            if (management != null)
            {
                return interestVisitors.GetVisitorsByManagement(management);
            }
            return null;
        }
        public bool RequestVisitor(int visitorID, int cost)
        {
            Visitor visitor = visitorRepository.FindVisitorByID(visitorID);
            if (visitor == null)
            {
                return false;
            }
            Hotel hotel = hotelRepository.FindHotelByVisitor(visitor);
            if (hotel == null)
            {
                return false;
            }
            Management management = managementRepository.FindByManager(_user.Id);
            if (management == null)
            {
                return false;
            }
            Availabledeal deal = new Availabledeal { VisitorID = visitorID, Tomanagementid = hotel.Managementid, Frommanagementid = management.Managementid, Cost = cost, Status = (int)Status.NotSeen };
            dealsRepository.Add(deal);
            return true;
        }
        public bool ConfirmDeal(int dealID)
        {
            Availabledeal deal = dealsRepository.GetDealByID(dealID);
            if (deal == null)
            {
                return false;
            }
            Management management = managementRepository.FindByManager(_user.Id);
            if (management == null || deal.Tomanagementid != management.Managementid)
            {
                return false;
            }
            Hotel hotel = hotelRepository.FindHotelByManagement((int)management.Managementid);
            if (hotel == null)
            {
                return false;
            }
            if (deal.Cost > hotel.Cost)
            {
                return false;
            }
            dealsRepository.ConfirmDeal(deal);
            return true;
        }
        public bool RejectDeal(int dealID)
        {
            Availabledeal deal = dealsRepository.GetDealByID(dealID);
            if (deal == null)
            {
                return false;
            }
            Management management = managementRepository.FindByManager(_user.Id);
            if (management == null || deal.Tomanagementid != management.Managementid)
            {
                return false;
            }
            dealsRepository.RejectDeal(deal);
            return true;
        }
        public List<Availabledeal> GetIncomingDeals()
        {
            Management management = managementRepository.FindByManager(_user.Id);
            if (management == null)
            {
                return null;
            }
            return dealsRepository.GetIncomingDeals(management);
        }
        public List<Availabledeal> GetOutgoaingDeals()
        {
            Management management = managementRepository.FindByManager(_user.Id);
            if (management == null)
            {
                return null;
            }
            return dealsRepository.GetOutgoaingDeals(management);
        }
        public bool DeleteInterestVisitor(int id)
        {
            InterestVisitor visitor = interestVisitors.GetVisitorByID(id);
            if (visitor == null)
            {
                return false;
            }
            interestVisitors.Delete(visitor);
            return true;
        }
    }
}
