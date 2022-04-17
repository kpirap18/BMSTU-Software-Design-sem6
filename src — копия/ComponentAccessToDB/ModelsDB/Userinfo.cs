using System;
using System.Collections.Generic;
using ComponentBuisinessLogic;
#nullable disable

namespace ComponentAccessToDB
{
    public partial class UserinfoDB
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Hash { get; set; }
        public int Permission { get; set; }

        public virtual ICollection<ManagementDB> ManagementAnalysists { get; set; }
        public virtual ICollection<ManagementDB> ManagementManagers { get; set; }
    }

    public partial class UserinfoConv
    {
        public static UserinfoDB BltoDB(Userinfo a_bl)
        {
            return new UserinfoDB
            {
                Id = a_bl.Id,
                Login = a_bl.Login,
                Hash = a_bl.Hash,
                Permission = a_bl.Permission
            };
        }

        public static Userinfo DBtoBL(UserinfoDB a_bl)
        {
            return new Userinfo
            (
                id: a_bl.Id,
                login: a_bl.Login,
                hash: a_bl.Hash,
                per: a_bl.Permission
            );
        }
    }
}
