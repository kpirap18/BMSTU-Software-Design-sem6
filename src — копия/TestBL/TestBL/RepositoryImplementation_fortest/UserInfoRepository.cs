using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentBuisinessLogic;

namespace TestBL
{
    public class UserInfoRepository : IUserInfoRepository, IDisposable
    {
        public void Add(Userinfo element)
        {
            return;
        }
        public List<Userinfo> GetAll()
        {
            List<Userinfo> a = new List<Userinfo>();
            return a;
        }
        public void Update(Userinfo element)
        {
            return;
        }
        public void Delete(Userinfo element)
        {
            return;
        }
        public Userinfo FindUserByLogin(string login)
        {
            Userinfo a = new Userinfo();
            return null;
        }
        public Userinfo FindUserByID(int id)
        {
            Userinfo a = new Userinfo();
            return a;
        }
        public void Dispose()
        {
            return;
        }
    }
}
