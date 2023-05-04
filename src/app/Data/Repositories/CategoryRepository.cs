namespace RecipeBook.Data.Repositories;

using Context;
using Models;

public class CategoryRepository : EfCoreRepository<Category, DatabaseContext>
{
    private readonly DatabaseContext _context;

    public CategoryRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }
}
