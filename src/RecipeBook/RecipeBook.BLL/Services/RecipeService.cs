using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeBook.BLL.Repositories;
using RecipeBook.DAL.Models;

namespace RecipeBook.BLL.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly RecipeRepository repository;
        public RecipeService(RecipeRepository recipeRepository)
        {
            repository = recipeRepository;
        }
        public List<Recipe>? GetAllRecipes()
        {
            return repository.GetAll();
        }
        public List<Recipe>? GetUserRecipes(long id)
        {
            return repository.GetUserRecipes(id);
        }
        public Recipe GetRecipe(long id)
        {
            return repository.Get(id);
        }
    }
}
