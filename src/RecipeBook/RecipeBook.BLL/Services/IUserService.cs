using RecipeBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.BLL.Services
{
    public interface IUserService
    {
        public User? GetUser(long id);
    }
}
