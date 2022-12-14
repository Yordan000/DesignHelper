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
            var roles = await repo.AllReadonly<IdentityRole>().ToListAsync();

            var usersWithRoles = await repo.AllReadonly<IdentityUserRole<string>>().ToListAsync();

            var users = await repo.AllReadonly<User>().ToListAsync();

            List<UserServiceModel> result = new List<UserServiceModel>();

            foreach (var item in usersWithRoles)
            {
                foreach (var role in roles)
                {
                    foreach (var user in users)
                    {
                        if (item.UserId == user.Id && item.RoleId == role.Id)
                        {
                            result.Add(new UserServiceModel()
                            {
                                UserId = user.Id,
                                Email = user.Email,
                                FullName = $"{user.FirstName} {user.LastName}",
                                UserRole = role.Name
                            });
                        }
                    }
                }
            }
            return result;
        }

        public string UserFullName(string userId)
        {
            var user = repo.AllReadonly<User>().First(u => u.Id == userId);

            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
            {
                return null;
            }

            return $"{user?.FirstName} {user?.LastName}".TrimEnd();
        }
    }
}
