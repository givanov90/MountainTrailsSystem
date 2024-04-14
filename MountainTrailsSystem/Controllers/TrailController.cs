using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Extensions;
using MountainTrailsSystem.Infrastructure.Data.Models;
using MountainTrailsSystem.Core.Models.Trail;

namespace MountainTrailsSystem.Controllers
{
    public class TrailController : BaseController
    {
        private readonly ITrailService trailService;
        private readonly IRegionService regionService;
        private readonly UserManager<ApplicationUser> userManager;

        public TrailController(ITrailService _trailService,
            IRegionService _regionService,
            UserManager<ApplicationUser> _userManager)
        {
            trailService = _trailService;
            regionService = _regionService;
            userManager = _userManager;
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            if (!await trailService.TrailExistsAsync(id))
            {
                return BadRequest();
            }

            var model = await trailService.TrailDetailsByIdAsync(id);

            if (information != model.GetTrailDetails())
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(int id)
        {
            if (!await trailService.TrailExistsAsync(id))
            {
                return BadRequest();
            }

            var userId = userManager.GetUserId(User);

            if (userId == null)
            {
                return Unauthorized();
            }

            await trailService.AddTrailToSavedAsync(userId, id);

            return RedirectToAction(nameof(Saved));
        }

        [HttpGet]
        public async Task<IActionResult> Saved()
        {
            var userId = userManager.GetUserId(User);

            var model = await trailService.AllSavedTrailsByUserIdAsync(userId);
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Unsave(int id)
        {
            if (!await trailService.TrailExistsAsync(id))
            {
                return BadRequest();
            }

            var userId = userManager.GetUserId(User);

            if (userId == null)
            {
                return Unauthorized();
            }

            await trailService.RemoveTrailFromSavedAsync(userId, id);

            return RedirectToAction(nameof(Saved));
        }

        [HttpGet]
        public async Task<IActionResult> Visited()
        {
            var userId = userManager.GetUserId(User);
            var model = await trailService.AllVisitedTrailsByUserIdAsync(userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Visit(int id)
        {
            if (!await trailService.TrailExistsAsync(id))
            {
                return BadRequest();
            }

            var userId = userManager.GetUserId(User);

            if (userId == null)
            {
                return Unauthorized();
            }

            await trailService.AddTrailToVisitedAsync(userId, id);

            return RedirectToAction(nameof(Visited));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Find(TrailSearchFormModel model)
        {
            model.Regions = await regionService.AllRegionsAsync();

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Search(TrailSearchFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var searchedTrails = await trailService.FindTrailsByConditionsAsync(model.RegionId, model.DifficultyLevel, model.Duration, model.Elevation);

            return View(searchedTrails);
        }
    }
}