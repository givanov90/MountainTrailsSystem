using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MountainTrailsSystem.Core.Contracts;
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

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }

            if (statusCode == 404)
            {
                return View("Error404");
            }

            return View();
        }
    }
}