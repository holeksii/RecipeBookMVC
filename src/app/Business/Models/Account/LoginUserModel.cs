using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Business.Models;

public class LoginUserModel
{
    [Required(ErrorMessage = "Please, enter your username")]
    [Display(Name = "User Name")]
    public string UserName { get; set; }

    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Remember me")]
    public bool RememberMe { get; set; }
}