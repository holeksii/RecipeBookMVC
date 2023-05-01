namespace RecipeBook.Web.Controllers;

using Microsoft.AspNetCore.Mvc;
using Business.Services;
using Business.Models;

public class RecipesController : Controller
{
    private readonly IRecipeService _recipeService;
    private readonly ILikeService _likeService;
    private readonly ICommentService _commentService;

    private readonly long _currentId;

    public RecipesController(IRecipeService recipeService, ICommentService commentService,
        ILikeService likeService)
    {
        _recipeService = recipeService;
        _commentService = commentService;
        _likeService = likeService;
        //hardcode as no registration written
        _currentId = 2;
    }

    [HttpGet]
    public IActionResult AllRecipes(string sortingField = "")
    {
        var list = _recipeService.GetAllRecipes();
        return View("Recipes", _recipeService.GetRecipesSortedBy(sortingField, list!));
    }

    [HttpGet("UserRecipes/{id:long}")]
    public IActionResult UserRecipes(long id, string sortingField = "")
    {
        var list = _recipeService.GetUserRecipes(id);
        return View("UserRecipes", _recipeService.GetRecipesSortedBy(sortingField, list!));
    }

    [HttpGet]
    public IActionResult MyRecipes(string sortingField = "")
    {
        var list = _recipeService.GetUserRecipes(_currentId);
        return View("UserRecipes", _recipeService.GetRecipesSortedBy(sortingField, list!));
    }

    [HttpGet]
    public IActionResult LikedRecipes(string sortingField = "")
    {
        var list = _recipeService.GetLikedRecipes(_currentId);
        return View("UserRecipes", _recipeService.GetRecipesSortedBy(sortingField, list!));
    }

    [HttpGet("Recipe/{id:long}")]
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
    public IActionResult AddRecipe(RecipeDetailsDTO recipe)
    {
        _recipeService.AddRecipe(_currentId, recipe);
        return View("Recipe", recipe);
    }

    [HttpPost]
    public IActionResult AddComment(long recipeId, string comment)
    {
        _commentService.AddComment(_currentId, recipeId, comment);
        var recipe = _recipeService.GetRecipe(recipeId);
        return View("Recipe", recipe);
    }

    [HttpPost]
    public IActionResult AddOrDeleteLike(long recipeId)
    {
        if (!_likeService.AddLike(_currentId, recipeId))
        {
            _likeService.DeleteLike(_currentId, recipeId);
        }
        var recipe = _recipeService.GetRecipe(recipeId);
        return View("Recipe", recipe);
    }
}
