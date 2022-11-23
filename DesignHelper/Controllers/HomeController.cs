using DesignHelper.Contracts;
using DesignHelper.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            var model = await projectService.LastThreeProjects();

            return View(model);
        }
    }
}