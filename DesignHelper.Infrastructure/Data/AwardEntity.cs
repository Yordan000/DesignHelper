using System.ComponentModel.DataAnnotations;

namespace DesignHelper.Infrastructure.Data
{
    public class AwardEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public List<ProjectEntity> Projects { get; set; } = new List<ProjectEntity>();
    }
}
