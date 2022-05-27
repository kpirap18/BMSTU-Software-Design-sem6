using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BL
{
    public enum Status
    {
        Confirmed = 0,
        Rejected = 1,
        NotSeen = 2
    }
    public class ManagerController : UserController
    {
        IAvailableDealsRepository dealsRepository;
        public ManagerController(Userinfo user, 
                                 IFunctionsRepository funcRep, 
                                 IAvailableDealsRepository dealsRep, 
                                 IVisitorRepository visitorRep, 
                                 IHotelRepository hotelRep,
                                 IHotelStarsRepository hotelstarsRep,
                                 IManagementRepository managementRep,
                                 IInterestVisitorsRepository interestVisitorRep,
                                 IStatisticsRepository statRep) :
            base(user, funcRep, visitorRep, hotelRep, hotelstarsRep, managementRep, interestVisitorRep, statRep)
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
            Availabledeal deal = new Availabledeal(vid: visitorID, tid: hotel.Managementid, 
                                                   fid: management.Managementid, 
                                                  cost: cost, s: (int)Status.NotSeen);
            try
            {
                dealsRepository.Add(deal);
            }
            catch
            {
                throw new AvailabledealException("Новая сделка");
            }
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

            try
            {
                interestVisitors.Delete(visitor);
            }
            catch
            {
                throw new InterestVisitorException("Удаление посетителя");
            }
            return true;
        }
    }
}
