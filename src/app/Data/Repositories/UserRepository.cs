namespace RecipeBook.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using Context;
using Models;

public class UserRepository : EfCoreRepository<User, DatabaseContext>
{
    private readonly DatabaseContext _context;

    public UserRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }

    public new virtual User? Get(long id)
    {
        return _context.Set<User>()
            .Include(u => u.Likes)
            .Include(u => u.Recipes)
            .Include(u => u.Comments)
            .FirstOrDefault(u => u.Id == id);
    }
}
