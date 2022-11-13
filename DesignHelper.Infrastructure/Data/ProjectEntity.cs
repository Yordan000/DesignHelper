using DesignHelper.Infrastructure.Constrains;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignHelper.Infrastructure.Data
{
    public class ProjectEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ConstrainValidations.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ConstrainValidations.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string Location { get; set; } = null!;

        [Required]
        public string Designer { get; set; } = null!;

        [Required]
        public double Area { get; set; }

        [Required]
        public decimal Rating { get; set; }

        [Required]
        public bool Awards { get; set; }

        [Required]
        public bool Visualization { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
      
    }
}
