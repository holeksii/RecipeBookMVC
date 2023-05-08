using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Business.Models;

public class ForgotPasswordModel
{
    [Required(ErrorMessage = "Please, enter your email")]
    [Display(Name = "Email address")]
    public string Email { get; set; }
}