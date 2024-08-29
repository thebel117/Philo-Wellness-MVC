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
            else
            {
                // Log the validation errors
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage); // Or use a logger
                }
            }

            return View(model);
        }

    }
}
