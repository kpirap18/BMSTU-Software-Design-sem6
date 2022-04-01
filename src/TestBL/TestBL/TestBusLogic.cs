using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComponentBuisinessLogic;
using ComponentAccessToDB;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;

namespace TestBL
{
    [TestClass]
    public class TestBusLogic
    {
        [TestMethod]
        public void TestUserController()
        {
            Userinfo user = new Userinfo();
            FunctionRepository funcRep = new FunctionRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Guest)));
            VisitorRepository visitorRep = new VisitorRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Guest))); ;
            HotelRepository hotelRep = new HotelRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Guest)));
            ManagementRepository managementRep = new ManagementRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Guest)));
            InterestVisitorsRepository interestVisitorRep = new InterestVisitorsRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Guest)));
            StatisticsRepository statRep = new StatisticsRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Guest)));


            UserController rep = new UserController(user, funcRep, visitorRep, hotelRep, managementRep, interestVisitorRep, statRep);
            List<Visitor> check = rep.GetAllVisitors();
            if (check != null)
            {
                Console.WriteLine("PASSED GetAllVisitors");
            }
            else
            {
                Console.WriteLine("        FAILED GetAllVisitors");
            }

            List<VisitorHotelStat> check2 = rep.GetVisitorHotelStat();
            if (check2 != null)
            {
                Console.WriteLine("PASSED GetVisitorHotelStat");
            }
            else
            {
                Console.WriteLine("        FAILED GetVisitorHotelStat");
            }

            List<Visitor> check3 = rep.GetVisitorsByHotel(1);
            if (check3 != null)
            {
                Console.WriteLine("PASSED GetVisitorsByHotel");
            }
            else
            {
                Console.WriteLine("        FAILED GetVisitorsByHotel");
            }

            Visitor check4 = rep.FindVisitorByID(1);
            if (check4 != null)
            {
                Console.WriteLine("PASSED FindVisitorByID");
            }
            else
            {
                Console.WriteLine("        FAILED FindVisitorByID");
            }

            Visitor check5 = rep.FindVisitorByName("Mike Elliott");
            if (check5 != null)
            {
                Console.WriteLine("PASSED FindVisitorByName");
            }
            else
            {
                Console.WriteLine("        FAILED FindVisitorByName");
            }

            List<Hotel> check6 = rep.GetAllHotels();
            if (check6 != null)
            {
                Console.WriteLine("PASSED GetAllHotels");
            }
            else
            {
                Console.WriteLine("        FAILED GetAllHotels");
            }

            Hotel check7 = rep.FindHotelByID(1);
            if (check7 != null)
            {
                Console.WriteLine("PASSED FindHotelByID");
            }
            else
            {
                Console.WriteLine("        FAILED FindHotelByID");
            }

            Hotel check8 = rep.FindHotelByName("Hotel1");
            if (check8 != null)
            {
                Console.WriteLine("PASSED FindHotelByName");
            }
            else
            {
                Console.WriteLine("        FAILED FindHotelByName");
            }

            Statistic check9 = rep.GetVisitorStatistic(1);
            if (check9 != null)
            {
                Console.WriteLine("PASSED GetVisitorStatistic");
            }
            else
            {
                Console.WriteLine("        FAILED GetVisitorStatistic");
            }
        }


        [TestMethod]
        public void TestAnalyticController()
        {
            Userinfo user = new Userinfo {Id = 2,  Hash = "3456", Login = "3456" };
            FunctionRepository funcRep = new FunctionRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Analytic)));
            VisitorRepository visitorRep = new VisitorRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Analytic))); ;
            HotelRepository hotelRep = new HotelRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Analytic)));
            ManagementRepository managementRep = new ManagementRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Analytic)));
            InterestVisitorsRepository interestVisitorRep = new InterestVisitorsRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Analytic)));
            StatisticsRepository statRep = new StatisticsRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Analytic)));


            AnalyticController rep = new AnalyticController(user, funcRep, visitorRep, hotelRep, managementRep, interestVisitorRep, statRep);


            //List<InterestVisitor> check1 = rep.GetAllInterstVisitors();
            if (rep != null)
            {
                Console.WriteLine("PASSED GetAllInterstVisitors");
            }
            else
            {
                Console.WriteLine("        FAILED GetAllInterstVisitors");
            }

            bool check2 = rep.AddInterestVisitor(1);
            if (check2 == true)
            {
                Console.WriteLine("PASSED AddInterestVisitor");
            }
            else
            {
                Console.WriteLine("        FAILED AddInterestVisitor");
            }

            bool check3 = rep.DeleteInterestVisitor(1);
            if (check3 == true)
            {
                Console.WriteLine("PASSED DeleteInterestVisitor");
            }
            else
            {
                Console.WriteLine("        FAILED DeleteInterestVisitor");
            }
        }

        [TestMethod]
        public void TestManagerController()
        {
            Userinfo user = new Userinfo { Id = 2,  Hash = "3456", Login = "3456" };
            FunctionRepository funcRep = new FunctionRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Manager)));
            AvailableDealsRepository dealRep = new AvailableDealsRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Manager)));
            VisitorRepository visitorRep = new VisitorRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Manager))); ;
            HotelRepository hotelRep = new HotelRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Manager)));
            ManagementRepository managementRep = new ManagementRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Manager)));
            InterestVisitorsRepository interestVisitorRep = new InterestVisitorsRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Manager)));
            StatisticsRepository statRep = new StatisticsRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Manager)));

            ManagerController rep = new ManagerController(user, funcRep, dealRep, visitorRep, hotelRep, managementRep, interestVisitorRep, statRep);

            List<InterestVisitor> check1 = rep.GetAllInterestVisitors();
            if (check1 != null)
            {
                Console.WriteLine("PASSED GetAllInterestVisitors");
            }
            else
            {
                Console.WriteLine("        FAILED GetAllInterestVisitors");
            }

            bool check2 = rep.RequestVisitor(1, 100);
            if (check2 == true)
            {
                Console.WriteLine("PASSED RequestVisitor");
            }
            else
            {
                Console.WriteLine("        FAILED RequestVisitor");
            }

            bool check3 = rep.ConfirmDeal(12);
            if (check3 == true)
            {
                Console.WriteLine("PASSED ConfirmDeal");
            }
            else
            {
                Console.WriteLine("        FAILED ConfirmDeal");
            }

            bool check4 = rep.RejectDeal(12);
            if (check4 == true)
            {
                Console.WriteLine("PASSED RejectDeal");
            }
            else
            {
                Console.WriteLine("        FAILED RejectDeal");
            }

            List<Availabledeal> check5 = rep.GetIncomingDeals();
            if (check5 != null)
            {
                Console.WriteLine("PASSED GetIncomingDeals");
            }
            else
            {
                Console.WriteLine("        FAILED GetIncomingDeals");
            }

            List<Availabledeal> check6 = rep.GetOutgoaingDeals();
            if (check6 != null)
            {
                Console.WriteLine("PASSED GetOutgoaingDeals");
            }
            else
            {
                Console.WriteLine("        FAILED GetOutgoaingDeals");
            }

            bool check7 = rep.DeleteInterestVisitor(1);
            if (check7 == true)
            {
                Console.WriteLine("PASSED DeleteInterestVisitor");
            }
            else
            {
                Console.WriteLine("        FAILED DeleteInterestVisitor");
            }
        }

        [TestMethod]
        public void TestModeratorController()
        {
            Userinfo user = new Userinfo();
            FunctionRepository funcRep = new FunctionRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            UserInfoRepository userRep  = new UserInfoRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            AvailableDealsRepository dealRep = new AvailableDealsRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            VisitorRepository visitorRep = new VisitorRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder))); ;
            HotelRepository hotelRep = new HotelRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            ManagementRepository managementRep = new ManagementRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            InterestVisitorsRepository interestVisitorRep = new InterestVisitorsRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            StatisticsRepository statRep = new StatisticsRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));

            ModeratorController rep = new ModeratorController(user, funcRep, userRep, dealRep, visitorRep, hotelRep, managementRep, interestVisitorRep, statRep);

            bool check1 = rep.MakeDeal(12);
            if (check1 == true)
            {
                Console.WriteLine("PASSED MakeDeal");
            }
            else
            {
                Console.WriteLine("        FAILED MakeDeal");
            }

            bool check2 = rep.DeleteDeal(13);
            if (check2 == true)
            {
                Console.WriteLine("PASSED DeleteDeal");
            }
            else
            {
                Console.WriteLine("        FAILED DeleteDeal");
            }

            List<Availabledeal> check3 = rep.GetAllDeals();
            if (check3 != null)
            {
                Console.WriteLine("PASSED GetAllDeals");
            }
            else
            {
                Console.WriteLine("        FAILED GetAllDeals");
            }

            bool check4 = rep.AddNewUser("log1", "123", 1);
            if (check4 == true)
            {
                Console.WriteLine("PASSED AddNewUser");
            }
            else
            {
                Console.WriteLine("        FAILED AddNewUser");
            }

            bool check5 = rep.DeleteUser(101);
            if (check5 == true)
            {
                Console.WriteLine("PASSED DeleteUser");
            }
            else
            {
                Console.WriteLine("        FAILED DeleteUser");
            }

            List<Userinfo> check6 = rep.GetAllUsers();
            if (check6 != null)
            {
                Console.WriteLine("PASSED GetAllUsers");
            }
            else
            {
                Console.WriteLine("        FAILED GetAllUsers");
            }
        }

    }
}

