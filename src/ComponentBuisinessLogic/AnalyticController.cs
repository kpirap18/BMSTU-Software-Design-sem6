﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentAccessToDB;
using Microsoft.Extensions.Logging;

namespace ComponentBuisinessLogic
{
    public class AnalyticController : UserController
    {
        public AnalyticController(Userinfo user, 
                                  ILogger<UserController> logger,
                                  IFunctionsRepository funcRep, 
                                  IVisitorRepository visitorRep, 
                                  IHotelRepository hotelRep, 
                                  IManagementRepository managementRep, 
                                  IInterestVisitorsRepository intervisitorRep,
                                  IStatisticsRepository statRep) : 
            base(user, logger, funcRep, visitorRep, hotelRep, managementRep, intervisitorRep, statRep)
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
            InterestVisitor newDesireVisitor = new InterestVisitor { Managementid = management.Managementid, VisitorID = visitor.VisitorID, HotelID = visitor.HotelID };
            interestVisitors.Add(newDesireVisitor);
            return true;
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
