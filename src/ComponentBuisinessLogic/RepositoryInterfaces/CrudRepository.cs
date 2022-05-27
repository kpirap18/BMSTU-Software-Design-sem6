using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface CrudRepository<T>
    {
        void Add(T element);
        List<T> GetLimit(int limit);
        void Update(T element);
        void Delete(T element);
    }
}
