using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelerBlog.Entity.Interfaces
{
    public interface ICrud<T>
    {
        string Add(T entity);
        T Get(int id);
        List<T> GetAll();
        string Update(T entity, int id);

        string Delete(int id);

    }
}
