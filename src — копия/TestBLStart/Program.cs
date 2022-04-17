using System;
using TestBL;


namespace TestBLStart
    {
    class Program
    {
        static void Main(string[] args)
        {
            TestBusLogic r = new TestBusLogic();
            r.TestUserController();
            r.TestAnalyticController();
            r.TestManagerController();
            r.TestModeratorController();
            Console.WriteLine("D O N E");
        }
    }
}
