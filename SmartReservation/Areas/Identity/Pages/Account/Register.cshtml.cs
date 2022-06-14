﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using SmartReservation.Interface;
using SmartReservation.Model;
using SmartReservation.Utils;

namespace SmartReservation.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ExternalUser> _signInManager;
        private readonly UserManager<ExternalUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IExternalUser _externalUser;
        private readonly IExternalUserRole _externalUserRole;

        public RegisterModel(
            UserManager<ExternalUser> userManager,
            SignInManager<ExternalUser> signInManager,
            ILogger<RegisterModel> logger,
            IExternalUser externalUser, IExternalUserRole externalUserRole)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _externalUser = externalUser;
            _externalUserRole = externalUserRole;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }
        public List<Roles> RoleList { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public string EmailExist { get; set; }

        public class InputModel
        {

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PasswordHash { get; set; }
            public string SecurityStamp { get; set; }
            public string PhoneNumber { get; set; }
            public bool PhoneNumberConfirmed { get; set; }
            public string Email { get; set; }
            public bool EmailConfirmed { get; set; }
            public DateTime LockoutEndDateUtc { get; set; }
            public bool LockoutEnabled { get; set; }
            public int AccessFailedCount { get; set; }
            public int CustomerID { get; set; }
            public int RoleID { get; set; }
            public string CustomerText { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            RoleList = await _externalUserRole.GetActiveUserRoles();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = string.Format("ListUsers", "Admin");
            var emailCheck = await _externalUser.CheckIfEmailExist(Input.Email);
            if (emailCheck.FirstName == "True")
            {
                EmailExist = "Please enter a unique email address";
            }
            else
            {
                var user = new ExternalUser();
                user.UserName = Input.Email;
                user.Email = Input.Email;
                user.EmailConfirmed = false;
                user.PhoneNumber = Input.PhoneNumber;
                user.PhoneNumberConfirmed = Input.PhoneNumberConfirmed;
                user.SecurityStamp = null;
                user.AccessFailedCount = 0;
                user.LockoutEnabled = false;
                user.LockoutEndDateUtc = null;
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;
                user.PasswordHash = Security.HashPassword(Input.Password);

                var result = await _externalUser.CreateAsync(user);

                if (result != null)
                {
                    var externalUserRole = new ExternalUserRole
                    {
                        ExternalUserID = Convert.ToInt32(result.ExternalUserID),
                        RoleID = 1,
                        CreatedOn = DateTime.Now,
                        CreatedByUserID = result.ExternalUserID,
                        DeletedByUserID = null,
                        DeletedOn = null
                    };
                    await _externalUserRole.Post(externalUserRole, "Newtyrx");
                    _logger.LogInformation("User created a new account with password.");
                    return Redirect("/Identity/Account/Login");
                }
            }
            return Page();
        }

    }
}
