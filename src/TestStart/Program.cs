using System;
using TrasferSystemTests;

namespace TestStart
{
    class Program
    {
        static void Main(string[] args)
        {
            TestTransferSystem r = new TestTransferSystem();
            r.TestUserInfoRepository();
            r.TestHotelRepository();
            r.TestVisitorRepository();
            r.TestStatisticsRepository();
            r.TestAvailableDealsRepository();
            r.TestInterestVisitorssRepository();
            Console.WriteLine("D O N E");
        }
    }
}
