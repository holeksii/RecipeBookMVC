namespace RecipeBook.Web.Controllers;

using global::Web.DTOs;
using Microsoft.AspNetCore.Mvc;
using Business.Services;
using Business.Models;
using Data.Models;

public class RecipesController : Controller
{
    private readonly IRecipeService _recipeService;
    private readonly ILikeService _likeService;
    private readonly ICommentService _commentService;
    private readonly ICategoryService _categoryService;
    private readonly IIngredientService _ingredientService;

    private readonly string _currentId;

    public RecipesController(IRecipeService recipeService, ICommentService commentService,
        ILikeService likeService, ICategoryService categoryService, IIngredientService ingredientService)
    {
        _recipeService = recipeService;
        _commentService = commentService;
        _likeService = likeService;
        _categoryService = categoryService;
        _ingredientService = ingredientService;
        //hardcode as no registration written
        _currentId = "1e85b391-2a3b-4e4e-94c0-e4a7eea8abf7";
    }

    [HttpGet]
    public IActionResult AllRecipes(string sortingField = "")
    {
        var list = _recipeService.GetAllRecipes();
        return View("Recipes", _recipeService.GetRecipesSortedBy(sortingField, list!));
    }

    [HttpGet("UserRecipes/{id}")]
    public IActionResult UserRecipes(string id, string sortingField = "")
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
        ViewBag.Categories = _categoryService.GetAll();
        /*var recipe = new RecipeDetailsDTO();
        return View("CreateRecipeCategory", recipe);*/
        return View("CreateRecipe");
    }

    [HttpPost]
    public IActionResult AddRecipe(RecipeDetailsDTO recipe)
    {
        var newRecipe = _recipeService.AddRecipe(_currentId, recipe.CategoryId, recipe);
        return View("AddRecipeIngredients", newRecipe);
    }

    [HttpPost]
    public IActionResult AddNewCategory(string name)
    {
        CategoryDTO category = _categoryService.AddNewCategory(name);
        ViewBag.Categories = _categoryService.GetAll();
        return View("CreateRecipe");
    }

    [HttpGet]
    [HttpPost]
    public IActionResult AddIngredient(long recipeId, string name, int quantity, string measure = "")
    {
        _ingredientService.AddIngredient(recipeId, name, quantity, measure);
        RecipeDetailsDTO recipe = _recipeService.GetRecipe(recipeId);
        return View("AddRecipeIngredients", recipe);
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
