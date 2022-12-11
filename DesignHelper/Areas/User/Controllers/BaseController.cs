using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static DesignHelper.Areas.User.Constrains.UserConstrains;

namespace DesignHelper.Areas.User.Controllers
{
    [Area(UserName)]
    [Route("User/[controller]/[Action]/{id?}")]
    [Authorize(Roles = UserRoleName)]
    public class BaseController : Controller
    {
        
    }
}
