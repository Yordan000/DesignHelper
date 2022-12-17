using DesignHelper.Contracts;
using DesignHelper.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using static DesignHelper.Areas.Admin.Constrains.AdminConstrains;
using static DesignHelper.Areas.Moderator.Constrains.ModeratorConstrains;
using static DesignHelper.Areas.User.Constrains.UserConstrains;

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

            if (User.IsInRole(ModeratorRoleName))
            {
                return RedirectToAction("Index", "Moderator", new { area = "Moderator" });
            }

            if (User.IsInRole(UserRoleName))
            {
                return RedirectToAction("Index", "User", new { area = "User" });
            }

            var model = await projectService.LastThreeProjects();

            return View(model);
        }
       
    }
}