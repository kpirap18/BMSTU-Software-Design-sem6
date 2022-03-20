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
                Console.WriteLine("Connections:ConnectAsGuest");
                //return config["Connections:ConnectAsGuest"];
                return "Connections:ConnectAsGuest";
            }
            else if (perms == (int)Permissions.Analytic)
            {
                Console.WriteLine("Connections:ConnectAsAnalytic");
                //return config["Connections:ConnectAsAnalytic"];
                return "Connections:ConnectAsAnalytic";
            }
            else if (perms == (int)Permissions.Manager)
            {
                Console.WriteLine("Connections:ConnectAsManager");
                //return config["Connections:ConnectAsManager"];
                return "Connections:ConnectAsManager";
            }
            else
            {
                Console.WriteLine("Connections:ConnectAsModer");
                //return config["Connections:ConnectAsModer"];
                return "Connections:ConnectAsModer";
            }
        }
    }
}
