using RecipeBook.Data.Context;
using RecipeBook.Data.Models;

namespace RecipeBook.Business.Repositories;

public class UserRepository : EfCoreRepository<User, DatabaseContext>
{
    private readonly DatabaseContext _context;

    public UserRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }
}
