using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentAccessToDB;
using Microsoft.Extensions.Logging;

namespace ComponentBuisinessLogic
{
    public class ModeratorController : UserController
    {
        IAvailableDealsRepository dealsRepository;
        IUserInfoRepository userInfoRepository;
        public ModeratorController(Userinfo user, 
                                   ILogger<UserController> logger, 
                                   IFunctionsRepository funcRep, 
                                   IUserInfoRepository userRep, 
                                   IAvailableDealsRepository dealsRep,
                                   IVisitorRepository visitorRep, 
                                   IHotelRepository hotelRep, 
                                   IManagementRepository managementRep, 
                                   IInterestVisitorsRepository interestVisitorRep,
                                   IStatisticsRepository statRep) :
            base(user, logger, funcRep, visitorRep, hotelRep, managementRep, interestVisitorRep, statRep)
        {
            dealsRepository = dealsRep;
            userInfoRepository = userRep;
        }
        public bool MakeDeal(int dealID)
        {
            Availabledeal deal = dealsRepository.GetDealByID(dealID);
            if (deal == null)
            {
                _logger.LogError("Deal {Number} was not fount at {dateTime}", dealID, DateTime.UtcNow);
                return false;
            }
            Hotel newHotel = hotelRepository.FindHotelByManagement((int)deal.Frommanagementid);
            if (newHotel == null)
            {
                _logger.LogError("New hotel was not fount by Tomanagementid {id} at {dateTime}", (int)deal.Tomanagementid, DateTime.UtcNow);
                return false;
            }
            Hotel lastHotel = hotelRepository.FindHotelByManagement((int)deal.Tomanagementid);
            if (lastHotel == null)
            {
                _logger.LogError("Last hotel was not fount by Frommanagementid {id} at {dateTime}", (int)deal.Frommanagementid, DateTime.UtcNow);
                return false;
            }
            Visitor visitor = visitorRepository.FindVisitorByID((int)deal.VisitorID);
            if (visitor == null)
            {
                _logger.LogError("Visitor {Number} was not fount at {dateTime}", (int)deal.VisitorID, DateTime.UtcNow);
                return false;
            }
            if (! CheckOportunityToBuy(deal.Cost, newHotel))
            {
                _logger.LogError("Deal cost {Number} is more than hotel balance at {dateTime}", deal.Cost, DateTime.UtcNow);
                return false;
            }
            UpdateHotelBalance(lastHotel, newHotel, deal.Cost);
            UpdateVisitorHotel(visitor, newHotel.HotelID);
            dealsRepository.Delete(deal);
            return true;
        }
        public bool DeleteDeal(int dealID)
        {
            Availabledeal deal = dealsRepository.GetDealByID(dealID);
            if (deal == null)
            {
                _logger.LogError("Deal {Number} was not fount at {dateTime}", dealID, DateTime.UtcNow);
                return false;
            }
            dealsRepository.Delete(deal);
            return true;
        }
        public void UpdateVisitorHotel(Visitor visitor, int hotel)
        {
            visitor.HotelID = hotel;
            visitorRepository.Update(visitor);
        }
        private void UpdateHotelBalance(Hotel lastHotel, Hotel newHotel, int cost)
        {
            lastHotel.Cost += cost;
            newHotel.Cost -= cost;
            hotelRepository.Update(lastHotel);
            hotelRepository.Update(newHotel);
        }
        private bool CheckOportunityToBuy(int cost, Hotel hotel)
        {
            return cost < hotel.Cost;
        }
        public List<Availabledeal> GetAllDeals()
        {
            return dealsRepository.GetAll();
        }
        public bool AddNewUser(string login, string hash, int perms)
        {
            if (userInfoRepository.FindUserByLogin(login) != null)
            {
                return false;
            }
            Userinfo user = new Userinfo { Login = login, Hash = hash, Permission = perms };
            userInfoRepository.Add(user);
            return true;
        }
        public bool DeleteUser(int id)
        {
            Userinfo user = userInfoRepository.FindUserByID(id);
            if (user == null)
            {
                _logger.LogError("User {id} was not found at {dateTime}", id, DateTime.UtcNow);
                return false;
            }
            userInfoRepository.Delete(user);
            return true;
        }
        public List<Userinfo> GetAllUsers()
        {
            return userInfoRepository.GetAll();
        }
    }
}
