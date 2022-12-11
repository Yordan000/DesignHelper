using Microsoft.AspNetCore.Mvc;

namespace DesignHelper.Areas.Moderator.Controllers
{
    public class ModeratorController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
