using RecipeBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.BLL.Services
{
    public interface IRecipeService
    {
        public List<Recipe>? GetAllRecipes();
        public List<Recipe>? GetUserRecipes(long id);
        public Recipe GetRecipe(long id);
    }
}
