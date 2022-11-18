using DesignHelper.Contracts;
using DesignHelper.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesignHelper.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService _projectService)
        {
            projectService = _projectService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await projectService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new ProjectAddViewModel()
            {
                
            };
            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Add(ProjectAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await projectService.AddProjectsAsync(model);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong!");
                
                return View(model);
            }
        }

    }
}
