using DesignHelper.Infrastructure.Constrains;
using DesignHelper.Infrastructure.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DesignHelper.Core.Contracts;

namespace DesignHelper.Core.Models.Project
{
    public class ProjectServiceModel : IProjectModel
    {
        public int Id { get; init; }
        public string Title { get; init; } = null!;
        public string Location { get; init; } = null!;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; } = null!;
        public string Author { get; init; } = null!;
        public double Area { get; init; }
        public decimal Rating { get; init; }
        public bool IsFavourite { get; init; }

    }
}
