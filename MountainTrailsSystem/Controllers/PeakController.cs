using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Core.Enumerations;
using MountainTrailsSystem.Core.Extensions;
using MountainTrailsSystem.Core.Models.Peak;
using MountainTrailsSystem.Infrastructure.Data.Models;

namespace MountainTrailsSystem.Controllers
{
    public class PeakController : BaseController
    {
        private readonly IPeakService peakService;
        private readonly UserManager<ApplicationUser> userManager;

        public PeakController(IPeakService _peakService, UserManager<ApplicationUser> _userManager)
        {
            peakService = _peakService;
            userManager = _userManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllPeaksQueryModel model)
        {
            var peaks = await peakService.AllPeaksAsync(model.CurrentPage);

            model.TotalPeaks = peaks.TotalPeaks;
            model.Peaks = peaks.Peaks;

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> AllTrails(int id, TrailSortCriteria? sortCriteria)
        {
            if (!await peakService.PeakExistsAsync(id))
            {
                return BadRequest();
            }

            var model = await peakService.AllTrailsByPeakIdAsync(id, sortCriteria);

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            if (!await peakService.PeakExistsAsync(id))
            {
                return BadRequest();
            }

            var model = await peakService.PeakDetailsByIdAsync(id);

            if (information != model.GetPeakDetails())
            {
                return BadRequest();
            }

            return View(model);
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Found(string condition)
        {
            var model = await peakService.FindPeaksByConditionAsync(condition);

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Find(PeakSearchConditionFormModel model)
        {
            return View(model);
        }
    }
}