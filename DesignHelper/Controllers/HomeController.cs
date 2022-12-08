using DesignHelper.Contracts;
using Microsoft.AspNetCore.Mvc;
using static DesignHelper.Areas.Admin.Constrains.AdminConstrains;

namespace DesignHelper.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectService projectService;

        public HomeController(IProjectService _projectService)
        {
            projectService = _projectService;
        }
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(AdminRoleName))
            {
                return RedirectToAction("Index", "Admin" , new { area = "Admin" });
            }

            var model = await projectService.LastThreeProjects();

            return View(model);
        }
    }
}