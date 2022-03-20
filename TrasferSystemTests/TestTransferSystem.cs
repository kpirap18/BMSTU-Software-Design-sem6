using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComponentAccessToDB;
using System.Collections.Generic;
using System;

namespace TrasferSystemTests
{
    [TestClass]
    public class TestTransferSystem
    {
        [TestMethod]
        public void TestUserInfoRepository()
        {
            Console.WriteLine("WDWWDWD");
            IUserInfoRepository rep = new UserInfoRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            Userinfo user = new Userinfo { Hash = "3456", Login = "3456" };
            rep.Add(user);
            Userinfo checkUser1 = rep.FindUserByLogin("3456");
            Assert.IsNotNull(checkUser1, "user1 was not added");
            Assert.AreEqual("3456", checkUser1.Hash, "Not equal Added user");
            
            int userId = checkUser1.Id;
            user.Id = userId;
            checkUser1.Hash = "7890";
            rep.Update(checkUser1);
            Userinfo checkUser2 = rep.FindUserByID(userId);
            Assert.IsNotNull(checkUser2, "cannot find user2 by id");
            Assert.AreEqual("7890", checkUser2.Hash, "Not Equal Updated user");

            rep.Delete(checkUser2);
            Assert.IsNull(rep.FindUserByID(checkUser2.Id), "user2 was not deleted");    

            List<Userinfo> users = rep.GetAll();
            Assert.IsNotNull(users, "Can't find userinfos");
        }

        [TestMethod]
        public void TestHotelRepository()
        {
            IHotelRepository rep = new HotelRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            Hotel hotel = new Hotel { Managementid = 1, Name = "Dynamo", Country = "Russia", Cost = 100000 };
            rep.Add(hotel);
            Hotel checkhotel1 = rep.FindHotelByName("Dynamo");
            Assert.IsNotNull(checkhotel1, "hotels1 was not added");
            Assert.AreEqual("Dynamo", checkhotel1.Name, "Not equal Added hotel");
            
            int hotelID = hotel.HotelID;
            //checkhotel1.Headcoach = "Denis Sklif";
            rep.Update(checkhotel1);
            Hotel checkhotel2 = rep.FindHotelByID(hotelID);
            Assert.IsNotNull(checkhotel2, "cannot find hotels2 by id");
            //Assert.AreEqual("Denis Sklif", checkhotel2.Headcoach, "Not equal updated hotel");
            
            rep.Delete(checkhotel2);
            Assert.IsNull(rep.FindHotelByID(checkhotel2.HotelID), "hotel2 was not deleted");
            
            List<Hotel> hotels = rep.GetAll();
            Assert.IsNotNull(hotels, "Can't find hotels");

            Visitor visitor = new Visitor { VisitorID = 1, HotelID = 1, Statistics = 1, Name = "Denis", Age = 20, Country = "Russia", Budget = 2000 };
            Hotel checkhotel3 = rep.FindHotelByVisitor(visitor);
            Assert.IsNotNull(checkhotel3, "Can't find hotel by visitor");
        }

        [TestMethod]
        public void TestVisitorRepository()
        {
            IVisitorRepository rep = new VisitorRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            Visitor player = new Visitor { HotelID = 1, Statistics = 1, Name = "Vlad", Age = 27, Country = "Russia", Budget = 4000 };
            rep.Add(player);
            Visitor checkPlayer1 = rep.FindVisitorByName("Vlad");
            Assert.IsNotNull(checkPlayer1, "player1 was no added");
            Assert.AreEqual("Vlad", checkPlayer1.Name, "Not equal added player");
            
            int playerID = checkPlayer1.VisitorID;
            //checkPlayer1.Height = 176;
            rep.Update(checkPlayer1);
            Visitor checkPlayer2 = rep.FindVisitorByID(playerID);
            Assert.IsNotNull(checkPlayer2, "player2 was not found by id");
            //Assert.AreEqual(176, checkPlayer2.Height, "player2 was not updated");

            rep.Delete(checkPlayer2);
            Assert.IsNull(rep.FindVisitorByID(playerID), "player2 was not deleted");
            
            List<Visitor> players = rep.GetAll();
            Assert.IsNotNull(players, "Can't find hotels");

            Hotel hotel = new Hotel { HotelID = 1 };
            players = rep.GetVisitorsByHotel(hotel);
            Assert.IsNotNull(players, "can't find players by hotel");
        }
        
        [TestMethod]
        public void TestStatisticsRepository()
        {
            IStatisticsRepository rep = new StatisticsRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            Statistic stat = new Statistic { AverageRating = 20, NumberOfTrips = 5 };
            rep.Add(stat);
            
            Statistic checkStat1 = rep.GetStatisticByID(2);
            Assert.IsNotNull(checkStat1, "stat1 was not added");
            Assert.AreEqual(5, checkStat1.NumberOfTrips, "not equal added stat1");

            checkStat1.NumberOfTrips = 25;
            rep.Update(checkStat1);
            Statistic checkStat2 = rep.GetStatisticByID(2);
            Assert.AreEqual(25, checkStat2.NumberOfTrips, "stat2 was not updated");

            rep.Delete(checkStat2);
            Assert.IsNull(rep.GetStatisticByID(2), "stat2 was not deleted");

            List<Statistic> stats = rep.GetAll();
            Assert.IsNotNull(stats, "Can't find stats");

            Visitor player = new Visitor { VisitorID = 1, Statistics = 1 };
            Assert.IsNotNull(rep.GetStatisticsByVisitor(player), "can't find stat by visitor");
        }
        [TestMethod]
        public void TestAvailableDealsRepository()
        {
            IAvailableDealsRepository rep = new AvailableDealsRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            Availabledeal deal = new Availabledeal { VisitorID = 1, Frommanagementid = 2, Tomanagementid = 3, Cost = 2000, Status = 2 };
            rep.Add(deal);
            
            deal.Cost = 2500;
            rep.Update(deal);
            
            List<Availabledeal> deals = rep.GetAll();
            Assert.IsNotNull(deals, "can't find deals");

            deals = rep.GetIncomingDeals(new Management { Managementid = 4 });
            Assert.IsNotNull(deals, "can't find incoming deals");

            deals = rep.GetOutgoaingDeals(new Management { Managementid = 3 });
            Assert.IsNotNull(deals, "can't find incoming deals");

            deal.Id = 1;
            rep.ConfirmDeal(deal);
            Availabledeal resDeal = rep.GetDealByID(1);
            Assert.IsNotNull(resDeal, "can't find deal");
            Assert.AreEqual(resDeal.Status, 0, "status is different");
            
            rep.RejectDeal(resDeal);
            resDeal = rep.GetDealByID(1);
            Assert.AreEqual(resDeal.Status, 1, "status is different");

            rep.Delete(deal);
        }
        [TestMethod]
        public void TestInterestVisitorssRepository()
        {
            IInterestVisitorsRepository rep = new InterestVisitorsRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            InterestVisitor visitor = new InterestVisitor { VisitorID = 1, HotelID = 1, Managementid = 3 };
            rep.Add(visitor);

            visitor.Managementid = 2;
            rep.Update(visitor);

            List<InterestVisitor> players = rep.GetAll();
            Assert.IsNotNull(visitor, "Can't find visitors");

            visitor = rep.GetVisitorByID(1);
            Assert.IsNotNull(visitor, "can't find visitor");

            players = rep.GetVisitorsByManagement(new Management { Managementid = 3 });
            Assert.IsNotNull(visitor, "Can't find visitors");

            rep.Delete(visitor);
        }

        [TestMethod]
        public void Test()
        {
            IUserInfoRepository rep = new UserInfoRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            Userinfo user = new Userinfo { Hash = "567", Login = "567", Permission = 3 };
            rep.Add(user);
        }
    }
}
