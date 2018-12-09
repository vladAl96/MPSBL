using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MPSBL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPSBL.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if(!ModelState.IsValid)
            {
                return View(lvm);
            }

            var user = await _userManager.FindByNameAsync(lvm.UserName);

            if(user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, lvm.Password, false, false);
                if(result.Succeeded)
                {
                    if (string.IsNullOrEmpty(lvm.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    return Redirect(lvm.ReturnUrl);     
                }
            }

            ModelState.AddModelError("", "Username/Password not found");
            return View(lvm);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginViewModel lvm)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = lvm.UserName
                };

                var result = await _userManager.CreateAsync(user, lvm.Password);

                if(result.Succeeded)
                {
                    await _signInManager.PasswordSignInAsync(user, lvm.Password, false, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", result.Errors.First().Description);
                }
                
            }
            return View(lvm);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
