using Microsoft.AspNetCore.Mvc;
using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Extensions;
using MountainTrailsSystem.Core.Models.Trail;

namespace MountainTrailsSystem.Areas.Admin.Controllers
{
    public class TrailController : AdminBaseController
    {
        private readonly ITrailService trailService;
        private readonly IRegionService regionService;
        private readonly IMountainService mountainService;
        private readonly IPeakService peakService;

        public TrailController(ITrailService _trailService,
            IRegionService _regionService,
            IMountainService _mountainService,
            IPeakService _peakService)
        {
            trailService = _trailService;
            regionService = _regionService;
            mountainService = _mountainService;
            peakService = _peakService;
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if (!await trailService.TrailExistsAsync(id))
            {
                return BadRequest();
            }

            var model = await trailService.GetTrailUpdateFormModelAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, TrailUpdateFormModel model)
        {
            if (!await trailService.TrailExistsAsync(id))
            {
                return BadRequest();
            }


            await trailService.UpdateAsync(id, model);

            return RedirectToAction("Details", new { id, information = model.GetTrailDetails(), area = "" });
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateTrailFormModel();

            model.Regions = await regionService.AllRegionsAsync();
            model.Mountains = await mountainService.AllMountainsAsync();
            model.Peaks = await peakService.AllPeaksAsListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTrailFormModel model)
        {
            if (await trailService.TrailByNameExistsAsync(model.Name))
            {
                ModelState.AddModelError(nameof(model.Name), "Trail already exists");
                return View(model);
            }

            await trailService.CreateTrailAsync(model);

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}