using DesignHelper.Core.Contracts.Admin;
using DesignHelper.Core.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static DesignHelper.Areas.Admin.Constrains.AdminConstrains;

namespace DesignHelper.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        private readonly IMemoryCache memoryCache;

        public UserController(IUserService _userService, IMemoryCache _memoryCache)
        {
            userService = _userService;
            memoryCache = _memoryCache;
        }
        public async Task<IActionResult> All()
        {
            var users = memoryCache.Get<IEnumerable<UserServiceModel>>(AllUsersCacheKey);

            if (users == null)
            {
                users = await userService.All();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                memoryCache.Set(AllUsersCacheKey, users, cacheOptions);
            }

            return View(users);
        }
    }
}
