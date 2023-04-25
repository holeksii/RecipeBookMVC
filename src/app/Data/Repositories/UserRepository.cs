using Microsoft.EntityFrameworkCore;
using RecipeBook.Data.Context;
using RecipeBook.Data.Models;

namespace RecipeBook.Data.Repositories;

public class UserRepository : EfCoreRepository<User, DatabaseContext>
{
    private readonly DatabaseContext _context;

    public UserRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }

    public UserRepository() : this(new DatabaseContext())
    {
    }

    public virtual new User? Get(long id)
    {
        return _context.Set<User>().Include(u => u.Likes).Include(u => u.Recipes).
            Include(u => u.Comments).FirstOrDefault(u => u.Id == id);
    }
}
