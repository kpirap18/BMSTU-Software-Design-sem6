using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;


namespace DB
{
    public class UserInfoRepository : IUserInfoRepository, IDisposable
    {
        private readonly transfersystemContext db;
        public UserInfoRepository(transfersystemContext curDb)
        {
            db = curDb;
        }
        public void Add(BL.Userinfo element)
        {
            DB.Userinfo v = UserinfoConv.BltoDB(element);
            try
            {
                v.Id = db.Userinfos.Count() + 1;
                db.Userinfos.Add(v);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new UserinfoAddException(v.Id, v.Login, v.Hash, v.Permission);
                Console.WriteLine(ex.Message);
            }
        }
        public List<BL.Userinfo> GetLimit(int limit)
        {
            IQueryable<DB.Userinfo> users = db.Userinfos.OrderBy(z => z.Id).Where(z => z.Id < limit);
            List<DB.Userinfo> conv = users.ToList();
            List<BL.Userinfo> final = new List<BL.Userinfo>();
            foreach (var m in conv)
            {
                final.Add(UserinfoConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final : null;
        }
        public void Update(BL.Userinfo element)
        {
            DB.Userinfo v = UserinfoConv.BltoDB(element);
            try
            {
                db.Userinfos.Update(v);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new UserinfoUpdateException(v.Id, v.Login, v.Hash, v.Permission);
                Console.WriteLine(ex.Message);
            }
        }
        public void Delete(BL.Userinfo element)
        {
            DB.Userinfo v = UserinfoConv.BltoDB(element);
            try
            {
                db.Userinfos.Remove(v);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new UserinfoDeleteException(v.Id);
                Console.WriteLine(ex.Message);
            }
        }
        public BL.Userinfo FindUserByLogin(string login)
        {
            IQueryable<DB.Userinfo> users = db.Userinfos.Where(needed => needed.Login == login);
            List<DB.Userinfo> conv = users.ToList();
            List<BL.Userinfo> final = new List<BL.Userinfo>();
            foreach (var m in conv)
            {
                final.Add(UserinfoConv.DBtoBL(m));
            }
            return final.Count() > 0 ? final.First() : null;
        }
        public BL.Userinfo FindUserByID(int id)
        {
            return UserinfoConv.DBtoBL(db.Userinfos.Find(id));
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
