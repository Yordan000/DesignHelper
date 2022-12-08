using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static DesignHelper.Areas.Admin.Constrains.AdminConstrains;

namespace DesignHelper.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Route("Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = AdminRoleName)]
    public class BaseController : Controller
    {
        
    }
}
