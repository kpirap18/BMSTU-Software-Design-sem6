using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;


namespace DB
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
        public static string GetConnection(int perms, IConfiguration config)
        {
            if (perms == (int)Permissions.Guest)
            {
                return config["Connections:ConnectAsGuest"];
            }
            else if (perms == (int)Permissions.Analytic)
            {
                return config["Connections:ConnectAsAnalytic"];
            }
            else if (perms == (int)Permissions.Manager)
            {
                return config["Connections:ConnectAsManager"];
            }
            else
            {
                return config["Connections:ConnectAsModer"];
            }
        }
    }
}
