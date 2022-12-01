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

        Task<ProjectQueryServiceModel> All(
            string? category = null,
            string? award = null,
            string? searchTerm = null,
            ProjectSorting sorting = ProjectSorting.Newest,
            int currentPage = 1,
            int housesPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNames();
        Task<IEnumerable<string>> AllAwardsNames();
        Task<IEnumerable<ProjectHomeModel>> LastThreeProjects();


     
    }
}
