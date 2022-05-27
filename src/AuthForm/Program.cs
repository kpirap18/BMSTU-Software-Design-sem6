using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB;
using BL;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AuthForm
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AuthorisationForm());
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
}
