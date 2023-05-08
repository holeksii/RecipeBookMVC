﻿using System.Threading.Tasks;
using RecipeBook.Business.Models;
using RecipeBook.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace RecipeBook.Business.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IEmailService _emailService;
    private readonly IConfiguration _configuration;

    public AccountService(UserManager<User> userMenager, SignInManager<User> signInManager,
        IEmailService emailService, IConfiguration configuration)
    {
        _userManager = userMenager;
        _signInManager = signInManager;
        _emailService = emailService;
        _configuration = configuration;
    }

    public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
    {
        var user = new User()
        {
            Email = userModel.Email,
            UserName = userModel.Email,
        };
        var result = await _userManager.CreateAsync(user, userModel.Password);
        if (result.Succeeded)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            if(!string.IsNullOrEmpty(token))
            {
                SendConfirmationEmail(user, token);
            }
        }
        return result;
    }

    public async Task<SignInResult> PasswordLoginAsync(LoginUserModel userModel)
    {
        return await _signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, userModel.RememberMe, false);
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    private void SendConfirmationEmail(User user, string token)
    {
        string appDomain = _configuration.GetSection("Application:AppDomain").Value;
        string link = _configuration.GetSection("Application:EmailConfirmationPath").Value;
        var placeHolders = new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>("{{UserName}}",user.UserName),
            new KeyValuePair<string, string>("{{token}}", string.Format(appDomain + link, user.Id, token))
        };
        _emailService.SendEmail("RecipeBook email confirmation", user.Email,
            "SignUpEmailTemplate", placeHolders);
    }

    public async Task<IdentityResult> ConfirmEmailAsync(string uid, string token)
    {
        return await _userManager.ConfirmEmailAsync(await _userManager.FindByIdAsync(uid), token);
    }
}
