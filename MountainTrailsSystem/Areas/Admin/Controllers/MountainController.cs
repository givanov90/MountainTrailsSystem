using Microsoft.AspNetCore.Mvc;
using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Models;

namespace MountainTrailsSystem.Areas.Admin.Controllers
{
    public class MountainController : AdminBaseController
    {
        private readonly IMountainService mountainService;
        private readonly IRegionService regionService;

        public MountainController(IMountainService _mountainService,
            IRegionService _regionService)
        {
            mountainService = _mountainService;
            regionService = _regionService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateMountainFormModel();

            model.Regions = await regionService.AllRegionsAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMountainFormModel model)
        {
            if (await mountainService.MountainExistsAsync(model.Name))
            {
                ModelState.AddModelError(nameof(model.Name), "Mountain already exists");
                return View(model);
            }

            await mountainService.CreateMountainAsync(model);

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}