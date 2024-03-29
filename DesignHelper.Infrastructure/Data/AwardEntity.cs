﻿using DesignHelper.Infrastructure.Constrains;
using System.ComponentModel.DataAnnotations;

namespace DesignHelper.Infrastructure.Data
{
    public class AwardEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ConstrainValidations.AwardsNameMaxLength)]
        public string Name { get; set; } = null!;

        public List<ProjectEntity> ProjectsWithAwards { get; set; } = new List<ProjectEntity>();
    }
}
