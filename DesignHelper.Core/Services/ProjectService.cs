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

        public async Task<int> Create(ProjectAddViewModel model)
        {
            var project = new ProjectEntity()
            {
                Title = model.Title,
                Area = model.Area,
                Location = model.Location,
                CategoryId = model.CategoryId,
                Description = model.Description,
                AwardId = model.AwardId,
                ToolsId = model.ToolsId,
                Author = model.Author,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating
            };

            await repo.AddAsync(project);
            await repo.SaveChangesAsync();

            return project.Id;
        }

        public async Task<IEnumerable<ProjectAwardsModel>> GetAllAwards()
        {
            return await repo.AllReadonly<AwardEntity>()
                .OrderBy(a => a.Id)
                .Select(a => new ProjectAwardsModel()
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProjectCategoryModel>> GetAllCategories()
        {
            return await repo.AllReadonly<Category>()
                .OrderBy(c => c.Id)
                .Select(c => new ProjectCategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProjectToolsUsedModel>> GetAllTools()
        {
            return await repo.AllReadonly<ToolUsed>()
                .OrderBy(t => t.Id)
                .Select(t => new ProjectToolsUsedModel()
                {
                    Id = t.Id,
                    Name = t.Name
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
