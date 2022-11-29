using DesignHelper.Contracts;
using DesignHelper.Core.Models.CheckBoxValidation;
using DesignHelper.Core.Models.Project;
using DesignHelper.Infrastructure.Data;
using DesignHelper.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

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
            var toolsUsed = new List<ProjectToolsUsed>();

            var project = new ProjectEntity()
            {
                Title = model.Title,
                Area = model.Area,
                Location = model.Location,
                CategoryId = model.CategoryId,
                Description = model.Description,
                AwardId = model.AwardId,
                Author = model.Author,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                
        };

            await repo.AddAsync(project);
            await repo.SaveChangesAsync();

            int projectId = project.Id;

            foreach (var item in model.ProjectTools)
            {
                if (item.IsChecked == true)
                {
                    project.ProjectsToolsUsed.Add(new ProjectToolsUsed()
                    {
                        ToolsUsedId = item.Id
                    });
                }

            }

            repo.Update(project);
            await repo.SaveChangesAsync();

            return projectId;
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
                .Where(p => p.IsActive)
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
