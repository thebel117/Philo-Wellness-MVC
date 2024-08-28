using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhiloWellnessMVC.Models.UserModels;
using PhiloWellnessMVC.Services;

namespace PhiloWellnessMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var success = await _userService.CreateUserAsync(model);
                if (success)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Unable to create user.");
            }

            return View(model);
        }
    }
}
