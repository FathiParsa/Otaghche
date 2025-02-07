using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Otaghche.Appliaction.Common.Interfaces;
using Otaghche.Appliaction.Common.Utility;
using Otaghche.Domain.Entities;
using Otaghche.Web.ViewModels;

namespace Otaghche.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Login(string returnUrl = null)
        {
            LoginVM loginVM = new()
            {
                RedirectUrl = returnUrl,
            };

            return View(loginVM);
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginVM.Email,
                    loginVM.Password, loginVM.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded) 
                {
                    if (string.IsNullOrEmpty(loginVM.RedirectUrl))
                    {
                        return RedirectToAction("Index" , "Home");
                    }
                    else
                    {
                        return LocalRedirect(loginVM.RedirectUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("" , "خطا در ورود. دوباره امتحان کنید");
                }
            }

            return View(loginVM);
        }




        public async Task<IActionResult> Register()
        {
            if (!await _roleManager.RoleExistsAsync(StaticData.Role_Admin) &&
                !await _roleManager.RoleExistsAsync(StaticData.Role_Customer))
            {
                await _roleManager.CreateAsync(new IdentityRole(StaticData.Role_Admin));
                await _roleManager.CreateAsync(new IdentityRole(StaticData.Role_Customer));
            }

            RegisterVM registerVM = new()
            {
                RolesList = _roleManager.Roles.Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
            };

            return View(registerVM);
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            ApplicationUser user = new()
            {
                Name = registerVM.Name,
                Email = registerVM.Email,
                NormalizedEmail = registerVM.Email.ToUpper(),
                UserName = registerVM.Email,
                PhoneNumber = registerVM.PhoneNumber,
                EmailConfirmed = true,
                CreatedAt = DateTime.Now,
            };

            var result = await _userManager.CreateAsync(user, registerVM.Password);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(registerVM.Role))
                {
                    await _userManager.AddToRoleAsync(user, registerVM.Role);
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, StaticData.Role_Customer);
                }

                await _signInManager.SignInAsync(user, isPersistent: false);

                if(string.IsNullOrEmpty(registerVM.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");   
                }
                else
                {
                    return LocalRedirect(registerVM.ReturnUrl);
                }
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }


            registerVM.RolesList = _roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Name
            });

            return View(registerVM);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
