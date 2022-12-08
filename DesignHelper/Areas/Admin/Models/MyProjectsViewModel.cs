using DesignHelper.Core.Models.Project;

namespace DesignHelper.Areas.Admin.Models
{
    public class MyProjectsViewModel
    {
        public IEnumerable<ProjectServiceModel> AddedProjects { get; set; }
            = new List<ProjectServiceModel>();

        public IEnumerable<ProjectServiceModel> FavouriteProjects { get; set; }
            = new List<ProjectServiceModel>();
    }
}
