using RecipeBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.BLL.Services;
public interface IRecipeService
{
    public List<Recipe>? GetAllRecipes();
    public List<Recipe>? GetUserRecipes(long id);
    public List<Recipe>? GetRecipesSortedBy(string field, List<Recipe> list);
    public Recipe? GetRecipe(long id);
    public Recipe AddRecipe(long userId, Recipe recipe);
}
