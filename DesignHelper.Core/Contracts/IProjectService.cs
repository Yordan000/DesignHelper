using DesignHelper.Core.Models.Project;
using DesignHelper.Infrastructure.Data;

namespace DesignHelper.Contracts
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectCategoryModel>> GetAllCategories();

        Task<IEnumerable<ProjectAwardsModel>> GetAllAwards();

        Task<IEnumerable<ProjectToolsUsedModel>> GetAllTools();

        Task<int> Create(ProjectAddViewModel model , string userId);

        Task<ProjectQueryServiceModel> All(
            string? category = null,
            string? award = null,
            string? searchTerm = null,
            ProjectSorting sorting = ProjectSorting.Newest,
            int currentPage = 1,
            int projectsPerPage = 1);

        Task<ProjectQueryServiceModel> TopRatedProjects();

        Task<IEnumerable<string>> AllCategoriesNames();

        Task<IEnumerable<string>> AllAwardsNames();

        Task<IEnumerable<string>> AllToolsUsedNames();

        Task<IEnumerable<ProjectHomeModel>> LastThreeProjects();

        Task<IEnumerable<ProjectServiceModel>> Favourites(string userId); 
        
        Task<bool> IsFavourite(int projectId, string userId);

        Task<ProjectDetailsViewModel> ProjectDetailsById(int id);

        Task<bool> IsFavouriteByUserWithId(int projectId, string currentUserId);

        Task AddToFavourites(int projectId, string currentUserId);

        Task RemoveFromFavourite(int projectId, string userId);

        Task<bool> Exists(int id);

        Task Delete(int projectId);

        Task Edit(int projectId, ProjectAddViewModel model);

        Task<int> GetProjectCategoryId(int projectId);

        Task<bool> CategoryExists(int categoryId);

        Task<int> GetProjectAwardId(int projectId);

        Task<bool> AwardExists(int awardId);

        Task<List<int>> GetProjectToolsId(int projectId);

        Task<bool> ToolsUsedExists(int toolsId);

        Task<IEnumerable<ProjectServiceModel>> AllProjectsByUserId(string userId);

        Task<IEnumerable<ProjectServiceModel>> AllProjectsByModeratorId();

    }
}
