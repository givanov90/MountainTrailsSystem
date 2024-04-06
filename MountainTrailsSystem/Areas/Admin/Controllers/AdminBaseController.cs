using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static MountainTrailsSystem.Core.Constants.RoleConstants;

namespace MountainTrailsSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdministratorRole)]
    public class AdminBaseController : Controller
    {
    }
}