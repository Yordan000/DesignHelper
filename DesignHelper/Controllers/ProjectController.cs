using DesignHelper.Contracts;
using DesignHelper.Core.Models.CheckBoxValidation;
using DesignHelper.Core.Models.Project;
using DesignHelper.Extensions;
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
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllProjectsQueryModel query)
        {
            var result = await projectService.All(
                query.Category,
                query.Award,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllProjectsQueryModel.ProjectsPerPage);

            query.TotalProjectsCount = result.TotalProjectsCount;
            query.Categories = await projectService.AllCategoriesNames();
            query.Awards = await projectService.AllAwardsNames();
            query.Projects = result.Projects;

            return View(query);
        }

        public async Task<IActionResult> Favourites()
        {
            IEnumerable<ProjectServiceModel> favourites;
            var userId = User.Id();

            favourites = await projectService.Favourites(userId);

            return View(favourites);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var toolsUsed = await projectService.GetAllTools();


            var model = new ProjectAddViewModel()
            {
                ProjectCategories = await projectService.GetAllCategories(),
                ProjectAwards = await projectService.GetAllAwards(),
                //ProjectTools = new List<CheckBoxItem>()
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

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if ((await projectService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = await projectService.ProjectDetailsById(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await projectService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var project = await projectService.ProjectDetailsById(id);
            var categoryId = await projectService.GetProjectCategoryId(id);
            var awardId = await projectService.GetProjectAwardId(id);

            var model = new ProjectAddViewModel()
            {
                CategoryId = categoryId,
                AwardId = awardId,
                Area = project.Area,
                Author = project.Author,
                Description = project.Description,
                ImageUrl = project.ImageUrl,
                Location = project.Location,
                Rating = project.Rating,
                Title = project.Title,
                ProjectCategories = await projectService.GetAllCategories(),
                ProjectAwards = await projectService.GetAllAwards()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProjectAddViewModel model)
        {
            if (id != model.Id)
            {
                
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await projectService.Exists(model.Id)) == false)
            {
                ModelState.AddModelError("", "Project doesn't exist");
                model.ProjectCategories = await projectService.GetAllCategories();
                model.ProjectAwards = await projectService.GetAllAwards();

                return View(model);
            }

            if ((await projectService.CategoryExists(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
                model.ProjectCategories = await projectService.GetAllCategories();

                return View(model);
            }

            if ((await projectService.AwardExists(model.AwardId)) == false)
            {
                ModelState.AddModelError(nameof(model.AwardId), "Award does not exist");
                model.ProjectAwards = await projectService.GetAllAwards();

                return View(model);
            }

            if (ModelState.IsValid == false)
            {
                model.ProjectCategories = await projectService.GetAllCategories();
                model.ProjectAwards = await projectService.GetAllAwards();

                return View(model);
            }

            await projectService.Edit(model.Id, model);

            return RedirectToAction(nameof(Details), new { model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if ((await projectService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var project = await projectService.ProjectDetailsById(id);
            var model = new ProjectDetailsModel()
            {
                ImageUrl = project.ImageUrl,
                Location = project.Location,
                Title = project.Title
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProjectDetailsViewModel project, int id)
        {
            if ((await projectService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            await projectService.Delete(id);

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavourites(int id)
        {
            if ((await projectService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if (await projectService.IsFavourite(id))
            {
                return RedirectToAction(nameof(All));
            }

            await projectService.AddToFavourites(id, User.Id());

            return RedirectToAction(nameof(Favourites));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavourites(int id)
        {
            if ((await projectService.Exists(id)) == false ||
                (await projectService.IsFavourite(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if ((await projectService.IsFavouriteByUserWithId(id, User.Id())) == false)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            await projectService.RemoveFromFavourite(id);

            return RedirectToAction(nameof(Favourites));
        }
    }
}
