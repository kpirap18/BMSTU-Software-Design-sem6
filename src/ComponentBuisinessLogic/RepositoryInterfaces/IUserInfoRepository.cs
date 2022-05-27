using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IUserInfoRepository : CrudRepository<Userinfo>
    {
        Userinfo FindUserByLogin(string login);
        Userinfo FindUserByID(int id);
    }
}
