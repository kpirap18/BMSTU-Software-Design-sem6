using System;
using System.Collections.Generic;

#nullable disable

namespace ComponentBuisinessLogic
{
    public partial class Userinfo
    {
        public Userinfo(int id = 1, string login = "login", string hash = "0000", int per = 1)
        {
            Id = id;
            Login = login;
            Hash = hash;
            Permission = per;
            ManagementAnalysists = new HashSet<Management>();
            ManagementManagers = new HashSet<Management>();
        }

        public int Id { get;  }
        public string Login { get;  }
        public string Hash { get;  }
        public int Permission { get;  }

        public virtual ICollection<Management> ManagementAnalysists { get;  }
        public virtual ICollection<Management> ManagementManagers { get;  }
    }
}
