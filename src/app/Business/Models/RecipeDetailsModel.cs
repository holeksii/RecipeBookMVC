using RecipeBook.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipeBook.BLL.Models;

public class RecipeDetailsModel
{
    public long Id { get; set; }

    [Range(1, 1000, ErrorMessage =
        "The value must be between 1 and 1000")]
    public int TimeToCook { get; set; }

    [Required]
    [MinLength(3)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MinLength(10)]
    public string Instructions { get; set; } = string.Empty;

    [Url]
    public string? ImageUrl { get; set; }

    [Required]
    public virtual Category? Category { get; set; }

    public virtual User? User { get; set; }

    [Required]
    public List<Ingredient> Ingredients { get; set; }

    public List<Like> Likes { get; set; }

    public List<Comment> Comments { get; set; }

    public static RecipeDetailsModel mapRecipe(Recipe recipe)
    {
        RecipeDetailsModel model = new RecipeDetailsModel();
        model.Id = recipe.Id;
        model.Name = recipe.Name;
        model.User = recipe.User;
        model.ImageUrl = recipe.ImageUrl;
        model.Instructions = recipe.Instructions;
        model.TimeToCook = recipe.TimeToCook;
        model.Category = recipe.Category;
        model.Ingredients = recipe.Ingredients;
        model.Likes = recipe.Likes;
        model.Comments = recipe.Comments;
        return model;
    }
    public static Recipe mapRecipeDetailsModel(RecipeDetailsModel model)
    {
        Recipe recipe = new Recipe();
        recipe.Name = model.Name;
        recipe.User = model.User;
        recipe.ImageUrl = model.ImageUrl;
        recipe.Instructions = model.Instructions;
        recipe.TimeToCook = model.TimeToCook;
        recipe.Category = model.Category;
        recipe.Ingredients = model.Ingredients;
        return recipe;
    }
}
