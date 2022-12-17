using DesignHelper.Contracts;
using DesignHelper.Core.Exceptions;
using DesignHelper.Core.Models.Project;
using DesignHelper.Infrastructure.Data;
using DesignHelper.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Identity;
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
            var user = await repo.AllReadonly<User>()
                .Where(u => u.Id == currentUserId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var project = await repo.AllReadonly<ProjectEntity>()
                .Where(p => p.Id == projectId)
                .FirstOrDefaultAsync();

            if (project == null)
            {
                throw new ArgumentException("Invalid project ID");
            }

            var userProject = new UserWithProject();

            if (userProject.ProjectId == projectId)
            {
                throw new ArgumentException("Project is already added to favourites!");
            }
            else
            {
                userProject.ProjectId = projectId;
                userProject.UserId = currentUserId;

                await repo.AddAsync(userProject);
            }

            await repo.SaveChangesAsync();
        }

        public async Task<ProjectQueryServiceModel> All(string? category = null, string? award = null, string? searchTerm = null, ProjectSorting sorting = ProjectSorting.Newest, int currentPage = 1, int projectsPerPage = 1)
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
                .Skip((currentPage - 1) * projectsPerPage)
                .Take(projectsPerPage)
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

        public async Task<IEnumerable<string>> AllToolsUsedNames()
        {
            return await repo.AllReadonly<ToolUsed>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> AwardExists(int awardId)
        {
            return await repo.AllReadonly<AwardEntity>()
                .AnyAsync(a => a.Id == awardId);
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await repo.AllReadonly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<bool> ToolsUsedExists(int toolsId)
        {
            return await repo.AllReadonly<ToolUsed>()
                .AnyAsync(c => c.Id == toolsId);
        }

        public async Task<int> Create(ProjectAddViewModel model, string userId)
        {
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
                AddedById = userId
            };

            await repo.AddAsync(project);
            await repo.SaveChangesAsync();

            int projectId = project.Id;

            foreach (var tool in model.ToolsUsedChecked)
            {
                project.ProjectsToolsUsed.Add(new ProjectToolsUsed()
                {
                    ProjectsEntityId = projectId,
                    ToolsUsedId = tool
                });
            }

            repo.Update(project);
            await repo.SaveChangesAsync();

            return projectId;
        }

        public async Task Delete(int projectId)
        {
            var project = await repo.GetByIdAsync<ProjectEntity>(projectId);
            project.IsActive = false;

            await repo.SaveChangesAsync();
        }

        public async Task Edit(int projectId, ProjectAddViewModel model)
        {
            var project = await repo.AllReadonly<ProjectEntity>().Include(p => p.ProjectsToolsUsed).FirstOrDefaultAsync(p => p.Id == projectId);

            project.Description = model.Description;
            project.ImageUrl = model.ImageUrl;
            project.Title = model.Title;
            project.Location = model.Location;
            project.CategoryId = model.CategoryId;
            project.Author = model.Author;
            project.Area = model.Area;
            project.Rating = model.Rating;
            project.AwardId = model.AwardId;

            foreach (var item in project.ProjectsToolsUsed.ToList())
            {
                 repo.Delete<ProjectToolsUsed>(project.ProjectsToolsUsed.First(p => p.ToolsUsedId == item.ToolsUsedId));
            }

            repo.Update(project);

            foreach (var tool in model.ToolsUsedChecked)
            {
                project.ProjectsToolsUsed.Add(new ProjectToolsUsed()
                {
                    ProjectsEntityId = projectId,
                    ToolsUsedId = tool
                });
            }

            await repo.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<ProjectEntity>()
                .AnyAsync(p => p.Id == id && p.IsActive);
        }

        public async Task<IEnumerable<ProjectServiceModel>> Favourites(string userId)
        {
            var user = await repo.AllReadonly<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.UsersProjects)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var result = await repo.AllReadonly<UserWithProject>()
                .Where(u => u.UserId == userId)
                .Select(p => new ProjectServiceModel()
                {
                    Id = p.UserProjects.Id,
                    Rating = p.UserProjects.Rating,
                    Area = p.UserProjects.Area,
                    Author = p.UserProjects.Author,
                    ImageUrl = p.UserProjects.ImageUrl,
                    Location = p.UserProjects.Location,
                    Title = p.UserProjects.Title,
                    IsFavourite = p.UserProjects.UsersProjects.Any(u => u.UserId == userId) ? true : false
                })
                .ToListAsync();

            return result;
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

        public async Task<int> GetProjectAwardId(int projectId)
        {
            return (await repo.GetByIdAsync<ProjectEntity>(projectId)).AwardId;
        }

        public async Task<int> GetProjectCategoryId(int projectId)
        {
            return (await repo.GetByIdAsync<ProjectEntity>(projectId)).CategoryId;
        }

        public async Task<List<int>> GetProjectToolsId(int projectId)
        {
            var result = await repo.AllReadonly<ProjectToolsUsed>()
                .Where(p => p.ProjectsEntityId == projectId)
                .Select(t => t.ToolsUsedId)
                .ToListAsync();

            return result;
        }

        public async Task<bool> IsFavourite(int projectId, string userId)
        {
            bool result = false;

            var userWithProject = await repo.AllReadonly<UserWithProject>().ToListAsync();

            if (userWithProject.Any(p => p.UserId == userId && p.ProjectId == projectId))
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> IsFavouriteByUserWithId(int projectId, string currentUserId)
        {
            bool result = false;

            var project = await repo.AllReadonly<UserWithProject>()
                .Where(p => p.ProjectId == projectId)
                .FirstOrDefaultAsync();

            if (project != null && project.UserId == currentUserId)
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
                    Title = p.Title,
                    Location = p.Location
                })
                .Take(3)
                .ToListAsync();
        }

        public async Task<ProjectDetailsViewModel> ProjectDetailsById(int id)
        {
            var result = await repo.AllReadonly<ProjectEntity>().Include(p => p.ProjectsToolsUsed).FirstOrDefaultAsync(p => p.Id == id);

            return await repo.AllReadonly<ProjectEntity>()
                .Where(p => p.IsActive)
                .Where(p => p.Id == id)
                .Include(p => p.ProjectsToolsUsed)
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
                    ToolsUsed = p.ProjectsToolsUsed.Select(p => p.ToolsUsed.Name).ToList()
                })
                .FirstAsync();
        }

        public async Task RemoveFromFavourite(int projectId, string userId)
        {
            var project = await repo.AllReadonly<ProjectEntity>().Include(p => p.UsersProjects).FirstOrDefaultAsync(p => p.Id == projectId);

            guard.AgainstNull(project, "Project can't be found!");

            repo.Delete<UserWithProject>(project.UsersProjects.First(p => p.ProjectId == projectId));

            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProjectServiceModel>> AllProjectsByUserId(string userId)
        {
            return await repo.AllReadonly<ProjectEntity>()
                .Where(p => p.AddedById == userId)
                .Where(t => t.IsActive)
                .Select(p => new ProjectServiceModel()
                {
                    Id = p.Id,
                    Area = p.Area,
                    Author = p.Author,
                    ImageUrl = p.ImageUrl,
                    Location = p.Location,
                    Rating = p.Rating,
                    Title = p.Title,
                    IsFavourite = p.UsersProjects.Any(u => u.UserId == userId) ? true : false
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProjectServiceModel>> AllProjectsByModeratorId()
        {
            var roleId = await repo.AllReadonly<IdentityRole>()
                .Where(p => p.Name == "Moderator")
                .Select(p => p.Id)
                .FirstOrDefaultAsync();

            var moderatorId = await repo.AllReadonly<IdentityUserRole<string>>()
                .Where(u => u.RoleId == roleId)
                .Select(u => u.UserId)
                .FirstOrDefaultAsync();

            return await repo.AllReadonly<ProjectEntity>()
                .Where(p => p.AddedById == moderatorId)
                .Where(t => t.IsActive)
                .Select(p => new ProjectServiceModel()
                {
                    Id = p.Id,
                    Area = p.Area,
                    Author = p.Author,
                    ImageUrl = p.ImageUrl,
                    Location = p.Location,
                    Rating = p.Rating,
                    Title = p.Title,
                    IsFavourite = p.UsersProjects.Any(u => u.UserId == moderatorId) ? true : false
                })
                .ToListAsync();
        }

        public async Task<ProjectQueryServiceModel> TopRatedProjects()
        {
            var result = new ProjectQueryServiceModel();
            var projects = await repo.AllReadonly<ProjectEntity>()
                .Where(p => p.IsActive)
                .Take(6)
                .OrderByDescending(p => p.Rating)
                .ThenByDescending(p => p.Area)
                .ToListAsync();

            result.Projects = projects.Select(p => new ProjectServiceModel()
            {
                Area = p.Area,
                Location = p.Location,
                Author = p.Author,
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Rating = p.Rating,
                Title = p.Title
            });

            return result;
        }
    }
}
