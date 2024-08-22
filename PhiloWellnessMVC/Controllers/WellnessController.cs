using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhiloWellnessMVC.Services;
using PhiloWellnessMVC.Models.WellnessModels;

namespace PhiloWellnessMVC.Controllers
{
    public class WellnessController : Controller
    {
        private readonly IWellnessService _wellnessService;

        public WellnessController(IWellnessService wellnessService)
        {
            _wellnessService = wellnessService;
        }

        // GET: Wellness/Index
        public async Task<IActionResult> Index()
        {
            var wellnessRatings = await _wellnessService.GetAllWellnessRatingsAsync();
            return View(wellnessRatings);
        }

        // GET: Wellness/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var wellness = await _wellnessService.GetWellnessByIdAsync(id);
            if (wellness == null)
            {
                return NotFound();
            }
            return View(wellness);
        }

        // GET: Wellness/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wellness/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WellnessCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _wellnessService.CreateWellnessAsync(model);
                if (result != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Unable to create wellness entry.");
            }
            return View(model);
        }

        // GET: Wellness/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var wellness = await _wellnessService.GetWellnessByIdAsync(id);
            if (wellness == null)
            {
                return NotFound();
            }
            return View(wellness);
        }

        // POST: Wellness/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(WellnessEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var success = await _wellnessService.UpdateWellnessAsync(model);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Unable to edit wellness entry.");
            }
            return View(model);
        }

        // GET: Wellness/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var wellness = await _wellnessService.GetWellnessByIdAsync(id);
            if (wellness == null)
            {
                return NotFound();
            }
            return View(wellness);
        }

        // POST: Wellness/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _wellnessService.DeleteWellnessAsync(id);
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
