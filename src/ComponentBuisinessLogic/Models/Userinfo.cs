using System;
using System.Collections.Generic;

#nullable disable

namespace BL
{
    public class Userinfo
    {
        public Userinfo(int id = 1, string login = "login", string hash = "0000", int per = 1)
        {
            Id = id;
            Login = login;
            Hash = hash;
            Permission = per;
        }

        public int Id { get;  }
        public string Login { get;  }
        public string Hash { get;  }
        public int Permission { get;  }
    }
}
