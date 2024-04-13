using Microsoft.AspNetCore.Mvc;
using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Models;

namespace MountainTrailsSystem.Areas.Admin.Controllers
{
    public class StatusNoteController : AdminBaseController
    {
        private readonly IStatusNoteService statusNoteService;

        public StatusNoteController(IStatusNoteService _statusNoteService)
        {
            statusNoteService = _statusNoteService;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await statusNoteService.StatusNoteDetailsByIdAsync(id);

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Resolve(int id)
        {
            if (!await statusNoteService.StatusNoteExistsAsync(id) || await statusNoteService.IsStatusNoteResolvedAsync(id))
            {
                return BadRequest();
            }

            await statusNoteService.ResolveStatusNoteAsync(id);

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpPost]
        public async Task<IActionResult> ResolveUpdate(int id)
        {
            if (!await statusNoteService.StatusNoteExistsAsync(id) || await statusNoteService.IsStatusNoteResolvedAsync(id))
            {
                return BadRequest();
            }

            await statusNoteService.ResolveStatusNoteAsync(id);

            int trailId = await statusNoteService.GetTrailByStatusNoteIdAsync(id);

            return RedirectToAction("Update", "Trail", new { area = "Admin", id = trailId });
        }



        public async Task<IActionResult> All()
        {
            var model = await statusNoteService.AllStatusNotesAsListAsync();

            return View(model);
        }
    }
}
