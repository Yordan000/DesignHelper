using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DesignHelper.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectEntity> ProjectsEntities { get; set; } 
        public DbSet<Category> Categories { get; set; }
        public DbSet<AwardEntity> Awards { get; set; }
        public DbSet<TopRatedEntity> TopRatedEntities { get; set; }
        public DbSet<ToolUsed> ToolsUsed { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserProject>()
                .HasKey(p => new { p.ApplicationUserId, p.ProjectEntityId });

            base.OnModelCreating(builder);
        }
    }
}