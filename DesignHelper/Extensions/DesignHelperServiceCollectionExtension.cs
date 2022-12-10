using DesignHelper.Contracts;
using DesignHelper.Core.Contracts.Admin;
using DesignHelper.Core.Exceptions;
using DesignHelper.Core.Services.Admin;
using DesignHelper.Infrastructure.Data.Common;
using DesignHelper.Services;
using System;

namespace DesignHelper.Extensions
{
    public static class DesignHelperServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IGuard, Guard>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
