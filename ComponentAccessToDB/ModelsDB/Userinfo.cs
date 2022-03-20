using System;
using System.Collections.Generic;

#nullable disable

namespace ComponentAccessToDB
{
    public partial class Userinfo
    {
        public Userinfo()
        {
            ManagementAnalysists = new HashSet<Management>();
            ManagementManagers = new HashSet<Management>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Hash { get; set; }
        public int Permission { get; set; }

        public virtual ICollection<Management> ManagementAnalysists { get; set; }
        public virtual ICollection<Management> ManagementManagers { get; set; }
    }
}
