using DesignHelper.Infrastructure.Constrains;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignHelper.Infrastructure.Data
{
    public class ToolUsed
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ConstrainValidations.ToolsUsedNameMaxLength)]
        public string Name { get; set; } = null!;

        public List<ProjectToolsUsed> ProjectsToolsUsed { get; set; } = new List<ProjectToolsUsed>();
    }
}
