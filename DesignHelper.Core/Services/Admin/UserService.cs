﻿using DesignHelper.Core.Contracts.Admin;
using DesignHelper.Core.Models.Admin;
using DesignHelper.Infrastructure.Data;
using DesignHelper.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace DesignHelper.Core.Services.Admin
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<UserServiceModel>> All()
        {
            List<UserServiceModel> result;

            result = await repo.AllReadonly<User>()
                .Select(u => new UserServiceModel()
                {
                    UserId = u.Id,
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}"
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