using DesignHelper.Contracts;
using DesignHelper.Core.Exceptions;
using DesignHelper.Core.Models.Project;
using DesignHelper.Infrastructure.Data;
using DesignHelper.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace DesignHelper.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository repo;
        private readonly IGuard guard;


        public ProjectService(IRepository _repo, IGuard _guard)
        {
            repo = _repo;
            guard = _guard;
        }

        public async Task AddToFavourites(int projectId, string currentUserId)
        {
            var project = await repo.GetByIdAsync<ProjectEntity>(projectId);

            if (project != null && project.AddToFavouritesId != null)
            {
                throw new ArgumentException("Project is already added to favourites!");
            }

            guard.AgainstNull(project, "Project can't be found!");
            project.AddToFavouritesId = currentUserId;

            await repo.SaveChangesAsync();
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

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<ProjectEntity>()
                .AnyAsync(p => p.Id == id && p.IsActive);
        }

        public async Task<IEnumerable<ProjectServiceModel>> Favourites(string userId)
        {
            return await repo.AllReadonly<ProjectEntity>()
                .Where(p => p.AddToFavouritesId == userId)
                .Where(p => p.IsActive)
                .Select(p => new ProjectServiceModel()
                {
                    Id = p.Id,
                    Rating = p.Rating,
                    Area = p.Area,
                    Author = p.Author,
                    ImageUrl = p.ImageUrl,
                    Location = p.Location,
                    Title = p.Title,
                    IsFavourite = p.AddToFavouritesId != null,
                })
                .ToListAsync();
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

        public async Task<bool> IsFavourite(int projectId)
        {
            return (await repo.GetByIdAsync<ProjectEntity>(projectId)).AddToFavouritesId != null;
        }

        public async Task<bool> IsFavouriteByUserWithId(int projectId, string currentUserId)
        {
            bool result = false;
            var project = await repo.AllReadonly<ProjectEntity>()
                .Where(p => p.IsActive)
                .Where(p => p.Id == projectId)
                .FirstOrDefaultAsync();

            if (project != null && project.AddToFavouritesId == currentUserId)
            {
                result = true;
            }

            return result;
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

        public async Task<ProjectDetailsViewModel> ProjectDetailsById(int id)
        {
            return await repo.AllReadonly<ProjectEntity>()
                .Where(p => p.IsActive)
                .Where(p => p.Id == id)
                .Select(p => new ProjectDetailsViewModel()
                {
                    Area = p.Area,
                    Author = p.Author,
                    Award = p.Awards.Name,
                    Category = p.Category.Name,
                    Description = p.Description,
                    Id = id,
                    ImageUrl = p.ImageUrl,
                    Location = p.Location,
                    Rating = p.Rating,
                    Title = p.Title,
                    IsFavourite = p.AddToFavouritesId != null
                })
                .FirstAsync();
        }

        public async Task RemoveFromFavourite(int projectId)
        {
            var project = await repo.GetByIdAsync<ProjectEntity>(projectId);
            guard.AgainstNull(project, "Project can't be found!");
            project.AddToFavouritesId = null;

            await repo.SaveChangesAsync();
        }
    }
}
