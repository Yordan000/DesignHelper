using DesignHelper.Contracts;
using DesignHelper.Core.Models.CheckBoxValidation;
using DesignHelper.Core.Models.Project;
using DesignHelper.Infrastructure.Data;
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

        public async Task<IActionResult> All([FromQuery] AllProjectsQueryModel query)
        {
            return View(query);
        }

        public async Task<IActionResult> Favourites()
        {
            return View(new AllProjectsQueryModel());
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var toolsUsed = await projectService.GetAllTools();


            var model = new ProjectAddViewModel()
            {
                ProjectCategories = await projectService.GetAllCategories(),
                ProjectAwards = await projectService.GetAllAwards(),
                ProjectTools = toolsUsed.Select(t => new CheckBoxItem()
                {
                    Id = t.Id,
                    Name = t.Name,
                    IsChecked = false
                })
                .ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProjectAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.ProjectCategories = await projectService.GetAllCategories();
                model.ProjectAwards = await projectService.GetAllAwards();

                foreach (var item in model.ProjectTools)
                {
                    
                }
                

                return View(model);
            }

            int id = await projectService.Create(model);

            return RedirectToAction(nameof(Details), new { id });
        }

        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View(new ProjectFormModel());
        }

        public async Task<IActionResult> Edit(int id, ProjectFormModel project)
        {
            return RedirectToAction(nameof(Details), new { id = "1" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(new ProjectDetailsViewModel());
        }

        public async Task<IActionResult> Delete(ProjectDetailsViewModel project)
        {
            return RedirectToAction(nameof(All));
        }
    }
}
