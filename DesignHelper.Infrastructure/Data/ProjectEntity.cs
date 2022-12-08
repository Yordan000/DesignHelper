using DesignHelper.Infrastructure.Constrains;
using Microsoft.AspNetCore.Identity;
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
        [MaxLength(ConstrainValidations.LocationMaxLength)]
        public string Location { get; set; } = null!;

        [Required]
        [MaxLength(ConstrainValidations.AuthorMaxLength)]
        public string Author { get; set; } = null!;

        [Required]
        [Range(ConstrainValidations.AreaMinLength, ConstrainValidations.AreaMaxLength)]
        public double Area { get; set; }

        [Required]
        [Range(typeof(decimal), ConstrainValidations.RatingMinLength, ConstrainValidations.RatingMaxLength)]
        public decimal Rating { get; set; }

        [Required]
        public int AwardId { get; set; }

        [ForeignKey(nameof(AwardId))]
        public AwardEntity Awards { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
        public List<ProjectToolsUsed> ProjectsToolsUsed { get; set; } = new List<ProjectToolsUsed>();
        public bool IsActive { get; set; } = true;

        public string? AddToFavouritesId { get; set; }

        [ForeignKey(nameof(AddToFavouritesId))]
        public User? AddToFavourites { get; set; } 

    }
}
