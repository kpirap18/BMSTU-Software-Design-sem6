using System.Collections.Generic;

#nullable disable

namespace DB
{
    public class Userinfo
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Hash { get; set; }
        public int Permission { get; set; }

        public virtual ICollection<DB.Management> ManagementAnalysists { get; set; }
        public virtual ICollection<DB.Management> ManagementManagers { get; set; }
    }

    
}
