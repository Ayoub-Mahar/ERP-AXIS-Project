using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ERP.DataAccess.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace ERP.Controllers
{
    public class AccountController : Controller
    {
        #region Declaration-of-Role-Manager-and-User-Manager-that-can-fetch-all-details-of-user-and-its-role-in constructor
        public UserManager<ApplicationUser > ObjUserManager;
        public SignInManager<ApplicationUser> ObjSignInManager;
        public AccountController(UserManager<ApplicationUser> _objUserManager,SignInManager<ApplicationUser> _objSignInManager)
        {
            ObjUserManager = _objUserManager;
            ObjSignInManager = _objSignInManager;
            
        }
        #endregion

        #region Logout-and-redirect-to-login
        [HttpPost]
        public async Task<IActionResult> Logout(RegisterUserVM objmodel)
        {
            await ObjSignInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        #endregion 
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LogInVM objmodel,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await ObjSignInManager .PasswordSignInAsync(objmodel.UserName , objmodel.Password,objmodel.RememberMe ,false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl)  )
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("create", "level1");
                    }
                }
                    ModelState.AddModelError(string.Empty, "Invalid Login");
                
            }
            return View(objmodel);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM  objmodel)
        {
            if (ModelState.IsValid)
            {
                var user = await ObjUserManager.FindByEmailAsync(objmodel.Email);
                if (user != null && await ObjUserManager.IsEmailConfirmedAsync (user))
                {
                    var tokenv = await ObjUserManager.GeneratePasswordResetTokenAsync(user);

                    var passwordresetlink = Url.Action("ResetPassword", "Account",
                        new { email = objmodel.Email, token = tokenv, Request.Scheme });
                 

                    // Send the user to Forgot Password Confirmation view
                    return View("ForgotPasswordConfirmation");
                }
                return View("ForgotPasswordConfirmation");

            }
            return View(objmodel);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            // If password reset token or email is null, most likely the
            // user tried to tamper the password reset link
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = await ObjUserManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    // reset the user password
                    var result = await ObjUserManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return View("ResetPasswordConfirmation");
                    }
                    // Display validation errors. For example, password reset token already
                    // used to change the password or password complexity rules not met
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }

                // To avoid account enumeration and brute force attacks, don't
                // reveal that the user does not exist
                return View("ResetPasswordConfirmation");
            }
            // Display validation errors if model state is not valid
            return View(model);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await ObjUserManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("Login");
                }

                // ChangePasswordAsync changes the user password
                var result = await ObjUserManager.ChangePasswordAsync(user,
                    model.CurrentPassword, model.NewPassword);

                // The new password did not meet the complexity rules or
                // the current password is incorrect. Add these errors to
                // the ModelState and rerender ChangePassword view
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }

                // Upon successfully changing the password refresh sign-in cookie
                await ObjSignInManager.RefreshSignInAsync(user);
                return View("ChangePasswordConfirmation");
            }

            return View(model);
        }
    }
}