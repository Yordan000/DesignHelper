using DesignHelper.Core.Models.CheckBoxValidation;
using DesignHelper.Infrastructure.Constrains;
using System.ComponentModel.DataAnnotations;

namespace DesignHelper.Core.Models.Project
{
    public class ProjectAddViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ConstrainValidations.TitleMinLength)]
        [MaxLength(ConstrainValidations.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(ConstrainValidations.DescriptionMinLength)]
        [MaxLength(ConstrainValidations.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MinLength(ConstrainValidations.LocationMinLength)]
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

        [Display(Name = "Award")]
        public int AwardId { get; set; }

        public IEnumerable<ProjectAwardsModel> ProjectAwards { get; set; } = new List<ProjectAwardsModel>();

        //[Display(Name = "Tools used")]
        //public int ToolsId { get; set; }
        //public IEnumerable<ProjectToolsUsedModel> ProjectTools { get; set; } = new List<ProjectToolsUsedModel>();

        public List<CheckBoxItem> ProjectTools { get; set; } = new List<CheckBoxItem>();

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<ProjectCategoryModel> ProjectCategories { get; set; } = new List<ProjectCategoryModel>();
    }
}
