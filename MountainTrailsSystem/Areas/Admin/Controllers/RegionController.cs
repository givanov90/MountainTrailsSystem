using Microsoft.AspNetCore.Mvc;
using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Models;

namespace MountainTrailsSystem.Areas.Admin.Controllers
{
    public class RegionController : AdminBaseController
    {
        private readonly IRegionService regionService;
        private readonly IMountainService mountainService;

        public RegionController(IRegionService _regionService,
            IMountainService _mountainService)
        {
            regionService = _regionService;
            mountainService = _mountainService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateRegionFormModel();

            model.Mountains = await mountainService.AllMountainsAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRegionFormModel model)
        {
            if (await regionService.RegionExistsAsync(model.Name))
            {
                ModelState.AddModelError(nameof(model.Name), "Region already exists");
                return View(model);
            }

            await regionService.CreateRegionAsync(model);

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}