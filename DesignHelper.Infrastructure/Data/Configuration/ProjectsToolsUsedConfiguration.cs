using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignHelper.Infrastructure.Data.Configuration
{
    internal class ProjectsToolsUsedConfiguration : IEntityTypeConfiguration<ProjectToolsUsed>
    {
        public void Configure(EntityTypeBuilder<ProjectToolsUsed> builder)
        {
            builder.HasData(CreateProjectsToolsUsed());
        }
        private List<ProjectToolsUsed> CreateProjectsToolsUsed()
        {
            var projects = new List<ProjectToolsUsed>()
            {
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 1,
                        ToolsUsedId = 1
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 1,
                        ToolsUsedId = 2
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 1,
                        ToolsUsedId = 6
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 1,
                        ToolsUsedId = 7
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 2,
                        ToolsUsedId = 2
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 2,
                        ToolsUsedId = 3
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 2,
                        ToolsUsedId = 5
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 2,
                        ToolsUsedId = 6
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 2,
                        ToolsUsedId = 8
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 3,
                        ToolsUsedId = 1
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 3,
                        ToolsUsedId = 4
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 3,
                        ToolsUsedId = 6
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 3,
                        ToolsUsedId = 8
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 4,
                        ToolsUsedId = 9
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 5,
                        ToolsUsedId = 3
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 5,
                        ToolsUsedId = 1
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 5,
                        ToolsUsedId = 5
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 5,
                        ToolsUsedId = 6
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 5,
                        ToolsUsedId = 8
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 6,
                        ToolsUsedId = 2
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 6,
                        ToolsUsedId = 4
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 6,
                        ToolsUsedId = 7
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 6,
                        ToolsUsedId = 6
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 7,
                        ToolsUsedId = 1
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 7,
                        ToolsUsedId = 2
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 7,
                        ToolsUsedId = 5
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 7,
                        ToolsUsedId = 3
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 7,
                        ToolsUsedId = 8
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 7,
                        ToolsUsedId = 6
                    },
                    new ProjectToolsUsed()
                    {
                        ProjectsEntityId = 8,
                        ToolsUsedId = 10
                    }
            };

            return projects;
        }

    }
}
