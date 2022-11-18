using DesignHelper.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DesignHelper.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("All", "Project");
            }
            return View();
        }
    }
}