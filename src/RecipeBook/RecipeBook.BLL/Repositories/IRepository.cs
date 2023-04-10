using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeBook.DAL.Data;

namespace RecipeBook.BLL.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        List<T>? GetAll();
        T? Get(long id);
        T Add(T entity);
        T Update(T entity);
        T? Delete(long id);
    }
}
