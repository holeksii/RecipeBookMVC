using System.ComponentModel.DataAnnotations;
using RecipeBook.DAL.Models;

namespace RecipeBook.BLL.Models;

public class UserModel
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

    public int RecipesCount { get; set; }

    public int CommentsCount { get; set; }

    public static UserModel mapUser(User user)
    {
        UserModel model = new UserModel();
        model.Id = user.Id;
        model.Username = user.Username;
        model.Email = user.Email;
        model.Password = user.Password;
        model.ImageUrl = user.ImageUrl;
        model.RecipesCount = user.Recipes.Count;
        model.CommentsCount = user.Comments.Count;
        return model;
    }
    public static User mapUserModel(UserModel model)
    {
        User user = new User();
        user.Username = model.Username;
        user.Email = model.Email;
        user.Password = model.Password;
        user.ImageUrl = model.ImageUrl;
        return user;
    }
}
