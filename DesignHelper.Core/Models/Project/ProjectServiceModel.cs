using DesignHelper.Infrastructure.Constrains;
using DesignHelper.Infrastructure.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesignHelper.Core.Models.Project
{
    public class ProjectServiceModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Location { get; set; } = null!;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;
        public string Author { get; set; } = null!;
        public double Area { get; set; }
        public decimal Rating { get; set; }
    }
}
