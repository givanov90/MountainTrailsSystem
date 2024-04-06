using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Models;

namespace MountainTrailsSystem.Controllers
{
    public class TrailController : BaseController
    {
        private readonly ITrailService trailService;

        public TrailController(ITrailService _trailService)
        {
            trailService = _trailService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllTrailsQueryModel model)
        {
            var trails = await trailService.AllTrailsAsync(model.CurrentPage);

            model.TotalTrails = trails.TotalTrails;
            model.Trails = trails.Trails;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!await trailService.TrailExistsAsync(id))
            {
                return BadRequest();
            }

            var model = await trailService.TrailDetailsByIdAsync(id);

            return View(model);
        }
    }
}
