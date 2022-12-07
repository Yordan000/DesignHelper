using DesignHelper.Core.Contracts;

namespace DesignHelper.Core.Models.Project
{
    public class ProjectHomeModel : IProjectModel
    {
        public int Id { get; set; }
        public string Title { get; init; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Location { get; init; } = null!;
    }
}
