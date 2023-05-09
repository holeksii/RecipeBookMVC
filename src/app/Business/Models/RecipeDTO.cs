using RecipeBook.Data.Models;

namespace RecipeBook.Business.Models;

public class RecipeDTO
{
    public long Id { get; set; }

    public int TimeToCook { get; set; }

    public string Name { get; set; }

    public string? ImageUrl { get; set; }

    public string Category { get; set; }

    public virtual User? User { get; set; }

    public int LikesCount { get; set; }

    public int CommentsCount { get; set; }

    public static RecipeDTO mapRecipe(Recipe recipe)
    {
        RecipeDTO model = new RecipeDTO();
        model.Id = recipe.Id;
        model.Name = recipe.Name;
        model.ImageUrl = recipe.ImageUrl;
        model.Category = recipe.Category.Name;
        model.User = recipe.User;
        model.LikesCount = recipe.Likes.Count;
        model.CommentsCount = recipe.Comments.Count;
        model.TimeToCook = recipe.TimeToCook;
        return model;
    }
}
