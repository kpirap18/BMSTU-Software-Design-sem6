#nullable disable

namespace DB
{
    public class InterestVisitor
    {
        public int Id { get; set; }
        public int VisitorID { get; set; }
        public int HotelID { get; set; }
        public int Managementid { get; set; }

        public virtual DB.Management Management { get; set; }
        public virtual DB.Visitor Visitor { get; set; }
        public virtual DB.Hotel Hotel { get; set; }
    }

    
}

