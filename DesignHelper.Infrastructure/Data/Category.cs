using DesignHelper.Infrastructure.Constrains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignHelper.Infrastructure.Data
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ConstrainValidations.CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public List<ProjectEntity> Projects { get; set; } = new List<ProjectEntity>();
    }
}
