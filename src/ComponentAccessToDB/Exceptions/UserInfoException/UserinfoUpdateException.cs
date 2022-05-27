using System;
using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class UserinfoUpdateException : Exception
    {
        public int UserinfoID;
        public string Login;
        public string Hash;
        public int Permission;
        public UserinfoUpdateException(int UserinfoID,
            string Login,
            string Hash,
            int Permission)
        {
            this.UserinfoID = UserinfoID;
            this.Login = Login;
            this.Hash = Hash;
            this.Permission = Permission;
        }
    }
}
