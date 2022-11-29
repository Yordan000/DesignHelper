using DesignHelper.Infrastructure.Data.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DesignHelper.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<ProjectToolsUsed>()
                .HasKey(p => new { p.ProjectsEntityId, p.ToolsUsedId });

            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ToolsUsedConfiguration());
            builder.ApplyConfiguration(new AwardsConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<ProjectEntity> ProjectsEntities { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<AwardEntity> Awards { get; set; } = null!;
        public DbSet<TopRatedEntity> TopRatedEntities { get; set; } = null!;
        public DbSet<ToolUsed> ToolsUsed { get; set; } = null!;
    }
}