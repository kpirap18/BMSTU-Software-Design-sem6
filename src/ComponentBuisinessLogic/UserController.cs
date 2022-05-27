using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;


namespace BL
{
    public class UserController
    {
        //public ILogger<UserController> _logger;

        protected IVisitorRepository visitorRepository;
        protected IHotelRepository hotelRepository;
        protected IHotelStarsRepository hotelStarsRepository;
        protected IInterestVisitorsRepository interestVisitors;
        protected IStatisticsRepository statisticsRepository;
        protected IManagementRepository managementRepository;
        protected IFunctionsRepository functionsRepository;
        protected Userinfo _user;
        public UserController(Userinfo user,
                              IFunctionsRepository funcRep,
                              IVisitorRepository visitorRep,
                              IHotelRepository hotelRep,
                              IHotelStarsRepository hotelstarsRep,
                              IManagementRepository managementRep,
                              IInterestVisitorsRepository interestVisitorRep,
                              IStatisticsRepository statRep)
        {
            visitorRepository = visitorRep;
            hotelRepository = hotelRep;
            hotelStarsRepository = hotelstarsRep;
            interestVisitors = interestVisitorRep;
            statisticsRepository = statRep;
            managementRepository = managementRep;
            functionsRepository = funcRep;
            _user = user;
        }
        public List<Visitor> GetAllVisitors()
        {
            return visitorRepository.GetLimit(100); 
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
            return hotelRepository.GetLimit(100);
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

        public List<Hotel> GetHotelByStars(int stars)
        {
            return hotelStarsRepository.FindHotelByStars(stars);
        }

    }
}
