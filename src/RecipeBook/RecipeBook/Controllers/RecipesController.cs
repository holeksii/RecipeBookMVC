using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.BLL.Services;

namespace RecipeBook.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeService _recipeService;
        private readonly ILogger<RecipesController> _logger;

        public RecipesController(IRecipeService recipeService, ILogger<RecipesController> logger)
        {
            _recipeService = recipeService;
            _logger = logger;
        }

        /// <summary>
        /// GET: RecipesController/Create
        /// </summary>
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AllRecipes()
        {
            return View("Recipes", _recipeService.GetAllRecipes());
        }

        [HttpGet("Autor/{id}")]
        public IActionResult UserRecipes(long id)
        {
            return View("Recipes", _recipeService.GetUserRecipes(id));
        }

        [HttpGet("Recipe/{id}")]
        public IActionResult Recipe(long id)
        {
            return View(_recipeService.GetRecipe(id));
        }
    }
}
