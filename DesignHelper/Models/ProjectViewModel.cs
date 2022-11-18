using DesignHelper.Infrastructure.Constrains;
using DesignHelper.Infrastructure.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesignHelper.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Author { get; set; } = null!;
        public double Area { get; set; }
        public decimal Rating { get; set; }
        public string? Award { get; set; }
        public string? Tools { get; set; }
        public string? Category { get; set; }
    }
}
