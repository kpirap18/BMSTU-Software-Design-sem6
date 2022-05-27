using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IHotelStarsRepository
    {
        List<Hotel> FindHotelByStars(int stars);
    }
}
