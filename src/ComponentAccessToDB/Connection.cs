using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentAccessToDB
{
    public enum Permissions : int
    {
        Guest,
        Analytic,
        Manager,
        Moder
    }
    public static class Connection
    {
        public static string GetConnection(int perms)//, IConfiguration config)
        {
            if (perms == (int)Permissions.Guest)
            {
                //return config["Connections:ConnectAsGuest"];
                return "Host=localhost;Port=5432;Database=postgres;Username=guest;Password=1234";
            }
            else if (perms == (int)Permissions.Analytic)
            {
                //return config["Connections:ConnectAsAnalytic"];
                return "Host=localhost;Port=5432;Database=postgres;Username=analytic;Password=1234";
            }
            else if (perms == (int)Permissions.Manager)
            {
                //return config["Connections:ConnectAsManager"];
                return "Host=localhost;Port=5432;Database=postgres;Username=manager;Password=1234";
            }
            else
            {
                //return config["Connections:ConnectAsModer"];
                return "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=1830";
            }
        }
    }
}
