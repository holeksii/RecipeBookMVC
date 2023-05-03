namespace RecipeBook.Web.Controllers;

using Microsoft.AspNetCore.Mvc;
using Business.Services;

public class UsersController : Controller
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public ActionResult UserInfo(string id)
    {
        return View("User", _userService.GetUser(id));
    }
}
