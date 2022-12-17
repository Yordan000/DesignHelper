using DesignHelper.Contracts;
using DesignHelper.Core.Exceptions;
using DesignHelper.Infrastructure.Data.Common;
using DesignHelper.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DesignHelper.Core.Contracts.Admin;
using DesignHelper.Services;
using System;
using DesignHelper.Core.Services.Admin;

namespace DesignHelper.Tests.UnitTests
{
    public class UserServiceTests
    {
        private IRepository repo;
        private IUserService userService;
        private UserManager<User> userManager;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("DesignDB")
                .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task TestProjectUserServivceAll()
        {
            var repo = new Repository(applicationDbContext);
            userService = new UserService(repo, userManager);

            await repo.AddRangeAsync(new List<User>()
            {
                new User(){ Id = "asd", Email = "", FirstName = "", LastName = ""},
                new User(){ Id = "fgh", Email = "", FirstName = "", LastName = ""},
                new User(){ Id = "jkl", Email = "", FirstName = "", LastName = ""}
            });

            await repo.SaveChangesAsync();

            var users = await repo.AllReadonly<User>().ToListAsync();

            var result = await userService.All();

            Assert.That(result.Count, Is.EqualTo(users.Count));
        }

        [Test]
        public async Task TestProjectUserFullName()
        {
            var repo = new Repository(applicationDbContext);
            userService = new UserService(repo, userManager);

            await repo.AddAsync(new User()
            { 
                Id = "asd", 
                Email = "", 
                FirstName = "aaaa", 
                LastName = "ssss"
            });

            await repo.SaveChangesAsync();

            var user = await repo.GetByIdAsync<User>("asd");

            var result = userService.UserFullName(user.Id);

            Assert.That(result, Is.EqualTo("aaaa ssss"));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
