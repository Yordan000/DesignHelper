using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignHelper.Infrastructure.Data
{
    public class UserProject
    {
        [Required]
        public string ApplicationUserId { get; set; } = null!;

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; } = null!;

        [Required]
        public int ProjectEntityId { get; set; }

        [ForeignKey(nameof(ProjectEntityId))]
        public ProjectEntity ProjectEntity { get; set; } = null!;
    }
}
