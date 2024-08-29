using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhiloWellnessMVC.Services.StudentProfileServices;
using PhiloWellnessMVC.Models.StudentProfileModels;
using PhiloWellnessMVC.Services;

namespace PhiloWellnessMVC.Controllers
{
    public class StudentProfileController : Controller
    {
        private readonly IStudentProfileService _studentProfileService;

        public StudentProfileController(IStudentProfileService studentProfileService)
        {
            _studentProfileService = studentProfileService;
        }

        // GET: StudentProfile/Index
        public async Task<IActionResult> Index()
        {
            var studentProfiles = await _studentProfileService.GetAllStudentProfilesAsync();
            return View(studentProfiles);
        }

        // GET: StudentProfile/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var studentProfile = await _studentProfileService.GetStudentProfileByIdAsync(id);
            if (studentProfile == null)
            {
                return NotFound();
            }
            return View(studentProfile);
        }

        // GET: StudentProfile/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentProfile/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentProfileCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _studentProfileService.CreateStudentProfileAsync(model);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Unable to create student profile.");
            }
            return View(model);
        }

        // GET: StudentProfile/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var studentProfile = await _studentProfileService.GetStudentProfileByIdAsync(id);
            if (studentProfile == null)
            {
                return NotFound();
            }
            return View(studentProfile);
        }

        // POST: StudentProfile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentProfileEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var success = await _studentProfileService.UpdateStudentProfileAsync(model);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Unable to edit student profile.");
            }
            return View(model);
        }

        // GET: StudentProfile/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var studentProfile = await _studentProfileService.GetStudentProfileByIdAsync(id);
            if (studentProfile == null)
            {
                return NotFound();
            }
            return View(studentProfile);
        }

        // POST: StudentProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _studentProfileService.DeleteStudentProfileAsync(id);
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
