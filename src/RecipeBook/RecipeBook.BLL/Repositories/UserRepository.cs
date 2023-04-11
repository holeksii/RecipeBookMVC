using RecipeBook.DAL.Data;
using RecipeBook.DAL.Models;

namespace RecipeBook.BLL.Repositories;
public class UserRepository : EfCoreRepository<User, DatabaseContext>
{
    private readonly DatabaseContext _context;
    public UserRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }
}
