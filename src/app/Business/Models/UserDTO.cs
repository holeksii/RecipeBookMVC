using System.ComponentModel.DataAnnotations;
using RecipeBook.Data.Models;

namespace RecipeBook.Business.Models;

public class UserDTO
{
    [Key]
    public string Id { get; set; }

    [Required]
    [MinLength(3)]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Url]
    public string ImageUrl { get; set; } = string.Empty;

    public int RecipesCount { get; set; }

    public int CommentsCount { get; set; }

    public static UserDTO mapUser(User user)
    {
        UserDTO model = new UserDTO();
        model.Id = user.Id;
        model.UserName = user.UserName;
        model.Email = user.Email;
        model.ImageUrl = user.ImageUrl;
        model.RecipesCount = user.Recipes.Count;
        model.CommentsCount = user.Comments.Count;
        return model;
    }
}
