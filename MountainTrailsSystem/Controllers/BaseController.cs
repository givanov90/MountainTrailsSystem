using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MountainTrailsSystem.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
