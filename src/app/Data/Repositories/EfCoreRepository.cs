namespace RecipeBook.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using Context;

public abstract class EfCoreRepository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : class, IEntity
    where TContext : DatabaseContext
{
    private readonly TContext _context;

    protected EfCoreRepository(TContext context)
    {
        _context = context;
    }

    public virtual TEntity? Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public virtual TEntity? Delete(long id)
    {
        var entity = _context.Set<TEntity>().Find(id);
        if (entity == null)
        {
            return entity;
        }

        _context.Set<TEntity>().Remove(entity!);
        _context.SaveChanges();
        return entity;
    }

    public virtual TEntity? Get(long id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public virtual List<TEntity>? GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    public virtual TEntity? Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
        return entity;
    }
}
