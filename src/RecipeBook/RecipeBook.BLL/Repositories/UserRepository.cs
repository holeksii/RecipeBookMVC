using RecipeBook.DAL.Data;
using RecipeBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.BLL.Repositories
{
    public class UserRepository : EfCoreRepository<User, DatabaseContext>
    {
        private readonly DatabaseContext _context;
        public UserRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }



    }
}
