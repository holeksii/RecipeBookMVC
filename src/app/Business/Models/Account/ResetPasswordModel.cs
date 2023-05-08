using System.ComponentModel.DataAnnotations;

namespace RecipeBook.Business.Models;

public class ResetPasswordModel
{
    [Required]
    public string UserId { get; set; }

    [Required(ErrorMessage = "Please, enter a strong password")]
    [Compare("ConfirmNewPassword", ErrorMessage = "Password does not match")]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; }

    [Required(ErrorMessage = "Please, confirm password")]
    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    public string ConfirmNewPassword { get; set; }

    [Required]
    public string Token { get; set; }

    public bool IsSuccess { get; set; }
}