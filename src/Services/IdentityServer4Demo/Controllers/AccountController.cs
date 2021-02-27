
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using IdentityServer4Demo.Models;

namespace IdentityServer4Demo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Login(string ReturnUrl)
        {
            LoginInput loginInput = new LoginInput
            {
                AllowRememberLogin = true,

                ReturnUrl = ReturnUrl
            };
            return View(loginInput);
        }
        [AllowAnonymous]
        public async Task<IActionResult> LoginPost(LoginInput loginInput)
        {

            var signRes = await _signInManager.PasswordSignInAsync(loginInput.Username, loginInput.Password, loginInput.RememberLogin, false);
            if (signRes.Succeeded)
            {
                return Redirect(loginInput.ReturnUrl);
            }
            else {
                IdentityUser identityUser = new IdentityUser(loginInput.Username);
                var createRes = await _userManager.CreateAsync(identityUser, loginInput.Password);
                if (createRes.Succeeded)
                {
                    await _signInManager.SignInAsync(identityUser, false);
                    return Redirect(loginInput.ReturnUrl);
                }

            }
            return View(loginInput);
        }
    }
}
