﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Business.Models;
using RecipeBook.Business.Services;

namespace Web.Controllers;

public class AccountController : Controller
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [Route("signup")]
    public IActionResult SignUp()
    {
        return View();
    }

    [Route("signup")]
    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpUserModel userModel)
    {
        if (ModelState.IsValid)
        {
            var result = await _accountService.CreateUserAsync(userModel);
            if(!result.Succeeded)
            {
                foreach(var errorMessage in result.Errors)
                {
                    ModelState.AddModelError("", errorMessage.Description);
                }
            }
            ModelState.Clear();
        }

        return View("Success");
    }
}
