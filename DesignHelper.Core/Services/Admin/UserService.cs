using DesignHelper.Core.Contracts.Admin;
using DesignHelper.Core.Models.Admin;
using DesignHelper.Infrastructure.Data;
using DesignHelper.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DesignHelper.Core.Services.Admin
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;
        private readonly UserManager<User> userManager;

        public UserService(IRepository _repo, UserManager<User> _userManager)
        {
            repo = _repo;
            userManager = _userManager;
        }

        public async Task<IEnumerable<UserServiceModel>> All()
        {
            List<UserServiceModel> result;
            //var user = await repo.AllReadonly<User>().
            var userId = await repo.AllReadonly<User>().ToListAsync();

            var roles = await repo.AllReadonly<IdentityRole>().ToListAsync();



            result = await repo.AllReadonly<User>()
                .Select(u => new UserServiceModel()
                {
                    UserId = u.Id,
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}",
                    //UserRole = roleId.Select(r => r.Id == u.Id).ToString()
                })
                .ToListAsync();



            return result;
        }

        public string UserFullName(string userId)
        {
            var user =  repo.AllReadonly<User>().First(u => u.Id == userId);

            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
            {
                return null;
            }

            return $"{user?.FirstName} {user?.LastName}".TrimEnd();
        }
    }
}
