using DesignHelper.Core.Models.Project;
using DesignHelper.Infrastructure.Data;

namespace DesignHelper.Contracts
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectCategoryModel>> GetAllCategories();
        Task<IEnumerable<ProjectAwardsModel>> GetAllAwards();
        Task<IEnumerable<ProjectToolsUsedModel>> GetAllTools();
        Task<int> Create(ProjectAddViewModel model);
       
        Task<IEnumerable<ProjectHomeModel>> LastThreeProjects();


     
    }
}
