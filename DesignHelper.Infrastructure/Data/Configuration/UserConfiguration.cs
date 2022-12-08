﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignHelper.Infrastructure.Data.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(CreateUsers());
        }
        private List<User> CreateUsers()
        {
            var users = new List<User>();
            var hasher = new PasswordHasher<User>();

            var user = new User()
            {
                Id = "ce6f82b6-3d55-4bb3-8e94-d051a0b01a07",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                FirstName = "Yordan",
                LastName = "Admin",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            user.PasswordHash = hasher.HashPassword(user, "Admin123");

            users.Add(user);

            user = new User()
            {
                Id = "3c128b69-c44c-4c7d-9f7a-9921c86bbf29",
                UserName = "user@gmail.com",
                NormalizedUserName = "USER@GMAIL.COM",
                Email = "user@gmail.com",
                NormalizedEmail = "USER@GMAIL.COM",
                FirstName = "Yordan",
                LastName = "User",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            user.PasswordHash = hasher.HashPassword(user, "User123");

            users.Add(user);

            user = new User()
            {
                Id = "5faa7c98-430f-4036-928f-f5210e8fbeea",
                UserName = "guest@gmail.com",
                NormalizedUserName = "GUEST@GMAIL.COM",
                Email = "guest@gmail.com",
                NormalizedEmail = "GUEST@GMAIL.COM",
                FirstName = "Yordan",
                LastName = "Guest",
                SecurityStamp = Guid.NewGuid().ToString()
            };

            user.PasswordHash = hasher.HashPassword(user, "Guest123");

            users.Add(user);

            return users;
        }
    }
}
