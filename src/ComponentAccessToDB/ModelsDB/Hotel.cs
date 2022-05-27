using System.Collections.Generic;
#nullable disable

namespace DB
{
    public class Hotel
    {
        public int HotelID { get; set; }
        public int Managementid { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Cost { get; set; }
        public int Stars { get; set; }

        public DB.CategHotel CategHotel { get; set; }
        public virtual DB.Management Management { get; set; }
        public virtual ICollection<DB.InterestVisitor> InterestVisitors { get; set; }
        public virtual ICollection<DB.Visitor> Visitors { get; set; }
    }

   
}
