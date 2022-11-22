using DesignHelper.Contracts;
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
    }
}
