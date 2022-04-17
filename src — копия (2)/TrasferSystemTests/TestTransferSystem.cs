using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComponentAccessToDB;
using System.Collections.Generic;
using System;
using ComponentBuisinessLogic;


namespace TrasferSystemTests
{
    [TestClass]
    public class TestTransferSystem
    {
        [TestMethod]
        public void TestUserInfoRepository()
        {
            IUserInfoRepository rep = new UserInfoRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            Userinfo user = new Userinfo(login:"3456", hash:"3456");
            rep.Add(user);
            Userinfo checkUser1 = rep.FindUserByLogin("3456");

            Assert.IsNotNull(checkUser1, "user1 was not added");
            

            Assert.AreEqual("3456", checkUser1.Hash, "Not equal Added user");
            
            
            int userId = checkUser1.Id;
            //user.Id = userId;
            //checkUser1.Hash = "7890";
            //rep.Update(checkUser1);
            Userinfo checkUser2 = rep.FindUserByID(userId);

            Assert.IsNotNull(checkUser2, "cannot find user2 by id");
            

            //Assert.AreEqual("7890", checkUser2.Hash, "Not Equal Updated user");


            rep.Delete(checkUser2);

            Assert.IsNull(rep.FindUserByID(checkUser2.Id), "user2 was not deleted");
            

            List<Userinfo> users = rep.GetLimit(100);

            Assert.IsNotNull(users, "Can't find userinfos");

        }

        [TestMethod]
        public void TestHotelRepository()
        {
            IHotelRepository rep = new HotelRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            Hotel hotel = new Hotel(mid:1, name:"Dynamo", country:"Russia", cost:100000);
            rep.Add(hotel);
            Hotel checkhotel1 = rep.FindHotelByName("Dynamo");
            Assert.IsNotNull(checkhotel1, "hotels1 was not added");

            Assert.AreEqual("Dynamo", checkhotel1.Name, "Not equal Added hotel");


            int hotelID = hotel.HotelID;
            rep.Update(checkhotel1);
            Hotel checkhotel2 = rep.FindHotelByID(hotelID);
            Assert.IsNotNull(checkhotel2, "cannot find hotels2 by id");



            rep.Delete(checkhotel2);
            Assert.IsNull(rep.FindHotelByID(checkhotel2.HotelID), "hotel2 was not deleted");


            List<Hotel> hotels = rep.GetLimit(100);
            Assert.IsNotNull(hotels, "Can't find hotels");

            Visitor visitor = new Visitor(vid:1, hid:1, s:1, name:"Denis", age:20, country:"Russia", b:2000);
            Hotel checkhotel3 = rep.FindHotelByVisitor(visitor);
            Assert.IsNotNull(checkhotel3, "Can't find hotel by visitor");

        }

        [TestMethod]
        public void TestVisitorRepository()
        {
            IVisitorRepository rep = new VisitorRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            Visitor visitor = new Visitor(hid: 1, s: 1, name: "Vlad", age: 27, country: "Russia", b: 4000);
            rep.Add(visitor);
            Visitor checkvisitor1 = rep.FindVisitorByName("Vlad");
            Assert.IsNotNull(checkvisitor1, "visitor1 was no added");


            Assert.AreEqual("Vlad", checkvisitor1.Name, "Not equal added visitor");


            int visitorID = checkvisitor1.VisitorID;
            rep.Update(checkvisitor1);
            Visitor checkvisitor2 = rep.FindVisitorByID(visitorID);
            Assert.IsNotNull(checkvisitor2, "visitor2 was not found by id");


            rep.Delete(checkvisitor2);
            Assert.IsNull(rep.FindVisitorByID(visitorID), "visitor2 was not deleted");


            List<Visitor> visitors = rep.GetLimit(100);
            Assert.IsNotNull(visitors, "Can't find hotels");


            Hotel hotel = new Hotel(hid:1);
            visitors = rep.GetVisitorsByHotel(hotel);
            Assert.IsNotNull(visitors, "can't find visitors by hotel");

        }
        
        [TestMethod]
        public void TestStatisticsRepository()
        {
            IStatisticsRepository rep = new StatisticsRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            Statistic stat = new Statistic(ar:20, number:5);
            rep.Add(stat);
            
            Statistic checkStat1 = rep.GetStatisticByID(2);
            Assert.IsNotNull(checkStat1, "stat1 was not added");

            
            Assert.AreEqual(25, checkStat1.NumberOfTrips, "not equal added stat1");

            checkStat1 = new Statistic(sid: checkStat1.Statisticsid, 
                                       number: 25, 
                                       ar: checkStat1.AverageRating);
            //checkStat1.NumberOfTrips = 25;
            rep.Update(checkStat1);
            Statistic checkStat2 = rep.GetStatisticByID(2);
            Assert.AreEqual(25, checkStat2.NumberOfTrips, "stat2 was not updated");


            rep.Delete(checkStat2);
            
            Assert.IsNotNull(rep.GetStatisticByID(2), "stat2 was not deleted");


            List<Statistic> stats = rep.GetLimit(100);
            Assert.IsNotNull(stats, "Can't find stats");


            Visitor visitor = new Visitor(vid:1, s:1);
            Assert.IsNotNull(rep.GetStatisticsByVisitor(visitor), "can't find stat by visitor");

        }
        [TestMethod]
        public void TestAvailableDealsRepository()
        {
            IAvailableDealsRepository rep = new AvailableDealsRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            Availabledeal deal = new Availabledeal(vid:1, fid:2, tid:3, cost:2000, s:2);
            rep.Add(deal);

            deal = new Availabledeal(id: deal.Id, vid: deal.VisitorID, 
                                     tid: deal.Tomanagementid, fid:deal.Frommanagementid,
                                     cost: 2500, s:deal.Status);
            //deal.Cost = 2500;
            rep.Update(deal);
            
            List<Availabledeal> deals = rep.GetLimit(100);
            Assert.IsNotNull(deals, "can't find deals");


            deals = rep.GetIncomingDeals(new Management(mid: 4));
            Assert.IsNotNull(deals, "can't find incoming deals");


            deals = rep.GetOutgoaingDeals(new Management(mid:3));
            Assert.IsNotNull(deals, "can't find incoming deals");


            deal = new Availabledeal(id: 1, vid: deal.VisitorID,
                                     tid: deal.Tomanagementid, fid: deal.Frommanagementid,
                                     cost: deal.Cost, s: deal.Status);
            rep.ConfirmDeal(deal);
            Availabledeal resDeal = rep.GetDealByID(1);
            Assert.IsNotNull(resDeal, "can't find deal");


            Assert.AreEqual(resDeal.Status, 2, "status is different");

        }
        [TestMethod]
        public void TestInterestVisitorssRepository()
        {
            IInterestVisitorsRepository rep = new InterestVisitorsRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            InterestVisitor visitor = new InterestVisitor(vid: 1, hid: 1, mid: 3);
            rep.Add(visitor);

            visitor = new InterestVisitor(id: visitor.Id, hid: visitor.HotelID,
                                          vid: visitor.VisitorID, mid:2);
            //visitor.Managementid = 2;
            rep.Update(visitor);

            List<InterestVisitor> visitors = rep.GetLimit(100);
            Assert.IsNotNull(visitors, "Can't find visitors");


            visitor = rep.GetVisitorByID(3);
            Assert.IsNotNull(visitor, "can't find visitor");


            visitors = rep.GetVisitorsByManagement(new Management(mid:3));
            Assert.IsNotNull(visitors, "Can't find visitors");


            rep.Delete(visitor);
        }

        //[TestMethod] ÿ¿¡ÀŒÕ
        //public void Test()
        //{
        //    IUserInfoRepository rep = new UserInfoRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
        //    Userinfo user = new Userinfo { Hash = "567", Login = "567", Permission = 3 };
        //    rep.Add(user);
        //}
    }
}
