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

        public async Task<ProjectQueryServiceModel> All(string? category = null, string? award = null, string? searchTerm = null, ProjectSorting sorting = ProjectSorting.Newest, int currentPage = 1, int housesPerPage = 1)
        {
            var result = new ProjectQueryServiceModel();
            var projects = repo.AllReadonly<ProjectEntity>()
                .Where(h => h.IsActive);

            if (string.IsNullOrEmpty(category) == false)
            {
                projects = projects
                    .Where(h => h.Category.Name == category);
            }

            if (string.IsNullOrEmpty(award) == false)
            {
                projects = projects
                    .Where(h => h.Awards.Name == award);
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";

                projects = projects
                    .Where(h => EF.Functions.Like(h.Title.ToLower(), searchTerm) ||
                        EF.Functions.Like(h.Location.ToLower(), searchTerm) ||
                        EF.Functions.Like(h.Description.ToLower(), searchTerm));
            }

            projects = sorting switch
            {
                ProjectSorting.Area => projects
                    .OrderBy(p => p.Area),
                ProjectSorting.Rating => projects
                    .OrderByDescending(p => p.Rating),
                _ => projects.OrderByDescending(h => h.Id)
            };

            result.Projects = await projects
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .Select(p => new ProjectServiceModel()
                {
                    Area = p.Area,
                    Location = p.Location,
                    Author = p.Author,
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Rating = p.Rating,
                    Title = p.Title

                })
                .ToListAsync();

            result.TotalProjectsCount = await projects.CountAsync();

            return result;
        }

        public async Task<IEnumerable<string>> AllAwardsNames()
        {
            return await repo.AllReadonly<AwardEntity>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repo.AllReadonly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
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
