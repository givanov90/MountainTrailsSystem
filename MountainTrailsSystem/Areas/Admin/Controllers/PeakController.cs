using Microsoft.AspNetCore.Mvc;
using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Models.Peak;

namespace MountainTrailsSystem.Areas.Admin.Controllers
{
    public class PeakController : AdminBaseController
    {
        private readonly IPeakService peakService;
        private readonly IMountainService mountainService;

        public PeakController(IPeakService _peakService,
            IMountainService _mountainService)
        {
            peakService = _peakService;
            mountainService = _mountainService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreatePeakFormModel();

            model.Mountains = await mountainService.AllMountainsAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePeakFormModel model, int peakId)
        {
            if (await peakService.PeakExistsAsync(peakId))
            {
                ModelState.AddModelError(nameof(model.Name), "Peak already exists");
                return View(model);
            }

            await peakService.CreatePeakAsync(model);

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}