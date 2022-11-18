using DesignHelper.Contracts;
using DesignHelper.Infrastructure.Data;
using DesignHelper.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignHelper.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext context;

        public ProjectService(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task AddProjectsAsync(ProjectAddViewModel model)
        {
            var project = new ProjectEntity()
            {
                Title = model.Title,
                Description = model.Description,
                Area = model.Area,
                CategoryId = model.CategoryId,
                Author = model.Author,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                Location = model.Location,
                AwardId = model.AwardId,
                ToolsId = model.ToolsId
            };

            await context.ProjectsEntities.AddAsync(project);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAllAsync()
        {
            var projects = await context.ProjectsEntities
                .Include(p => p.Category)
                .ToListAsync();

            return projects
                .Select(p => new ProjectViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Area = p.Area,
                    Author = p.Author,
                    Description = p.Description,
                    Rating = p.Rating,
                    Award = p.Awards.Name,
                    ImageUrl = p.ImageUrl,
                    Category = p.Category.Name,
                    Tools = p.ToolsUsed.Name
                });
        }

        public Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
