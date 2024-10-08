using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhiloWellnessMVC.Services;
using PhiloWellnessMVC.Models.VisitModels;
using PhiloWellnessMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace PhiloWellnessMVC.Controllers
{
    public class VisitController : Controller
    {
        private readonly IVisitService _visitService;
        private readonly PhiloWellnessDbContext _context; // Add this line

        public VisitController(IVisitService visitService, PhiloWellnessDbContext context) // Inject context here
        {
            _visitService = visitService;
            _context = context; // Set the context here
        }

        // GET: Visit/Index
        public async Task<IActionResult> Index()
        {
            var visits = await _visitService.GetAllVisitsAsync();
            return View(visits);
        }

        // GET: Visit/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var visit = await _visitService.GetVisitByIdAsync(id);
            if (visit == null)
            {
                return NotFound();
            }
            return View(visit);
        }

        // GET: Visit/Create
        public IActionResult Create()
        {
            // Populate ViewBag.Users with the list of users
            ViewBag.Users = _context.Users
                .Select(u => new { u.UserId })
                .ToList();

            return View();
        }

        // POST: Visit/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VisitCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _visitService.CreateVisitAsync(model);
                if (result != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Unable to create visit.");
            }

            // Populate ViewBag.Users in case of a validation error or failure to create visit
            ViewBag.Users = _context.Users
                .Select(u => new { u.UserId})
                .ToList();

            return View(model);
        }

        // GET: Visit/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var visit = await _visitService.GetVisitByIdAsync(id);
            if (visit == null)
            {
                return NotFound();
            }
            return View(visit);
        }

        // POST: Visit/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VisitEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var success = await _visitService.UpdateVisitAsync(model);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Unable to edit visit.");
            }
            return View(model);
        }

        // GET: Visit/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var visit = await _visitService.GetVisitByIdAsync(id);
            if (visit == null)
            {
                return NotFound();
            }
            return View(visit);
        }

        // POST: Visit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _visitService.DeleteVisitAsync(id);
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
