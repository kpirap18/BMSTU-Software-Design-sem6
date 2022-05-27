using System.Collections.Generic;
#nullable disable

namespace DB
{
    public class CategHotel
    {

        public int CategoryID { get; set; }
        public string TypeCateg { get; set; }

        public virtual ICollection<DB.Hotel> Hotels { get; set; }
    }

   
}
