
#nullable disable

namespace DB
{
    public partial class Availabledeal
    {
        public int Id { get; set; }
        public int VisitorID { get; set; }
        public int Tomanagementid { get; set; }
        public int Frommanagementid { get; set; }
        public int Cost { get; set; }
        public int Status { get; set; }

        public virtual DB.Management Frommanagement { get; set; }
        public virtual DB.Visitor Visitor { get; set; }
        public virtual DB.Management Tomanagement { get; set; }
    }

}
