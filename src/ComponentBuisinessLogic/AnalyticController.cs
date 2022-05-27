using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BL
{
    public class AnalyticController : UserController
    {
        public AnalyticController(Userinfo user, 
                                  IFunctionsRepository funcRep, 
                                  IVisitorRepository visitorRep, 
                                  IHotelRepository hotelRep,
                                  IHotelStarsRepository hotelstarsRep,
                                  IManagementRepository managementRep, 
                                  IInterestVisitorsRepository intervisitorRep,
                                  IStatisticsRepository statRep) : 
            base(user, funcRep, visitorRep, hotelRep, hotelstarsRep, managementRep, intervisitorRep, statRep)
        {
        }
        public List<InterestVisitor> GetAllInterstVisitors()
        {
            Management management = managementRepository.FindByAnalytic(_user.Id);
            return interestVisitors.GetVisitorsByManagement(management);
        }
        public bool AddInterestVisitor(int visitorID)
        {
            Visitor visitor = visitorRepository.FindVisitorByID(visitorID);
            if (visitor == null)
            {
                return false;
            }
            Management management = managementRepository.FindByAnalytic(_user.Id);
            if (management == null)
            {
                return false;
            }
            InterestVisitor newDesireVisitor = new InterestVisitor(mid: management.Managementid, 
                                                                   vid: visitor.VisitorID, 
                                                                   hid: visitor.HotelID);
            try
            {
                interestVisitors.Add(newDesireVisitor);
            }
            catch
            {
                throw new InterestVisitorException("Добавление посетителя");
            }
            return true;
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
