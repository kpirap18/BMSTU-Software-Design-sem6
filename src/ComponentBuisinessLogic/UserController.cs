using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentAccessToDB;
using Microsoft.Extensions.Logging;

namespace ComponentBuisinessLogic
{
    public class UserController
    {
        protected VisitorRepository visitorRepository;
        protected HotelRepository hotelRepository;
        protected InterestVisitorsRepository interestVisitors;
        protected StatisticsRepository statisticsRepository;
        protected ManagementRepository managementRepository;
        protected FunctionRepository functionsRepository;
        protected Userinfo _user;
        public UserController(Userinfo user,  
                              FunctionRepository funcRep, 
                              VisitorRepository visitorRep, 
                              HotelRepository hotelRep, 
                              ManagementRepository managementRep, 
                              InterestVisitorsRepository interestVisitorRep, 
                              StatisticsRepository statRep)
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
