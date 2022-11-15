using DesignHelper.Infrastructure.Constrains;
using System.ComponentModel.DataAnnotations;

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
