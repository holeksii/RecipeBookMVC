using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Business.Models;

public class LoginUserModel
{
    [Required(ErrorMessage = "Please, enter your email")]
    [Display(Name = "Email address")]
    public string Email { get; set; }

    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Remember me")]
    public bool RememberMe { get; set; }
}