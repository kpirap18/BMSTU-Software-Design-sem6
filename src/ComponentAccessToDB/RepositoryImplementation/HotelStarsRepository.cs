using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;


// Так как был добавлен новый столбик "Stars" -- то был создан данный репозиторий
// В БД непосредсвенно был изменен класс Hotel 
// В контроллер был добавлен новый метод
// В UI был добавлен новый пункт для user 
// В  GUI добавлена новая кнопка и ее реализация соответственно 
namespace DB
{
    public class HotelStarsRepository : IHotelStarsRepository, IDisposable
    {
        private readonly transfersystemContext db;
        public HotelStarsRepository(transfersystemContext curDb) 
        {
            db = curDb;
        }
        public List<BL.Hotel> FindHotelByStars(int stars)
        {
            IQueryable<DB.Hotel> hotels = db.Hotels.Where(needed => needed.Stars == stars);
            List<DB.Hotel> conv = hotels.ToList();
            List<BL.Hotel> final = new List<BL.Hotel>();
            foreach (var m in conv)
            {
                final.Add(HotelConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final : null;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
