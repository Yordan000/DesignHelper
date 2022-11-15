using System.ComponentModel.DataAnnotations;

namespace DesignHelper.Infrastructure.Data
{
    public class TopRatedEntity
    {
        [Key]
        public int Id { get; set; }

        public List<ProjectEntity> Projects { get; set; } = new List<ProjectEntity>();
    }
}
