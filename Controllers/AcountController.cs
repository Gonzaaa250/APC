using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TesisPadel.Areas.Identity.Pages.Account;

    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("/Account/Login")]
        public async Task<IActionResult> Login(RegisterViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return Json(new
                {
                    success = true
                });
            }
            else
            {
                return Json(new
                {
                    success = false,
                    error = "Error"
                });
            }
        }
        [HttpPost]
        [Route("/Account/Register")]

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Json(new { success = true });
                }
                else
                {
                    var errors = result.Errors.Select(e => e.Description);
                    return Json(new { success = false, errors = errors });
                }
            }

            return Json(new { success = false, errors = "Entrada no válida" });
        }
    }
