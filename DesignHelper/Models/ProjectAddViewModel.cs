using DesignHelper.Infrastructure.Constrains;
using DesignHelper.Infrastructure.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesignHelper.Models
{
    public class ProjectAddViewModel
    {
        [Required]
        [MinLength(ConstrainValidations.TitleMinLength)]
        [MaxLength(ConstrainValidations.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(ConstrainValidations.DescriptionMinLength)]
        [MaxLength(ConstrainValidations.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MaxLength(ConstrainValidations.LocationMaxLength)]
        public string Location { get; set; } = null!;

        [Required]
        [MinLength(ConstrainValidations.AuthorMinLength)]
        [MaxLength(ConstrainValidations.AuthorMaxLength)]
        public string Author { get; set; } = null!;

        [Required]
        [Range(ConstrainValidations.AreaMinLength, ConstrainValidations.AreaMaxLength)]
        public double Area { get; set; }

        [Required]
        [Range(typeof(decimal), ConstrainValidations.RatingMinLength, ConstrainValidations.RatingMaxLength)]
        public decimal Rating { get; set; }

        public int AwardId { get; set; }

        public IEnumerable<AwardEntity> Awards { get; set; } = new List<AwardEntity>();

        public int ToolsId { get; set; }

        public IEnumerable<ToolUsed> Tools { get; set; } = new List<ToolUsed>();

        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
