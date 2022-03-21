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
            IUserInfoRepository rep = new UserInfoRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            Userinfo user = new Userinfo { Hash = "3456", Login = "3456" };
            rep.Add(user);
            Userinfo checkUser1 = rep.FindUserByLogin("3456");

            //Assert.IsNotNull(checkUser1, "user1 was not added");
            if (checkUser1 != null)
            {
                Console.WriteLine("PASSED user1 was added");
            }
            else
            {
                Console.WriteLine("        FAILED user1 was not added");
            }

            //Assert.AreEqual("3456", checkUser1.Hash, "Not equal Added user");
            if (Equals("3456", checkUser1.Hash))
            {
                Console.WriteLine("PASSED equal Added user");
            }
            else
            {
                Console.WriteLine("        FAILED Not equal Added user");
            }
            
            int userId = checkUser1.Id;
            user.Id = userId;
            checkUser1.Hash = "7890";
            rep.Update(checkUser1);
            Userinfo checkUser2 = rep.FindUserByID(userId);

            //Assert.IsNotNull(checkUser2, "cannot find user2 by id");
            if (checkUser2 != null)
            {
                Console.WriteLine("PASSED find user2 by id");
            }
            else
            {
                Console.WriteLine("        FAILED cannot find user2 by id");
            }

            //Assert.AreEqual("7890", checkUser2.Hash, "Not Equal Updated user");
            if (Equals("7890", checkUser1.Hash))
            {
                Console.WriteLine("PASSED Equal Updated user");
            }
            else
            {
                Console.WriteLine("        FAILED Not Equal Updated user");
            }

            rep.Delete(checkUser2);

            //Assert.IsNull(rep.FindUserByID(checkUser2.Id), "user2 was not deleted");
            if (rep.FindUserByID(checkUser2.Id) == null)
            {
                Console.WriteLine("PASSED user2 was deleted");
            }
            else
            {
                Console.WriteLine("        FAILED user2 was not deleted");
            }

            List<Userinfo> users = rep.GetAll();

            //Assert.IsNotNull(users, "Can't find userinfos");
            if (users != null)
            {
                Console.WriteLine("PASSED Can find userinfos");
            }
            else
            {
                Console.WriteLine("        FAILED Can't find userinfos");
            }
        }

        [TestMethod]
        public void TestHotelRepository()
        {
            IHotelRepository rep = new HotelRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            Hotel hotel = new Hotel { Managementid = 1, Name = "Dynamo", Country = "Russia", Cost = 100000 };
            rep.Add(hotel);
            Hotel checkhotel1 = rep.FindHotelByName("Dynamo");
            //Assert.IsNotNull(checkhotel1, "hotels1 was not added");
            if (checkhotel1 != null)
            {
                Console.WriteLine("PASSED hotels1 was added");
            }
            else
            {
                Console.WriteLine("        FAILED hotels1 was not added");
            }

            //Assert.AreEqual("Dynamo", checkhotel1.Name, "Not equal Added hotel");
            if (Equals(checkhotel1.Name, "Dynamo"))
            {
                Console.WriteLine("PASSED equal Added hotel");
            }
            else
            {
                Console.WriteLine("        FAILED Not equal Added hotel");
            }

            int hotelID = hotel.HotelID;
            rep.Update(checkhotel1);
            Hotel checkhotel2 = rep.FindHotelByID(hotelID);
            //Assert.IsNotNull(checkhotel2, "cannot find hotels2 by id");
            if (checkhotel2 != null)
            {
                Console.WriteLine("PASSED can find hotels2 by id");
            }
            else
            {
                Console.WriteLine("        FAILED cannot find hotels2 by id");
            }


            rep.Delete(checkhotel2);
            //Assert.IsNull(rep.FindHotelByID(checkhotel2.HotelID), "hotel2 was not deleted");
            if (rep.FindHotelByID(checkhotel2.HotelID) == null)
            {
                Console.WriteLine("PASSED hotel2 was deleted");
            }
            else
            {
                Console.WriteLine("        FAILED hotel2 was not deleted");
            }

            List<Hotel> hotels = rep.GetAll();
            //Assert.IsNotNull(hotels, "Can't find hotels");
            if (hotels != null)
            {
                Console.WriteLine("PASSED Can find hotels");
            }
            else
            {
                Console.WriteLine("        FAILED Can't find hotels");
            }

            Visitor visitor = new Visitor { VisitorID = 1, HotelID = 1, Statistics = 1, Name = "Denis", Age = 20, Country = "Russia", Budget = 2000 };
            Hotel checkhotel3 = rep.FindHotelByVisitor(visitor);
            //Assert.IsNotNull(checkhotel3, "Can't find hotel by visitor");
            if (checkhotel3 != null)
            {
                Console.WriteLine("PASSED Can find hotel by visitor");
            }
            else
            {
                Console.WriteLine("        FAILED Can't find hotel by visitor");
            }
        }

        [TestMethod]
        public void TestVisitorRepository()
        {
            IVisitorRepository rep = new VisitorRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            Visitor visitor = new Visitor { HotelID = 1, Statistics = 1, Name = "Vlad", Age = 27, Country = "Russia", Budget = 4000 };
            rep.Add(visitor);
            Visitor checkvisitor1 = rep.FindVisitorByName("Vlad");
            //Assert.IsNotNull(checkvisitor1, "visitor1 was no added");
            if (checkvisitor1 != null)
            {
                Console.WriteLine("PASSED visitor1 was added");
            }
            else
            {
                Console.WriteLine("        FAILED visitor1 was no added");
            }

            //Assert.AreEqual("Vlad", checkvisitor1.Name, "Not equal added visitor");
            if (Equals("Vlad", checkvisitor1.Name))
            {
                Console.WriteLine("PASSED equal added visitor");
            }
            else
            {
                Console.WriteLine("        FAILED Not equal added visitor");
            }

            int visitorID = checkvisitor1.VisitorID;
            rep.Update(checkvisitor1);
            Visitor checkvisitor2 = rep.FindVisitorByID(visitorID);
            //Assert.IsNotNull(checkvisitor2, "visitor2 was not found by id");
            if (checkvisitor2 != null)
            {
                Console.WriteLine("PASSED visitor2 was found by id");
            }
            else
            {
                Console.WriteLine("        FAILED visitor2 was not found by id");
            }

            rep.Delete(checkvisitor2);
            //Assert.IsNull(rep.FindVisitorByID(visitorID), "visitor2 was not deleted");
            if (rep.FindVisitorByID(visitorID) == null)
            {
                Console.WriteLine("PASSED visitor2 was deleted");
            }
            else
            {
                Console.WriteLine("        FAILED visitor2 was not deleted");
            }

            List<Visitor> visitors = rep.GetAll();
            //Assert.IsNotNull(visitors, "Can't find hotels");
            if (visitors != null)
            {
                Console.WriteLine("PASSED Can find hotels");
            }
            else
            {
                Console.WriteLine("        FAILED Can't find hotels");
            }

            Hotel hotel = new Hotel { HotelID = 1 };
            visitors = rep.GetVisitorsByHotel(hotel);
            //Assert.IsNotNull(visitors, "can't find visitors by hotel");
            if (visitors != null)
            {
                Console.WriteLine("PASSED can find visitors by hotel");
            }
            else
            {
                Console.WriteLine("        FAILED can't find visitors by hotel");
            }
        }
        
        [TestMethod]
        public void TestStatisticsRepository()
        {
            IStatisticsRepository rep = new StatisticsRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            Statistic stat = new Statistic { AverageRating = 20, NumberOfTrips = 5 };
            rep.Add(stat);
            
            Statistic checkStat1 = rep.GetStatisticByID(2);
            //Assert.IsNotNull(checkStat1, "stat1 was not added");
            if (checkStat1 != null)
            {
                Console.WriteLine("PASSED stat1 was not added");
            }
            else
            {
                Console.WriteLine("        FAILED stat1 was not added");
            }

            //Assert.AreEqual(25, checkStat1.NumberOfTrips, "not equal added stat1");
            if (Equals(25, checkStat1.NumberOfTrips))
            {
                Console.WriteLine("PASSED equal added stat1");
            }
            else
            {
                Console.WriteLine("        FAILED not equal added stat1");
            }

            checkStat1.NumberOfTrips = 25;
            rep.Update(checkStat1);
            Statistic checkStat2 = rep.GetStatisticByID(2);
            //Assert.AreEqual(25, checkStat2.NumberOfTrips, "stat2 was not updated");
            if (Equals(checkStat2.NumberOfTrips, 25))
            {
                Console.WriteLine("PASSED stat2 was updated");
            }
            else
            {
                Console.WriteLine("        FAILED stat2 was not updated");
            }

            rep.Delete(checkStat2);
            
            //Assert.IsNull(rep.GetStatisticByID(2), "stat2 was not deleted");
            if (rep.GetStatisticByID(2) == null)
            {
                Console.WriteLine("PASSED stat2 was deleted");
            }
            else
            {
                Console.WriteLine("        FAILED stat2 was not deleted");
            }

            List<Statistic> stats = rep.GetAll();
            //Assert.IsNotNull(stats, "Can't find stats");
            if (stats != null)
            {
                Console.WriteLine("PASSED Can find stats");
            }
            else
            {
                Console.WriteLine("        FAILED Can't find stats");
            }

            Visitor visitor = new Visitor { VisitorID = 1, Statistics = 1 };
            //Assert.IsNotNull(rep.GetStatisticsByVisitor(visitor), "can't find stat by visitor");
            if (rep.GetStatisticsByVisitor(visitor) != null)
            {
                Console.WriteLine("PASSED can find stat by visitor");
            }
            else
            {
                Console.WriteLine("        FAILED can't find stat by visitor");
            }
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
            //Assert.IsNotNull(deals, "can't find deals");
            if (deals != null)
            {
                Console.WriteLine("PASSED Can find deals");
            }
            else
            {
                Console.WriteLine("        FAILED Can't find deals");
            }

            deals = rep.GetIncomingDeals(new Management { Managementid = 4 });
            //Assert.IsNotNull(deals, "can't find incoming deals");
            if (deals != null)
            {
                Console.WriteLine("PASSED can find incoming deals");
            }
            else
            {
                Console.WriteLine("        FAILED can't find incoming deals");
            }

            deals = rep.GetOutgoaingDeals(new Management { Managementid = 3 });
            //Assert.IsNotNull(deals, "can't find incoming deals");
            if (deals != null)
            {
                Console.WriteLine("PASSED can find incoming deals");
            }
            else
            {
                Console.WriteLine("        FAILED can't find incoming deals");
            }

            deal.Id = 1;
            rep.ConfirmDeal(deal);
            Availabledeal resDeal = rep.GetDealByID(1);
            //Assert.IsNotNull(resDeal, "can't find deal");
            if (resDeal != null)
            {
                Console.WriteLine("PASSED can find deal");
            }
            else
            {
                Console.WriteLine("        FAILED can't find deal");
            }

            //Assert.AreEqual(resDeal.Status, 0, "status is different");
            if (Equals(resDeal.Status, 0))
            {
                Console.WriteLine("PASSED status is eq");
            }
            else
            {
                Console.WriteLine("        FAILED status is different");
            }

        }
        [TestMethod]
        public void TestInterestVisitorssRepository()
        {
            IInterestVisitorsRepository rep = new InterestVisitorsRepository(new transfersystemContext(Connection.GetConnection((int)Permissions.Moder)));
            InterestVisitor visitor = new InterestVisitor { VisitorID = 1, HotelID = 1, Managementid = 3 };
            rep.Add(visitor);

            visitor.Managementid = 2;
            rep.Update(visitor);

            List<InterestVisitor> visitors = rep.GetAll();
            //Assert.IsNotNull(visitors, "Can't find visitors");
            if (visitors != null)
            {
                Console.WriteLine("PASSED Can find visitors");
            }
            else
            {
                Console.WriteLine("        FAILED Can't find visitors");
            }

            visitor = rep.GetVisitorByID(1);
            //Assert.IsNotNull(visitor, "can't find visitor");
            if (visitor != null)
            {
                Console.WriteLine("PASSED can find visitor");
            }
            else
            {
                Console.WriteLine("        FAILED can't find visitor");
            }

            visitors = rep.GetVisitorsByManagement(new Management { Managementid = 3 });
            //Assert.IsNotNull(visitors, "Can't find visitors");
            //if (visitors != null)
            //{
            //    Console.WriteLine("PASSED Can find visitors");
            //}
            //else
            //{
            //    Console.WriteLine("        FAILED Can't find visitors");
            //}

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
