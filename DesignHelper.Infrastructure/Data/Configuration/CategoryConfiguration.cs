using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignHelper.Infrastructure.Data.Configuration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        private List<Category> CreateCategories()
        {
            List<Category> categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Architecture"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Interior Design"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Visualization"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Photography"
                }
            };

            return categories;
        }
    }
}
