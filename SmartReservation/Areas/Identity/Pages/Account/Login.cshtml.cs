﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SmartReservation.Model;
using SmartReservation.Interface;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using SmartReservation.Service;

namespace SmartReservation.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ExternalUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IExternalUserRole _externalUserRole;
        private readonly UserManager<ExternalUser> _userManager;

        public LoginModel(SignInManager<ExternalUser> signInManager,
            ILogger<LoginModel> logger,
            IConfiguration configuration, IHttpClientFactory factory, IExternalUserRole externalUserRole, UserManager<ExternalUser> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _externalUserRole = externalUserRole;
            _userManager = userManager;

            new ExternalUserService(configuration, factory);
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public class ParentMenu
        {
            [Required]
            public string Title { get; set; }

            public string Icon { get; set; }
        }

        public class SubMenu
        {
            [Required]
            public string Title { get; set; }

            [Required]
            public string Controller { get; set; }

            public string Action { get; set; }

            public string Role { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = string.Format("/Home/Index");

            if (!ModelState.IsValid) return Page();
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
            ExternalUser userw = new ExternalUser();
            try
            {
                userw = await _userManager.FindByNameAsync(Input.Email);
            }
            catch
            {
                userw = null;
            }

            if (userw == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            var result = await _signInManager.PasswordSignInAsync(userw, Input.Password, Input.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                //Get the users
                var user = await _userManager.FindByNameAsync(Input.Email);
                var roles = await _externalUserRole.GetRolesByUserId(user.ExternalUserID, "Newtryx");
                _logger.LogInformation("User logged in.");
                foreach (var item in roles)
                {
                    if (item.Role == "Admin")
                    {
                        return Redirect(Url.Action("Index", "Home"));
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
            }

            ModelState.AddModelError(string.Empty, "Username / Password is invalid.");
            return Page();

            // If we got this far, something failed, redisplay form
        }
    }
}
