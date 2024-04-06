using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MountainTrailsSystem.Core.Contracts;
using MountainTrailsSystem.Models;
using System.Diagnostics;

namespace MountainTrailsSystem.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ITrailService trailService;

        public HomeController(ITrailService _trailService)
        {
            trailService = _trailService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await trailService.LastThreeTrailsAsync();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}