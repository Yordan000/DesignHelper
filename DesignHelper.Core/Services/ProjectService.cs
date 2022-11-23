using DesignHelper.Contracts;
using DesignHelper.Core.Models.Project;
using DesignHelper.Infrastructure.Data;
using DesignHelper.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace DesignHelper.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository repo;


        public ProjectService(IRepository _repo)
        {
            repo = _repo;
        }
        public async Task<IEnumerable<ProjectCategoryModel>> GetAllCategories()
        {
            return await repo.AllReadonly<Category>()
                .OrderBy(c => c.Name)
                .Select(c => new ProjectCategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProjectHomeModel>> LastThreeProjects()
        {
            return await repo.AllReadonly<ProjectEntity>()
                .OrderByDescending(p => p.Id)
                .Select(p => new ProjectHomeModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Title = p.Title
                })
                .Take(3)
                .ToListAsync();
        }
    }
}
