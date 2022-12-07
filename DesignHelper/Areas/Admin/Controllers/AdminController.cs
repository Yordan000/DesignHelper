using Microsoft.AspNetCore.Mvc;

namespace DesignHelper.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
