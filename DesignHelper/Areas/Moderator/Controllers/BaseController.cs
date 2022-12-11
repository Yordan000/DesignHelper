using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static DesignHelper.Areas.Moderator.Constrains.ModeratorConstrains;

namespace DesignHelper.Areas.Moderator.Controllers
{
    [Area(ModeratorName)]
    [Route("Moderator/[controller]/[Action]/{id?}")]
    [Authorize(Roles = ModeratorRoleName)]
    public class BaseController : Controller
    {
    }
}
