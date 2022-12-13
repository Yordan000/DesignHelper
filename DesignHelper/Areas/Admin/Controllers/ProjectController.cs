using DesignHelper.Areas.Admin.Models;
using DesignHelper.Contracts;
using DesignHelper.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DesignHelper.Areas.Admin.Controllers
{
    public class ProjectController : BaseController
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService _projectService)
        {
            projectService = _projectService;
        }

        public async Task<IActionResult> Favourites()
        {
            var myProjects = new MyProjectsViewModel();
            var adminId = User.Id();

            myProjects.FavouriteProjects = await projectService.Favourites(adminId);

            myProjects.AddedProjects = await projectService.AllProjectsByUserId(adminId);

            myProjects.ProjectsAddedByModerator = await projectService.AllProjectsByModeratorId();

            return View(myProjects);
        }
    }
}
