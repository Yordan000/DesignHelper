using DesignHelper.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using static DesignHelper.Areas.Admin.Constrains.AdminConstrains;
using static DesignHelper.Areas.Moderator.Constrains.ModeratorConstrains;
using static DesignHelper.Areas.User.Constrains.UserConstrains;

namespace DesignHelper.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedRoles(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var services = scopedServices.ServiceProvider;

            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdminRoleName))
                {
                    return;
                }

                if (await roleManager.RoleExistsAsync(ModeratorRoleName))
                {
                    return;
                }

                if (await roleManager.RoleExistsAsync(UserRoleName))
                {
                    return;
                }

                var adminRole = new IdentityRole { Name = AdminRoleName };
                await roleManager.CreateAsync(adminRole);

                var moderatorRole = new IdentityRole { Name = ModeratorRoleName };
                await roleManager.CreateAsync(moderatorRole);

                var userRole = new IdentityRole { Name = UserRoleName };
                await roleManager.CreateAsync(userRole);

                var admin = await userManager.FindByNameAsync(AdminEmail);

                await userManager.AddToRoleAsync(admin, adminRole.Name);

                var moderator = await userManager.FindByNameAsync(ModeratorEmail);

                await userManager.AddToRoleAsync(moderator, moderatorRole.Name);

                var user = await userManager.FindByNameAsync(UserEmail);

                await userManager.AddToRoleAsync(user, userRole.Name);

            })
                .GetAwaiter()
                .GetResult();

            return app;
        }
    }
}
