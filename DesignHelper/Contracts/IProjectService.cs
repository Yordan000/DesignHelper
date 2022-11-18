using DesignHelper.Infrastructure.Data;
using DesignHelper.Models;

namespace DesignHelper.Contracts
{
    public interface IProjectService
    {
        Task AddProjectsAsync(ProjectAddViewModel model);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<ProjectViewModel>> GetAllAsync();
    }
}
