using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignHelper.Infrastructure.Data.Configuration
{
    internal class ToolsUsedConfiguration : IEntityTypeConfiguration<ToolUsed>
    {
        public void Configure(EntityTypeBuilder<ToolUsed> builder)
        {
            builder.HasData(CreateToolsUsed());
        }

        private List<ToolUsed> CreateToolsUsed()
        {
            List<ToolUsed> toolsUsed = new List<ToolUsed>()
            {
                new ToolUsed()
                {
                    Id = 1,
                    Name = "3Ds Max"
                },
                new ToolUsed()
                {
                    Id = 2,
                    Name = "AutoCAD"
                },
                new ToolUsed()
                {
                    Id = 3,
                    Name = "Revit"
                },
                new ToolUsed()
                {
                    Id = 4,
                    Name = "Archicad"
                },
                new ToolUsed()
                {
                    Id = 5,
                    Name = "Lumion"
                },
                new ToolUsed()
                {
                    Id = 6,
                    Name = "Photoshop"
                },
                new ToolUsed()
                {
                    Id = 7,
                    Name = "Vray"
                },
                new ToolUsed()
                {
                    Id = 8,
                    Name = "Corona"
                },
                new ToolUsed()
                {
                    Id = 9,
                    Name = "Canon 6D"
                },
                new ToolUsed()
                {
                    Id = 10,
                    Name = "Sony Alpha 7Riii"
                },
                new ToolUsed()
                {
                    Id = 11,
                    Name = "Nikon"
                }
            };

            return toolsUsed;
        }
    }
}
