namespace RecipeBook.Web.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Data.Services;
using RecipeBook.Data.Models;

public class RecipesController : Controller
{
    private readonly IRecipeService _recipeService;
    private readonly ILikeService _likeService;
    private readonly ICommentService _commentService;
    private readonly ILogger<RecipesController> _logger;

    private readonly long currentId;

    public RecipesController(IRecipeService recipeService, ICommentService commentService,
        ILogger<RecipesController> logger, ILikeService likeService)
    {
        _recipeService = recipeService;
        _commentService = commentService;
        _logger = logger;
        _likeService = likeService;
        //hardcode as no registration written
        currentId = 2;
    }

    [HttpGet]
    public IActionResult AllRecipes(string sortingField = "")
    {
        var list = _recipeService.GetAllRecipes();
        return View("Recipes", _recipeService.GetRecipesSortedBy(sortingField, list!));
    }

    [HttpGet("UserRecipes/{id}")]
    public IActionResult UserRecipes(long id, string sortingField = "")
    {
        var list = _recipeService.GetUserRecipes(id);
        return View("UserRecipes", _recipeService.GetRecipesSortedBy(sortingField, list!));
    }

    [HttpGet]
    public IActionResult MyRecipes(string sortingField = "")
    {
        var list = _recipeService.GetUserRecipes(currentId);
        return View("UserRecipes", _recipeService.GetRecipesSortedBy(sortingField, list!));
    }

    [HttpGet]
    public IActionResult LikedRecipes(string sortingField = "")
    {
        var list = _recipeService.GetLikedRecipes(currentId);
        return View("UserRecipes", _recipeService.GetRecipesSortedBy(sortingField, list!));
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
        _recipeService.AddRecipe(currentId, recipe);
        return View("Recipe", recipe);
    }

    [HttpPost]
    public IActionResult AddComment(long recipeId, string comment)
    {
        _commentService.AddComment(currentId, recipeId, comment);
        var recipe = _recipeService.GetRecipe(recipeId);
        return View("Recipe", recipe);
    }

    [HttpPost]
    public IActionResult AddOrDeleteLike(long recipeId)
    {
        _likeService.AddOrDeleteLike(currentId, recipeId);
        var recipe = _recipeService.GetRecipe(recipeId);
        return View("Recipe", recipe);
    }
}
