using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.BLL.Services;
using RecipeBook.DAL.Models;

namespace RecipeBook.Controllers;
public class RecipesController : Controller
{
    private readonly IRecipeService _recipeService;
    private readonly ILikeService _likeService;
    private readonly ICommentService _commentService;
    private readonly ILogger<RecipesController> _logger;

    public RecipesController(IRecipeService recipeService, ICommentService commentService,
        ILogger<RecipesController> logger, ILikeService likeService)
    {
        _recipeService = recipeService;
        _commentService = commentService;
        _logger = logger;
        _likeService = likeService;
    }

    [HttpGet]
    public IActionResult AllRecipes(string sortingField = "")
    {
        var list = _recipeService.GetAllRecipes();
        return View("Recipes", _recipeService.GetRecipesSortedBy(sortingField, list));
    }

    [HttpGet("UserRecipes/{id}")]
    public IActionResult UserRecipes(long id, string sortingField = "")
    {
        var list = _recipeService.GetUserRecipes(id);
        return View("UserRecipes", _recipeService.GetRecipesSortedBy(sortingField, list));
    }

    [HttpGet("Recipe/{id}")]
    public IActionResult Recipe(long id)
    {
        return View("Recipe", _recipeService.GetRecipe(id));
    }

    [HttpGet]
    public IActionResult CreateRecipe()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddRecipe(Recipe recipe)
    {
        _recipeService.AddRecipe(2, recipe);
        return View("Recipe", recipe);
    }
    [HttpPost]
    public async Task<IActionResult> AddComment(long recipeId, string comment)
    {
        _commentService.AddComment((long)2, (long)recipeId, comment);
        var recipe = _recipeService.GetRecipe(recipeId);
        return View("Recipe", recipe);
    }
    [HttpPost]
    public async Task<IActionResult> AddLike(long recipeId)
    {
        _likeService.AddLike((long)2, (long)recipeId);
        var recipe = _recipeService.GetRecipe(recipeId);
        return View("Recipe", recipe);
    }
}