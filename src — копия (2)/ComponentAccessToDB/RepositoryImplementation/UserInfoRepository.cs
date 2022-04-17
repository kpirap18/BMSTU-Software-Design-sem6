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
            element = new Userinfo(id: db.Userinfos.Count() + 1,
                                   login: element.Login,
                                   hash: element.Hash,
                                   per: element.Permission);
           // element.Id = db.Userinfos.Count() + 1;
            db.Userinfos.Add(element);
            db.SaveChanges();
        }
        public List<Userinfo> GetLimit(int limit)
        {
            IQueryable<Userinfo> users = db.Userinfos.OrderBy(z => z.Id).Where(z => z.Id < limit);
            return users.Count() > 0 ? users.ToList() : null;
        }
        public void Update(Userinfo element)
        {
            db.Userinfos.Update(element);
            db.SaveChanges();
        }
        public void Delete(Userinfo element)
        {
            db.Userinfos.Remove(element);
            db.SaveChanges();
        }
        public Userinfo FindUserByLogin(string login)
        {
            IQueryable<Userinfo> users = db.Userinfos.Where(needed => needed.Login == login);
            return users.Count() > 0 ? users.First() : null;
        }
        public Userinfo FindUserByID(int id)
        {
            return db.Userinfos.Find(id);
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
