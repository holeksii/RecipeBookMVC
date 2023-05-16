namespace RecipeBook.Web.Controllers;

using Microsoft.AspNetCore.Mvc;
using Business.Services;
using Microsoft.AspNetCore.Authorization;

public class UsersController : Controller
{
    private readonly IUserService _userService;
    private readonly IContextService _contextService;

    public UsersController(IUserService userService, IContextService contextService)
    {
        _userService = userService;
        _contextService = contextService;
    }

    [Authorize]
    [HttpGet("{id}")]
    public ActionResult UserInfo(string id)
    {
        return View("UserInfo", _userService.GetUser(id));
    }

    [Authorize]
    [HttpGet("MyAccount")]
    public ActionResult MyAccount()
    {
        string _currentId = _contextService.GetUserId();
        return View("UserInfo", _userService.GetUser(_currentId));
    }
}
