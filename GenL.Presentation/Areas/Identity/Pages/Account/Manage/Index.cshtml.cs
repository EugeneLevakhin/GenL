// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using GenL.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GenL.Presentation.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;

        public IndexModel(
            UserManager<UserEntity> userManager,
            SignInManager<UserEntity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

			[Required]
			[Display(Name = "UserName")]
			public string UserName { get; set; }

			//[Required]
			//[EmailAddress]
			//[Display(Name = "Email")]
			//public string Email { get; set; }

			[Display(Name = "First name")]
			public string FirstName { get; set; }

			[Display(Name = "Last name")]
			public string LastName { get; set; }
		}

        private async Task LoadAsync(UserEntity user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var email = await _userManager.GetEmailAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                UserName = userName,
                //Email = email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            if (user.UserName != Input.UserName)
            {
				var userWithSameUserName = await _userManager.FindByNameAsync(Input.UserName);
				if (userWithSameUserName != null)
				{
					ModelState.AddModelError("UserName", $"UserName '{Input.UserName}' is already taken.");
					return RedirectToPage();
				}
			}

			//if (user.Email != Input.Email)
			//{
			//	var userWithSameEmail = await _userManager.FindByEmailAsync(Input.Email);
			//	if (userWithSameEmail != null)
			//	{
			//		ModelState.AddModelError("Email", $"Email '{Input.Email}' is already taken.");
			//	}
			//}

			var setUserNameResult = await _userManager.SetUserNameAsync(user, Input.UserName);
			if (!setUserNameResult.Succeeded)
			{
				ModelState.AddModelError("UserName", "User name change error");
				return RedirectToPage();
			}

			//var setEmailResult = await _userManager.SetEmailAsync(user, Input.Email);
			//if (!setEmailResult.Succeeded)
			//{
			//	ModelState.AddModelError("Email", "Email change error");

			//	// ToDo : 
			//	//StatusMessage = "<strong>Verify your new email</strong><br/><br/>" +
			//	//    "We sent an email to " + Input.Email +
			//	//    " to verify your address. Please click the link in that email to continue.";
			//}

			var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            if (user.FirstName != Input.FirstName)
            {
                user.FirstName = Input.FirstName;
			}

			if (user.LastName != Input.LastName)
			{
				user.LastName = Input.LastName;
			}

            await _userManager.UpdateAsync(user);
			await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}