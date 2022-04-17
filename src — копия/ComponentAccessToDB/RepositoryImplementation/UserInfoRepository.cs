using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentBuisinessLogic;


namespace ComponentAccessToDB
{
    public class UserInfoRepository : IUserInfoRepository, IDisposable
    {
        private readonly transfersystemContext db;
        public UserInfoRepository(transfersystemContext curDb)
        {
            db = curDb;
        }
        public void Add(Userinfo element)
        {
            UserinfoDB v = UserinfoConv.BltoDB(element);
            v.Id = db.Userinfos.Count() + 1;
            db.Userinfos.Add(v);
            db.SaveChanges();
        }
        public List<Userinfo> GetLimit(int limit)
        {
            IQueryable<UserinfoDB> users = db.Userinfos.OrderBy(z => z.Id).Where(z => z.Id < limit);
            List<UserinfoDB> conv = users.ToList();
            List<Userinfo> final = new List<Userinfo>();
            foreach (var m in conv)
            {
                final.Add(UserinfoConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final : null;
        }
        public void Update(Userinfo element)
        {
            UserinfoDB v = UserinfoConv.BltoDB(element);
            db.Userinfos.Update(v);
            db.SaveChanges();
        }
        public void Delete(Userinfo element)
        {
            UserinfoDB v = UserinfoConv.BltoDB(element);
            db.Userinfos.Remove(v);
            db.SaveChanges();
        }
        public Userinfo FindUserByLogin(string login)
        {
            IQueryable<UserinfoDB> users = db.Userinfos.Where(needed => needed.Login == login);
            List<UserinfoDB> conv = users.ToList();
            List<Userinfo> final = new List<Userinfo>();
            foreach (var m in conv)
            {
                final.Add(UserinfoConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final.First() : null;
        }
        public Userinfo FindUserByID(int id)
        {
            return UserinfoConv.DBtoBL(db.Userinfos.Find(id));
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
