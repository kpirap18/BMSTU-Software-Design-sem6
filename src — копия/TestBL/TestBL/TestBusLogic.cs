using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComponentBuisinessLogic;
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
            IFunctionsRepository funcRep = new FunctionRepository();
            IVisitorRepository visitorRep = new VisitorRepository();
            IHotelRepository hotelRep = new HotelRepository();
            IManagementRepository managementRep = new ManagementRepository();
            IInterestVisitorsRepository interestVisitorRep = new InterestVisitorsRepository();
            IStatisticsRepository statRep = new StatisticsRepository();


            UserController rep = new UserController(user, funcRep, visitorRep, hotelRep, managementRep, interestVisitorRep, statRep);
            List<Visitor> check = rep.GetAllVisitors();
            Assert.IsNotNull(check, "GetAllVisitors");


            List<VisitorHotelStat> check2 = rep.GetVisitorHotelStat();
            Assert.IsNotNull(check2, "GetVisitorHotelStat");

            List<Visitor> check3 = rep.GetVisitorsByHotel(1);
            Assert.IsNotNull(check3, "GetVisitorsByHotel");
            

            Visitor check4 = rep.FindVisitorByID(1);
            Assert.IsNotNull(check4, "FindVisitorByID");

            Visitor check5 = rep.FindVisitorByName("Mike Elliott");
            Assert.IsNotNull(check5, "FindVisitorByName");

            List<Hotel> check6 = rep.GetAllHotels();
            Assert.IsNotNull(check6, "GetAllHotels");

            Hotel check7 = rep.FindHotelByID(1);
            Assert.IsNotNull(check7, "FindHotelByID");

            Hotel check8 = rep.FindHotelByName("Hotel1");
            Assert.IsNotNull(check8, "FindHotelByName");

            Statistic check9 = rep.GetVisitorStatistic(1);
            Assert.IsNotNull(check9, "GetVisitorStatistic");
        }


        [TestMethod]
        public void TestAnalyticController()
        {
            Userinfo user = new Userinfo(id: 2, hash: "3456", login: "3456" );
            IFunctionsRepository funcRep = new FunctionRepository();
            IVisitorRepository visitorRep = new VisitorRepository(); ;
            IHotelRepository hotelRep = new HotelRepository();
            IManagementRepository managementRep = new ManagementRepository();
            IInterestVisitorsRepository interestVisitorRep = new InterestVisitorsRepository();
            IStatisticsRepository statRep = new StatisticsRepository();


            AnalyticController rep = new AnalyticController(user, funcRep, visitorRep, hotelRep, managementRep, interestVisitorRep, statRep);


            List<InterestVisitor> check1 = rep.GetAllInterstVisitors();
            Assert.IsNotNull(check1, "GetAllInterstVisitors");

            bool check2 = rep.AddInterestVisitor(1);
            Assert.AreEqual(check2, true, "AddInterestVisitor");

            bool check3 = rep.DeleteInterestVisitor(1);
            Assert.AreEqual(check3, true, "DeleteInterestVisitor");
        }

        [TestMethod]
        public void TestManagerController()
        {
            Userinfo user = new Userinfo(id: 2, hash: "3456", login: "3456");
            IFunctionsRepository funcRep = new FunctionRepository();
            IAvailableDealsRepository dealRep = new AvailableDealsRepository();
            IVisitorRepository visitorRep = new VisitorRepository(); ;
            IHotelRepository hotelRep = new HotelRepository();
            IManagementRepository managementRep = new ManagementRepository();
            IInterestVisitorsRepository interestVisitorRep = new InterestVisitorsRepository();
            IStatisticsRepository statRep = new StatisticsRepository();

            ManagerController rep = new ManagerController(user, funcRep, dealRep, visitorRep, hotelRep, managementRep, interestVisitorRep, statRep);

            List<InterestVisitor> check1 = rep.GetAllInterestVisitors();
            Assert.IsNotNull(check1, "GetAllInterestVisitors");

            bool check2 = rep.RequestVisitor(1, 100);
            Assert.AreEqual(check2, true, "RequestVisitor");

            bool check3 = rep.ConfirmDeal(12);
            Assert.AreEqual(check3, true, "ConfirmDeal");

            bool check4 = rep.RejectDeal(12);
            Assert.AreEqual(check4, true, "RejectDeal");

            List<Availabledeal> check5 = rep.GetIncomingDeals();
            Assert.IsNotNull(check5, "GetIncomingDeals");

            List<Availabledeal> check6 = rep.GetOutgoaingDeals();
            Assert.IsNotNull(check6, "GetOutgoaingDeals");

            bool check7 = rep.DeleteInterestVisitor(1);
            Assert.AreEqual(check7, true, "DeleteInterestVisitor");
        }

        [TestMethod]
        public void TestModeratorController()
        {
            Userinfo user = new Userinfo();
            IFunctionsRepository funcRep = new FunctionRepository();
            IUserInfoRepository userRep  = new UserInfoRepository();
            IAvailableDealsRepository dealRep = new AvailableDealsRepository();
            IVisitorRepository visitorRep = new VisitorRepository(); ;
            IHotelRepository hotelRep = new HotelRepository();
            IManagementRepository managementRep = new ManagementRepository();
            IInterestVisitorsRepository interestVisitorRep = new InterestVisitorsRepository();
            IStatisticsRepository statRep = new StatisticsRepository();

            ModeratorController rep = new ModeratorController(user, funcRep, userRep, dealRep, visitorRep, hotelRep, managementRep, interestVisitorRep, statRep);

            bool check1 = rep.MakeDeal(12);
            Assert.AreEqual(check1, true, "MakeDeal");

            bool check2 = rep.DeleteDeal(13);
            Assert.AreEqual(check2, true, "DeleteDeal");

            List<Availabledeal> check3 = rep.GetAllDeals();
            Assert.IsNotNull(check3, "GetAllDeals");

            bool check4 = rep.AddNewUser("log1", "123", 1);
            Assert.AreEqual(check4, true, "AddNewUser");

            bool check5 = rep.DeleteUser(101);
            Assert.AreEqual(check5, true, "DeleteUser");

            List<Userinfo> check6 = rep.GetAllUsers();
            Assert.IsNotNull(check6, "GetAllUsers");
        }

    }
}

