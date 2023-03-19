using System.ComponentModel.DataAnnotations;
using RecipeBookMVC.Models.Builders;

namespace RecipeBookMVC.Models;

public class User
{
    [Key]
    public long Id { get; set; }

    [Required]
    [MinLength(3)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$",
        ErrorMessage = "Password must be between 8 and 15 characters and contain at least one uppercase letter, " +
            "one lowercase letter, one number and one special character")]
    public string Password { get; set; } = "Pa$$w0rd";

    [Url]
    public string ImageUrl { get; set; } = string.Empty;

    public List<Recipe> Recipes { get; set; } = new();

    public List<Like> Likes { get; set; } = new();


    public List<Comment> Comments { get; set; } = new();

    public void AddRecipe(Recipe recipe)
    {
        Recipes.Add(recipe);
    }

    public void RemoveRecipe(Recipe recipe)
    {
        Recipes.Remove(recipe);
    }

    public void AddLike(Like like)
    {
        Likes.Add(like);
    }

    public void RemoveLike(Like like)
    {
        Likes.Remove(like);
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public void RemoveComment(Comment comment)
    {
        Comments.Remove(comment);
    }

    public static UserBuilder CreateBuilder() => new UserBuilder();
}
