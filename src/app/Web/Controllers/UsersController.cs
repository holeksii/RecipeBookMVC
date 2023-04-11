namespace RecipeBook.Web.Controllers;

using Microsoft.AspNetCore.Mvc;
using RecipeBook.Business.Services;

public class UsersController : Controller
{
    private readonly IUserService _userService;
    private readonly ILogger<UsersController> _logger;
    private readonly long currentId;

    public UsersController(IUserService userService, ILogger<UsersController> logger)
    {
        _userService = userService;
        _logger = logger;
        //hardcode as no registration written
        currentId = 2;
    }
    [HttpGet("{id}")]
    public ActionResult UserInfo(long id)
    {
        return View("User", _userService.GetUser(id));
    }
}
