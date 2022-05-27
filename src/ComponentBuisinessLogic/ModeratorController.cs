using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BL
{
    public class ModeratorController : UserController
    {
        //private readonly ILogger<ModeratorController> _logger;

        IAvailableDealsRepository dealsRepository;
        IUserInfoRepository userInfoRepository;
        public ModeratorController(Userinfo user, 
                                   IFunctionsRepository funcRep, 
                                   IUserInfoRepository userRep, 
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
            userInfoRepository = userRep;
        }
        public bool MakeDeal(int dealID)
        {
            Availabledeal deal = dealsRepository.GetDealByID(dealID);
            if (deal == null)
            {
                Console.WriteLine("Deal {Number} was not fount at {dateTime}", dealID, DateTime.UtcNow);
                return false;
            }
            Hotel newHotel = hotelRepository.FindHotelByManagement((int)deal.Frommanagementid);
            if (newHotel == null)
            {
                Console.WriteLine("New hotel was not fount by Tomanagementid {id} at {dateTime}", (int)deal.Tomanagementid, DateTime.UtcNow);
                return false;
            }
            Hotel lastHotel = hotelRepository.FindHotelByManagement((int)deal.Tomanagementid);
            if (lastHotel == null)
            {
                Console.WriteLine("Last hotel was not fount by Frommanagementid {id} at {dateTime}", (int)deal.Frommanagementid, DateTime.UtcNow);
                return false;
            }
            Visitor visitor = visitorRepository.FindVisitorByID((int)deal.VisitorID);
            if (visitor == null)
            {
                Console.WriteLine("Visitor {0} was not fount at {1}", (int)deal.VisitorID, DateTime.UtcNow);
                return false;
            }
            if (! CheckOportunityToBuy(deal.Cost, newHotel))
            {
                Console.WriteLine("Deal cost {0} is more than hotel balance at {1}", deal.Cost, DateTime.UtcNow);
                return false;
            }
            UpdateHotelBalance(lastHotel, newHotel, deal.Cost);
            UpdateVisitorHotel(visitor, newHotel.HotelID);
            return true;
        }
        public bool DeleteDeal(int dealID)
        {
            Availabledeal deal = dealsRepository.GetDealByID(dealID);
            if (deal == null)
            {
                Console.WriteLine("Deal {Number} was not fount at {dateTime}", dealID, DateTime.UtcNow);
                return false;
            }
            try
            {
                dealsRepository.Delete(deal);
            }
            catch
            {
                throw new AvailabledealException("Удаление сделки");
            }
            return true;
        }
        public bool UpdateVisitorHotel(Visitor visitor, int hotel)
        {
            visitor = new Visitor(vid: visitor.VisitorID,
                                  hid: hotel,
                                  s: visitor.Statistics,
                                  name: visitor.Name,
                                  age: visitor.Age,
                                  country: visitor.Country,
                                  b: visitor.Budget);
            try
            {
                visitorRepository.Update(visitor);
            }
            catch
            {
                throw new VisitorException("Обновление посетителя");
            }
            return true;
        }
        private bool UpdateHotelBalance(Hotel lastHotel, Hotel newHotel, int cost)
        {
            lastHotel = new Hotel(hid: lastHotel.HotelID,
                                  mid: lastHotel.Managementid,
                                  name: lastHotel.Name,
                                  country: lastHotel.Country,
                                  cost: lastHotel.Cost + cost, 
                                  stars: lastHotel.Stars);
            newHotel = new Hotel(hid: newHotel.HotelID,
                                  mid: newHotel.Managementid,
                                  name: newHotel.Name,
                                  country: newHotel.Country,
                                  cost: newHotel.Cost - cost,
                                  stars: lastHotel.Stars);
            try
            {
                hotelRepository.Update(lastHotel);
                hotelRepository.Update(newHotel);
            }
            catch
            {
                throw new HotelException("Обновление отеля");
            }
            return true;
        }
        private bool CheckOportunityToBuy(int cost, Hotel hotel)
        {
            return cost <= hotel.Cost;
        }
        public List<Availabledeal> GetAllDeals()
        {
            return dealsRepository.GetLimit(100);
        }
        public bool AddNewUser(string login, string hash, int perms)
        {
            if (userInfoRepository.FindUserByLogin(login) != null)
            {
                return false;
            }
            Userinfo user = new Userinfo(login: login,hash: hash, per: perms);

            try
            {
                userInfoRepository.Add(user);
            }
            catch
            {
                throw new UserinfoException("Добавление нового юзера");
            }
            return true;
        }
        public bool DeleteUser(int id)
        {
            Userinfo user = userInfoRepository.FindUserByID(id);
            if (user == null)
            {
                Console.WriteLine("User {id} was not found at {dateTime}", id, DateTime.UtcNow);
                return false;
            }
            try
            {
                userInfoRepository.Delete(user);
            }
            catch
            {
                throw new UserinfoException("Удаление нового юзера");
            }
            return true;
        }
        public List<Userinfo> GetAllUsers()
        {
            return userInfoRepository.GetLimit(100);
        }
    }
}
