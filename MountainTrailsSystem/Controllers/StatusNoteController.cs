using Microsoft.AspNetCore.Mvc;
using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Models.StatusNote;

namespace MountainTrailsSystem.Controllers
{
    public class StatusNoteController : BaseController
    {
        private readonly IStatusNoteService statusNoteService;
        private readonly ITrailService trailService;

        public StatusNoteController(IStatusNoteService _statusNoteService,
            ITrailService _trailService)
        {
            statusNoteService = _statusNoteService;
            trailService = _trailService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Report()
        {
            var model = new TrailStatusNoteViewModel();

            model.Trails = await trailService.AllTrailsAsListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Report(TrailStatusNoteViewModel model)
        {
            if (!await trailService.TrailExistsAsync(model.TrailId))
            {
                ModelState.AddModelError(nameof(model.TrailId), "Trail does not exists");
                return View(model);
            }

            await statusNoteService.CreateStatusNoteAsync(model);

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
