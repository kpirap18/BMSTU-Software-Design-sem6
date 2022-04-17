using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentBuisinessLogic
{
    public class UserController
    {
        protected IVisitorRepository visitorRepository;
        protected IHotelRepository hotelRepository;
        protected IInterestVisitorsRepository interestVisitors;
        protected IStatisticsRepository statisticsRepository;
        protected IManagementRepository managementRepository;
        protected IFunctionsRepository functionsRepository;
        protected Userinfo _user;
        public UserController(Userinfo user,  
                              IFunctionsRepository funcRep, 
                              IVisitorRepository visitorRep, 
                              IHotelRepository hotelRep, 
                              IManagementRepository managementRep, 
                              IInterestVisitorsRepository interestVisitorRep, 
                              IStatisticsRepository statRep)
        {
            visitorRepository = visitorRep;
            hotelRepository = hotelRep;
            interestVisitors = interestVisitorRep;
            statisticsRepository = statRep;
            managementRepository = managementRep;
            functionsRepository = funcRep;
            _user = user;
        }
        public List<Visitor> GetAllVisitors()
        {
            return visitorRepository.GetAll();
        }
        public List<VisitorHotelStat> GetVisitorHotelStat()
        {
            return functionsRepository.GetVisitorHotelStat();
        }
        public List<Visitor> GetVisitorsByHotel(int hotelID)
        {
            Hotel hotel = hotelRepository.FindHotelByID(hotelID);
            return visitorRepository.GetVisitorsByHotel(hotel);
        }
        public Visitor FindVisitorByID(int id)
        {
            return visitorRepository.FindVisitorByID(id);
        }
        public Visitor FindVisitorByName(string name)
        {
            return visitorRepository.FindVisitorByName(name);
        }
        public List<Hotel> GetAllHotels()
        {
            return hotelRepository.GetAll();
        }
        public Hotel FindHotelByID(int id)
        {
            return hotelRepository.FindHotelByID(id);
        }
        public Hotel FindHotelByName(string name)
        {
            return hotelRepository.FindHotelByName(name);
        }
        public Statistic GetVisitorStatistic(int id)
        {
            return statisticsRepository.GetStatisticByID(id);
        }
    }
}
