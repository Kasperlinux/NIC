﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NIC.Models;
using NIC.Models.ViewModel;

namespace NIC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
<<<<<<< HEAD
        [AllowAnonymous]
=======
       
>>>>>>> c395b6a2d4306bc1a16817092014799a2fe91197
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
<<<<<<< HEAD
        [AllowAnonymous]
=======
        
>>>>>>> c395b6a2d4306bc1a16817092014799a2fe91197
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    City = model.City
                };

                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    //if (!string.IsNullOrEmpty(returnUrl))
                    //{
                    //    return LocalRedirect(returnUrl);
                    //}
                    //else
                    //{
                    //    return RedirectToAction("Index", "Home");
                    //}
                    return RedirectToAction("Admin", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
