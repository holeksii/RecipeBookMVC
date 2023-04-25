using RecipeBook.DAL.Models;

namespace RecipeBook.BLL.Models;

public class RecipeModel
{
    public long Id { get; set; }

    public int TimeToCook { get; set; }

    public string Name { get; set; }

    public string? ImageUrl { get; set; }

    public string Category { get; set; }

    public virtual User? User { get; set; }

    public int LikesCount { get; set; }

    public int CommentsCount { get; set; }

    public static RecipeModel mapRecipe(Recipe recipe)
    {
        RecipeModel model = new RecipeModel();
        model.Id = recipe.Id;
        model.Name = recipe.Name;
        model.ImageUrl = recipe.ImageUrl;
        model.Category = recipe.Category.Name;
        model.User = recipe.User;
        model.LikesCount = recipe.Likes.Count;
        model.CommentsCount = recipe.Comments.Count;
        return model;
    }
}
