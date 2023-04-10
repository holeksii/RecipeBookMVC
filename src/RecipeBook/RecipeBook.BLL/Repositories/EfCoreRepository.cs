using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeBook.DAL.Data;

namespace RecipeBook.BLL.Repositories
{
    public abstract class EfCoreRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DatabaseContext
    {
        private readonly TContext _context;
        protected EfCoreRepository(TContext context)
        {
            _context = context;
        }
        public TEntity Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public TEntity? Delete(long id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            if (entity == null)
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
            }
            return entity;
        }

        virtual public TEntity? Get(long id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        virtual public List<TEntity>? GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}
