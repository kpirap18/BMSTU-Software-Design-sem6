using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            element.Id = 111;
            db.Userinfos.Add(element);
            db.SaveChanges();
        }
        public List<Userinfo> GetAll()
        {
            IQueryable<Userinfo> users = db.Userinfos;
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
