using System;
using TrasferSystemTests;

namespace TestStart
{
    class Program
    {
        static void Main(string[] args)
        {
            TestTransferSystem r = new TestTransferSystem();
            r.TestAvailableDealsRepository();
            r.TestUserInfoRepository();
            r.TestHotelRepository();
            r.TestVisitorRepository();
            r.TestStatisticsRepository();
            
            r.TestInterestVisitorssRepository();
            Console.WriteLine("D O N E");
        }
    }
}
