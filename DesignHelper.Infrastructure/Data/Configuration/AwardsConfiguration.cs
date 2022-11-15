using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignHelper.Infrastructure.Data.Configuration
{
    internal class AwardsConfiguration : IEntityTypeConfiguration<AwardEntity>
    {
        public void Configure(EntityTypeBuilder<AwardEntity> builder)
        {
            builder.HasData(CreateAwards());
        }

        private List<AwardEntity> CreateAwards()
        {
            List<AwardEntity> awards = new List<AwardEntity>()
            {
                new AwardEntity()
                {
                    Id = 1,
                    Name = "Best Architecture Award 2022"
                },
                new AwardEntity()
                {
                    Id = 2,
                    Name = "Best Interior Design Award 2022"
                },
                new AwardEntity()
                {
                    Id = 3,
                    Name = "Best Visualization Award 2022"
                },
                new AwardEntity()
                {
                    Id = 4,
                    Name = "Best Photography Award 2022"
                }
            };

            return awards;
        }
    }
}
