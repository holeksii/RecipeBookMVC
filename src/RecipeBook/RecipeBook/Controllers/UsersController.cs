using Microsoft.AspNetCore.Mvc;
using RecipeBook.BLL.Services;

namespace RecipeBook.Controllers;
public class UsersController : Controller
{
    private readonly IUserService _userService;
    private readonly ILogger<UsersController> _logger;

    public UsersController(IUserService userService, ILogger<UsersController> logger)
    {
        _userService = userService;
        _logger = logger;
    }
    [HttpGet("{id}")]
    public ActionResult UserInfo(long id)
    {
        return View("User", _userService.GetUser(id));
    }
}
