using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DB;
using BL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace TechnologicalUI
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var _config = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
            var db = new transfersystemContext(Connection.GetConnection(0, _config));
            IUserInfoRepository rep = new UserInfoRepository(db);
            BL.Userinfo user = rep.FindUserByLogin("admin");
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<Start>();
                    services.AddSingleton(provider => { return user; });
                    DiExtensions.AddRepositoryExtensions(services);
                    DiExtensions.AddControllerExtensions(services);
                    services.AddDbContext<transfersystemContext>(option => option.UseNpgsql(Connection.GetConnection(user.Permission, _config)));

                    var serilogLogger = new LoggerConfiguration()
                        .WriteTo.File("log.txt") // Console()
                        .CreateLogger();
                    services.AddLogging(x =>
                    {
                        x.AddSerilog(logger: serilogLogger, dispose: true);
                    });
                });

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    //var prog = new Start(db);
                    var prog = services.GetRequiredService<Start>();
                    prog.Run();
                    Console.WriteLine("Successfully opened");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Occured");
                }
            }
        }
        
    }
    class Start
    {
        private UserController _user;
        private AnalyticController _analytic;
        private ManagerController _manager;
        private ModeratorController _moderator;
        private transfersystemContext _db;
        //public Start(UserController user, AnalyticController analytic, ManagerController manager, ModeratorController moderator, transfersystemContext db)
        public Start(transfersystemContext db)
        {
            _db = db;
            BL.Userinfo user = new BL.Userinfo();
            IFunctionsRepository funcRep = new FunctionRepository(db);
            IUserInfoRepository userRep = new UserInfoRepository(db);
            IAvailableDealsRepository dealRep = new AvailableDealsRepository(db);
            IVisitorRepository visitorRep = new VisitorRepository(db);
            IHotelRepository hotelRep = new HotelRepository(db);
            IHotelStarsRepository hotelstarsRep = new HotelStarsRepository(db);
            IManagementRepository managementRep = new ManagementRepository(db);
            IInterestVisitorsRepository interestVisitorRep = new InterestVisitorsRepository(db);
            IStatisticsRepository statRep = new StatisticsRepository(db);

            _user = new UserController(user, funcRep, visitorRep, hotelRep, hotelstarsRep, managementRep, interestVisitorRep, statRep);
            _analytic = new AnalyticController(user, funcRep, visitorRep, hotelRep, hotelstarsRep, managementRep, interestVisitorRep, statRep);
            _manager = new ManagerController(user, funcRep, dealRep, visitorRep, hotelRep, hotelstarsRep, managementRep, interestVisitorRep, statRep);
            _moderator = new ModeratorController(user, funcRep, userRep, dealRep, visitorRep, hotelRep, hotelstarsRep, managementRep, interestVisitorRep, statRep);
            _db = db;
            Run();
        }
        public void Run()
        {
            Log.Information("Run at {dateTime}",  DateTime.UtcNow);
            int need = 0;
            while (need != 5)
            {
                PrintMenuMain();
                need = Convert.ToInt32(Console.ReadLine());
                switch (need)
                {
                    case 1:
                        CheckUser();
                        break;
                    case 2:
                        CheckAnalytic();
                        break;
                    case 3:
                        CheckManager();
                        break;
                    case 4:
                        CheckModerator();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Неверный номер");
                        break;
                }
            }
        }
        void PrintMenuMain()
        {
            Console.WriteLine("1 - user\n2 - analytic\n3 - manager\n4 - moderator\n5 - Exit");
        }
        void CheckUser()
        {
            int need = 0;
            while (need != 6)
            {
                Console.WriteLine("1 - Просмотреть всех посетителей\n2 - Получить посетителя по ID\n3 - Просмотреть все" +
               " команды\n4 - Получить отель по ID\n5 - Получить статистику по ID\n6 - Получить все отели определенной категории \n7 - Exit\n");
                need = Convert.ToInt32(Console.ReadLine());
                switch (need)
                {
                    case 1:
                        GetAllVisitors();
                        break;
                    case 2:
                        GetVisitorByID();
                        break;
                    case 3:
                        GetAllHotels();
                        break;
                    case 4:
                        GetHotelByID();
                        break;
                    case 5:
                        GetStatByID();
                        break;
                    case 6:
                        GetHotelByStars();
                        break;
                    case 7:
                        break;
                    default:
                        Console.WriteLine("Неверный номер");
                        break;
                }
            }
        }

        void GetAllVisitors()
        {
            List<BL.Visitor> visitors = _user.GetAllVisitors();
            if (visitors != null)
            {
                foreach (BL.Visitor visitor in visitors)
                {

                    Console.WriteLine(Convert.ToString(visitor.VisitorID) + " " +
                        Convert.ToString(visitor.HotelID) + " " +
                        Convert.ToString(visitor.Statistics) + " " +
                        Convert.ToString(visitor.Name) + " " +
                        Convert.ToString(visitor.Age) + " " +
                        Convert.ToString(visitor.Country) + " " +
                        Convert.ToString(visitor.Budget));
                }
            }
            else
            {
                Console.WriteLine("Посетители не найдены");
            }
        }
        void GetVisitorByID()
        {
            Console.WriteLine("Введите ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            BL.Visitor visitor = _user.FindVisitorByID(id);
            if (visitor != null)
            {
                Console.WriteLine(Convert.ToString(visitor.VisitorID) + " " +
                        Convert.ToString(visitor.HotelID) + " " +
                        Convert.ToString(visitor.Statistics) + " " +
                        Convert.ToString(visitor.Name) + " " +
                        Convert.ToString(visitor.Age) + " " +
                        Convert.ToString(visitor.Country) + " " +
                        Convert.ToString(visitor.Budget));
            }
            else
            {
                Console.WriteLine("Посетитель не найден");
            }
        }
        void GetAllHotels()
        {
            List<BL.Hotel> hotels = _user.GetAllHotels();
            if (hotels != null)
            {
                foreach (BL.Hotel hotel in hotels)
                {
                    Console.WriteLine(Convert.ToString(hotel.HotelID) + " " +
                        Convert.ToString(hotel.Managementid) + " " +
                        Convert.ToString(hotel.Name) + " " +
                        Convert.ToString(hotel.Country) + " " +
                        Convert.ToString(hotel.Cost) + " " +
                        Convert.ToString(hotel.Stars));
                }
            }
            else
            {
                Console.WriteLine("Отели не найдены");
            }
        }

        void GetHotelByStars()
        {
            Console.WriteLine("Введите категорию:");
            int stars = Convert.ToInt32(Console.ReadLine());
            List<BL.Hotel> hotels = _user.GetHotelByStars(stars);  // TODO
            if (hotels != null)
            {
                foreach (BL.Hotel hotel in hotels)
                {
                    Console.WriteLine(Convert.ToString(hotel.HotelID) + " " +
                        Convert.ToString(hotel.Managementid) + " " +
                        Convert.ToString(hotel.Name) + " " +
                        Convert.ToString(hotel.Country) + " " +
                        Convert.ToString(hotel.Cost) + " " +
                        Convert.ToString(hotel.Stars));
                }
            }
            else
            {
                Console.WriteLine("Отели не найдены");
            }
        }

        void GetHotelByID()
        {
            Console.WriteLine("Введите ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            BL.Hotel hotel = _user.FindHotelByID(id);
            if (hotel != null)
            {
                Console.WriteLine(Convert.ToString(hotel.HotelID) + " " +
                        Convert.ToString(hotel.Managementid) + " " +
                        Convert.ToString(hotel.Name) + " " +
                        Convert.ToString(hotel.Country) + " " +
                        Convert.ToString(hotel.Cost));
            }
            else
            {
                Console.WriteLine("Отель не найден");
            }
        }
        void GetStatByID()
        {
            Console.WriteLine("Введите ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            BL.Statistic stat = _user.GetVisitorStatistic(id);
            if (stat != null)
            {
                Console.WriteLine(Convert.ToString(stat.Statisticsid) + " " +
                        Convert.ToString(stat.NumberOfTrips) + " " +
                        Convert.ToString(stat.AverageRating));
            }
            else
            {
                Console.WriteLine("Статистика не найдена");
            }
        }
        void CheckAnalytic()
        {
            int need = 0;
            while (need != 2)
            {
                Console.WriteLine("1 - Просмотреть желаемых посетителей\n2 - Exit");
                need = Convert.ToInt32(Console.ReadLine());
                switch (need)
                {
                    case 1:
                        GetDesiredVisitors();
                        break;
                    case 2:
                        break;
                    default:
                        Console.WriteLine("Неверный номер");
                        break;
                }
            }
        }
        void GetDesiredVisitors()
        {
            List<BL.InterestVisitor> visitors = _analytic.GetAllInterstVisitors();
            if (visitors != null)
            {
                foreach (BL.InterestVisitor visitor in visitors)
                {
                    Console.WriteLine(Convert.ToString(visitor.Id) + " " +
                        Convert.ToString(visitor.VisitorID) + " " +
                        Convert.ToString(visitor.HotelID));
                }
            }
            else
            {
                Console.WriteLine("Посетители не найдены");
            }
        }
        void CheckManager()
        {
            int need = 0;
            while (need != 3)
            {
                Console.WriteLine("1 - Получить входящие сделки\n2 - Получить исходящие сделки\n3 - Exit");
                need = Convert.ToInt32(Console.ReadLine());
                switch (need)
                {
                    case 1:
                        GetIncomingDeals();
                        break;
                    case 2:
                        GetOutcomingDeals();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Неверный номер");
                        break;
                }
            }
        }
        void GetIncomingDeals()
        {
            List<BL.Availabledeal> deals = _manager.GetIncomingDeals();
            if (deals != null)
            {
                foreach (BL.Availabledeal deal in deals)
                {
                    Console.WriteLine(Convert.ToString(deal.Id) + " " +
                        Convert.ToString(deal.VisitorID) + " " +
                        Convert.ToString(deal.Tomanagementid) + " " +
                        Convert.ToString(deal.Frommanagementid) + " " +
                        Convert.ToString(deal.Cost) + " " +
                        Convert.ToString(deal.Status));
                }
            }
            else
            {
                Console.WriteLine("Сделки не найдены");
            }
        }
        void GetOutcomingDeals()
        {
            List<BL.Availabledeal> deals = _manager.GetOutgoaingDeals();
            if (deals != null)
            {
                foreach (BL.Availabledeal deal in deals)
                {
                    Console.WriteLine(Convert.ToString(deal.Id) + " " +
                        Convert.ToString(deal.VisitorID) + " " +
                        Convert.ToString(deal.Tomanagementid) + " " +
                        Convert.ToString(deal.Frommanagementid) + " " +
                        Convert.ToString(deal.Cost) + " " +
                        Convert.ToString(deal.Status));
                }
            }
            else
            {
                Console.WriteLine("Сделки не найдены");
            }
        }
        void CheckModerator()
        {
            int need = 0;
            while (need != 2)
            {
                Console.WriteLine("1 - Просмотреть все сделки\n2 - Exit");
                need = Convert.ToInt32(Console.ReadLine());
                switch (need)
                {
                    case 1:
                        GetAllDeals();
                        break;
                    case 2:
                        break;
                    default:
                        Console.WriteLine("Неверный номер");
                        break;
                }
            }
        }
        void GetAllDeals()
        {
            List<BL.Availabledeal> deals = _moderator.GetAllDeals();
            if (deals != null)
            {
                foreach (BL.Availabledeal deal in deals)
                {
                    Console.WriteLine(Convert.ToString(deal.Id) + " " +
                        Convert.ToString(deal.VisitorID) + " " +
                        Convert.ToString(deal.Tomanagementid) + " " +
                        Convert.ToString(deal.Frommanagementid) + " " +
                        Convert.ToString(deal.Cost) + " " +
                        Convert.ToString(deal.Status));
                }
            }
            else
            {
                Console.WriteLine("Сделки не найдены");
            }
        }
    }
    public static class DiExtensions
    {
        public static void AddRepositoryExtensions(IServiceCollection services)
        {
            services.AddSingleton<IVisitorRepository, VisitorRepository>();
            services.AddSingleton<IHotelRepository, HotelRepository>();
            services.AddSingleton<IUserInfoRepository, UserInfoRepository>();
            services.AddSingleton<IStatisticsRepository, StatisticsRepository>();
            services.AddSingleton<IAvailableDealsRepository, AvailableDealsRepository>();
            services.AddSingleton<IInterestVisitorsRepository, InterestVisitorsRepository>();
            services.AddSingleton<IManagementRepository, ManagementRepository>();
        }
        public static void AddControllerExtensions(IServiceCollection services)
        {
            services.AddScoped<AnalyticController>();
            services.AddScoped<ManagerController>();
            services.AddScoped<ModeratorController>();
            services.AddScoped<UserController>();
        }
    }
}

