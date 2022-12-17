using DesignHelper.Contracts;
using DesignHelper.Core.Exceptions;
using DesignHelper.Core.Models.Project;
using DesignHelper.Infrastructure.Data;
using DesignHelper.Infrastructure.Data.Common;
using DesignHelper.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Logging;
using Moq;

namespace DesignHelper.Tests.UnitTests
{
    [TestFixture]
    public class ProjectServiceTests
    {
        private IRepository repo;
        private IGuard guard;
        private IProjectService projectService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public void Setup()
        {
            guard = new Guard();

            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("DesignDB")
                .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task TestProjectAddToFavourites()
        {
            var repo = new Repository(applicationDbContext);
            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new User()
            {
                Id = "asd",
                Email = "",
                FirstName = "",
                LastName = ""
            });

            await repo.SaveChangesAsync();

            await repo.AddAsync(new ProjectEntity()
            {
                Id = 10,
                Author = "",
                Description = "",
                ImageUrl = "",
                Location = "",
                Title = "",
                AddedById = ""
            });

            await repo.SaveChangesAsync();

            await projectService.AddToFavourites(10, "asd");

            var user = await repo.GetByIdAsync<User>("asd");

            Assert.That(user.UsersProjects.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task TestProjectAwardExist()
        {
            var repo = new Repository(applicationDbContext);
            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new AwardEntity()
            {
                Id = 10,
                Name = "Test Award"
            });

            await repo.SaveChangesAsync();

            var result = await projectService.AwardExists(10);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task TestProjectCategoryExist()
        {
            var repo = new Repository(applicationDbContext);
            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new Category()
            {
                Id = 10,
                Name = "Test Category"
            });

            await repo.SaveChangesAsync();

            var result = await projectService.CategoryExists(10);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task TestProjectToolsUsedExist()
        {
            var repo = new Repository(applicationDbContext);
            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new ToolUsed()
            {
                Id = 20,
                Name = "Test Tools"
            });

            await repo.SaveChangesAsync();

            var result = await projectService.ToolsUsedExists(20);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task TestProjectExist()
        {
            var repo = new Repository(applicationDbContext);
            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new ProjectEntity()
            {
                Id = 10,
                Author = "",
                Description = "",
                ImageUrl = "",
                Location = "",
                Title = "",
                AddedById = ""
            });

            await repo.SaveChangesAsync();

            var result = await projectService.Exists(10);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task TestProjectDelete()
        {
            var repo = new Repository(applicationDbContext);
            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new ProjectEntity()
            {
                Id = 10,
                Author = "",
                Description = "",
                ImageUrl = "",
                Location = "",
                Title = "",
                AddedById = ""
            });

            await repo.SaveChangesAsync();

            await repo.AddAsync(new ProjectEntity()
            {
                Id = 11,
                Author = "",
                Description = "",
                ImageUrl = "",
                Location = "",
                Title = "",
                AddedById = ""
            });

            await repo.SaveChangesAsync();

            await projectService.Delete(11);
            var deletedProject = await repo.GetByIdAsync<ProjectEntity>(11);
            var projects = await repo.AllReadonly<ProjectEntity>().ToListAsync();

            Assert.That(projects.Count(), Is.EqualTo(10));
            Assert.That(deletedProject.IsActive, Is.False);
        }

        [Test]
        public async Task TestProjectGetProjectAwardById()
        {
            var repo = new Repository(applicationDbContext);
            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new ProjectEntity()
            {
                Id = 11,
                Author = "",
                Description = "",
                ImageUrl = "",
                Location = "",
                Title = "",
                AddedById = "",
                AwardId = 7
            });

            await repo.SaveChangesAsync();

            var result = await projectService.GetProjectAwardId(11);

            Assert.That(result, Is.EqualTo(7));

        }

        [Test]
        public async Task TestProjectGetProjectCategoryById()
        {
            var repo = new Repository(applicationDbContext);
            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new ProjectEntity()
            {
                Id = 11,
                Author = "",
                Description = "",
                ImageUrl = "",
                Location = "",
                Title = "",
                AddedById = "",
                CategoryId = 7
            });

            await repo.SaveChangesAsync();

            var result = await projectService.GetProjectCategoryId(11);

            Assert.That(result, Is.EqualTo(7));

        }

        [Test]
        public async Task TestProjectGetProjectToolsUsedById()
        {
            var repo = new Repository(applicationDbContext);
            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new ProjectEntity()
            {
                Id = 11,
                Author = "",
                Description = "",
                ImageUrl = "",
                Location = "",
                Title = "",
                AddedById = "",
            });

            var project = await repo.GetByIdAsync<ProjectEntity>(11);

            project.ProjectsToolsUsed.Add(new ProjectToolsUsed()
            {
                ProjectsEntityId = 11,
                ToolsUsedId = 22
            });

            await repo.SaveChangesAsync();

            project.ProjectsToolsUsed.Add(new ProjectToolsUsed()
            {
                ProjectsEntityId = 11,
                ToolsUsedId = 23
            });

            await repo.SaveChangesAsync();

            var result = await projectService.GetProjectToolsId(11);

            Assert.That(result.Count, Is.EqualTo(2));

        }

        [Test]
        public async Task TestProjectIsFavourite()
        {
            var repo = new Repository(applicationDbContext);
            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new User()
            {
                Id = "asd",
                Email = "",
                FirstName = "",
                LastName = ""
            });

            await repo.SaveChangesAsync();

            await repo.AddAsync(new ProjectEntity()
            {
                Id = 10,
                Author = "",
                Description = "",
                ImageUrl = "",
                Location = "",
                Title = "",
                AddedById = ""
            });

            await repo.SaveChangesAsync();

            var user = await repo.GetByIdAsync<User>("asd");

            user.UsersProjects.Add(new UserWithProject()
            {
                ProjectId = 10,
                UserId = user.Id
            });

            await repo.SaveChangesAsync();

            var result = await projectService.IsFavourite(10, user.Id);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task TestProjectAll()
        {
            var repo = new Repository(applicationDbContext);
            projectService = new ProjectService(repo, guard);

            await repo.AddRangeAsync(new List<ProjectEntity>()
            {
                new ProjectEntity() { Id = 10 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = ""},
                new ProjectEntity() { Id = 13 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = ""},
                new ProjectEntity() { Id = 15 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = ""},
                new ProjectEntity() { Id = 17 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = ""},
            });

            await repo.SaveChangesAsync();

            var projects = await repo.AllReadonly<ProjectEntity>().ToListAsync();

            var result = await projectService.All();

            Assert.That(result.TotalProjectsCount, Is.EqualTo(projects.Count));
        }

        [Test]
        public async Task TestAllAwardsNames()
        {
            var repo = new Repository(applicationDbContext);
            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new AwardEntity()
            {
                Id = 10,
                Name = "Test Award"
            });

            await repo.SaveChangesAsync();

            var awards = await repo.AllReadonly<AwardEntity>().Select(a => a.Name).ToListAsync();

            var result = await projectService.AllAwardsNames();

            foreach (var award in awards)
            {
                Assert.That(result.Contains(award), Is.True);
            }

            Assert.That(awards.Count, Is.EqualTo(result.Count()));
        }

        [Test]
        public async Task TestAllCategoryNames()
        {
            var repo = new Repository(applicationDbContext);
            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new Category()
            {
                Id = 10,
                Name = "Test Category"
            });

            await repo.SaveChangesAsync();

            var categories = await repo.AllReadonly<Category>().Select(a => a.Name).ToListAsync();

            var result = await projectService.AllCategoriesNames();

            foreach (var category in categories)
            {
                Assert.That(result.Contains(category), Is.True);
            }

            Assert.That(categories.Count, Is.EqualTo(result.Count()));
        }

        [Test]
        public async Task TestAllToolsNames()
        {
            var repo = new Repository(applicationDbContext);
            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new ToolUsed()
            {
                Id = 20,
                Name = "Test Tool"
            });

            await repo.SaveChangesAsync();

            var toolsUsed = await repo.AllReadonly<ToolUsed>().Select(a => a.Name).ToListAsync();

            var result = await projectService.AllToolsUsedNames();

            foreach (var tool in toolsUsed)
            {
                Assert.That(result.Contains(tool), Is.True);
            }

            Assert.That(toolsUsed.Count, Is.EqualTo(result.Count()));
        }

        [Test]
        public async Task TestProjectFavourites()
        {
            var repo = new Repository(applicationDbContext);
            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new User()
            {
                Id = "asd",
                Email = "",
                FirstName = "",
                LastName = ""
            });

            await repo.SaveChangesAsync();

            await repo.AddRangeAsync(new List<ProjectEntity>()
            {
                new ProjectEntity() { Id = 10 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = ""},
                new ProjectEntity() { Id = 13 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = ""},
                new ProjectEntity() { Id = 15 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = ""},
            });

            await repo.SaveChangesAsync();

            var user = await repo.GetByIdAsync<User>("asd");
            var projects = await repo.AllReadonly<ProjectEntity>().Select(p => p.Id).ToListAsync();

            foreach (var project in projects)
            {
                if (project > 7)
                {
                    user.UsersProjects.Add(new UserWithProject()
                    {
                        ProjectId = project,
                        UserId = user.Id
                    });
                    await repo.SaveChangesAsync();
                }
            }

            var result = await projectService.Favourites(user.Id);

            Assert.That(result.Count, Is.EqualTo(user.UsersProjects.Count()));
        }

        [Test]
        public async Task TestProjectRemoveFromFavourites()
        {
            var repo = new Repository(applicationDbContext);
            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new User()
            {
                Id = "asd",
                Email = "",
                FirstName = "",
                LastName = ""
            });

            await repo.SaveChangesAsync();

            await repo.AddRangeAsync(new List<ProjectEntity>()
            {
                new ProjectEntity() { Id = 10 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = ""},
                new ProjectEntity() { Id = 13 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = ""},
                new ProjectEntity() { Id = 15 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = ""},
            });

            await repo.SaveChangesAsync();

            var user = await repo.GetByIdAsync<User>("asd");

            user.UsersProjects.AddRange(new List<UserWithProject>()
            {
                new UserWithProject() { ProjectId = 10, UserId = user.Id },
                new UserWithProject() { ProjectId = 13, UserId = user.Id },
                new UserWithProject() { ProjectId = 15, UserId = user.Id },
            });

            await repo.SaveChangesAsync();

            await projectService.RemoveFromFavourite(10, user.Id);

            Assert.That(user.UsersProjects.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task TestProjectCreate()
        {
            var repo = new Repository(applicationDbContext);
            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new User()
            {
                Id = "asd",
                Email = "",
                FirstName = "",
                LastName = ""
            });

            await repo.SaveChangesAsync();

            await projectService.Create(new ProjectAddViewModel()
            {
                Id = 13,
                Title = "",
                Description = "",
                ImageUrl = "",
                Author = "",
                Area = 0,
                Rating = 0.0M,
                Location = ""
            }, "asd");

            var projects = await repo.AllReadonly<ProjectEntity>().ToListAsync();

            Assert.That(projects.Count(), Is.EqualTo(9));
        }

        [Test]
        public async Task TestProjectGetAllAwards()
        {
            var repo = new Repository(applicationDbContext);
            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new AwardEntity()
            {
                Id = 10,
                Name = "Test Award"
            });

            await repo.SaveChangesAsync();

            var result = await projectService.GetAllAwards();

            Assert.That(result.Count(), Is.EqualTo(6));
        }

        [Test]
        public async Task TestProjectGetAllCategories()
        {
            var repo = new Repository(applicationDbContext);
            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new Category()
            {
                Id = 10,
                Name = "Test Category"
            });

            await repo.SaveChangesAsync();

            var result = await projectService.GetAllCategories();

            Assert.That(result.Count(), Is.EqualTo(5));
        }

        [Test]
        public async Task TestProjectGetAllToolsUsed()
        {
            var repo = new Repository(applicationDbContext);
            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new ToolUsed()
            {
                Id = 20,
                Name = "Test Tools"
            });

            await repo.SaveChangesAsync();

            var result = await projectService.GetAllTools();

            Assert.That(result.Count(), Is.EqualTo(12));
        }

        [Test]
        public async Task TestProjectEdit()
        {
            var repo = new Repository(applicationDbContext);

            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new ProjectEntity()
            {
                Id = 10,
                Author = "",
                Description = "",
                Title = "",
                ImageUrl = "",
                Location = "",
                Area = 1,
                Rating = 1M,
                AddedById = "",
            });

            await repo.SaveChangesAsync();

            var project = await repo.GetByIdAsync<ProjectEntity>(10);

            project.ProjectsToolsUsed.Add(new ProjectToolsUsed()
            {
                ProjectsEntityId = 10,
                ToolsUsedId = 20
            });
            await repo.SaveChangesAsync();

            projectService?.Edit(10, new ProjectAddViewModel()
            {
                Id = 10,
                Author = "",
                Description = "",
                Title = "Title has been changed",
                ImageUrl = "",
                Location = "",
                Area = 1,
                Rating = 1M
            });

            var result = await repo.GetByIdAsync<ProjectEntity>(10);
            //var title = await repo.AllReadonly<ProjectEntity>().ToListAsync();

            Assert.That(result.Title, Is.EqualTo("Title has been changed"));
        }

        [Test]
        public async Task TestProjectAllProjectsByUserId()
        {
            var repo = new Repository(applicationDbContext);

            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new User()
            {
                Id = "asd",
                Email = "",
                FirstName = "",
                LastName = ""
            });

            await repo.SaveChangesAsync();

            await repo.AddRangeAsync(new List<ProjectEntity>()
            {
                new ProjectEntity() { Id = 10 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = "asd"},
                new ProjectEntity() { Id = 13 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = "asd"},
                new ProjectEntity() { Id = 15 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = "asd"},
                new ProjectEntity() { Id = 12 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = "asd"}
            });

            await repo.SaveChangesAsync();

            var result = await projectService.AllProjectsByUserId("asd");

            Assert.That(result.Count(), Is.EqualTo(4));
        }

        [Test]
        public async Task TestProjectAllProjectsByModeratorId()
        {
            var repo = new Repository(applicationDbContext);

            projectService = new ProjectService(repo, guard);

            await repo.AddAsync(new IdentityRole()
            {
                Id = "md",
                Name = "Moderator"
            });

            await repo.SaveChangesAsync();

            await repo.AddAsync(new IdentityUserRole<string>()
            {
                RoleId = "md",
                UserId = "mod"
            });

            await repo.SaveChangesAsync();

            await repo.AddRangeAsync(new List<ProjectEntity>()
            {
                new ProjectEntity() { Id = 10 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = "asd"},
                new ProjectEntity() { Id = 13 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = "asd"},
                new ProjectEntity() { Id = 15 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = "asd"},
                new ProjectEntity() { Id = 12 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = "asd"},
                new ProjectEntity() { Id = 17 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = "mod"},
                new ProjectEntity() { Id = 19 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = "mod"},
            });

            await repo.SaveChangesAsync();

            var result = await projectService.AllProjectsByModeratorId();

            Assert.That(result.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task TestLastThreeProjectsOrder()
        {
            var repo = new Repository(applicationDbContext);

            projectService = new ProjectService(repo, guard);

            await repo.AddRangeAsync(new List<ProjectEntity>()
            {
                new ProjectEntity() { Id = 10 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = ""},
                new ProjectEntity() { Id = 13 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = ""},
                new ProjectEntity() { Id = 15 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = ""},
                new ProjectEntity() { Id = 12 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = ""}
            });

            await repo.SaveChangesAsync();

            var projectCollection = await projectService.LastThreeProjects();

            Assert.That(3, Is.EqualTo(projectCollection.Count()));
            Assert.That(projectCollection.Any(p => p.Id == 1), Is.False);

        }

        [Test]
        public async Task TestProjectDetailsById()
        {
            var repo = new Repository(applicationDbContext);

            projectService = new ProjectService(repo, guard);

            await repo.AddRangeAsync(new List<ProjectEntity>()
            {
                new ProjectEntity() { Id = 10 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = "asd"},
                new ProjectEntity() { Id = 13 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = "asd"},
                new ProjectEntity() { Id = 15 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = "asd"},
                new ProjectEntity() { Id = 12 , Author = "", Description = "", ImageUrl = "", Location = "", Title = "", AddedById = "asd"}
            });

            await repo.SaveChangesAsync();

            var result = projectService.ProjectDetailsById(15);

            Assert.That(result, Is.Not.Null);
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
