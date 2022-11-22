using DesignHelper.Core.Models.Project;

namespace DesignHelper.Contracts
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectCategoryModel>> GetAllCategories();
     
    }
}
