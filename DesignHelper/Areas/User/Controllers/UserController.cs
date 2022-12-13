using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DesignHelper.Areas.User.Controllers
{
    public class UserController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
