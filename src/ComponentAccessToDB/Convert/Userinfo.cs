using System;
using System.Collections.Generic;
using BL;
#nullable disable

namespace DB
{
    public partial class UserinfoConv
    {
        public static DB.Userinfo BltoDB(BL.Userinfo a_bl)
        {
            return new DB.Userinfo
            {
                Id = a_bl.Id,
                Login = a_bl.Login,
                Hash = a_bl.Hash,
                Permission = a_bl.Permission
            };
        }

        public static BL.Userinfo DBtoBL(DB.Userinfo a_bl)
        {
            return new BL.Userinfo
            (
                id: a_bl.Id,
                login: a_bl.Login,
                hash: a_bl.Hash,
                per: a_bl.Permission
            );
        }
    }
}
