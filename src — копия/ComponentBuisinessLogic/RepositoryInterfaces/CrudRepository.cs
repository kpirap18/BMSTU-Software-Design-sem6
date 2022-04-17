using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentBuisinessLogic
{
    public interface CrudRepository<T>
    {
        void Add(T element);
        List<T> GetAll();
        void Update(T element);
        void Delete(T element);
    }
}
