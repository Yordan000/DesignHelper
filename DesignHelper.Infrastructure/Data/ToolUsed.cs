using DesignHelper.Infrastructure.Constrains;
using System.ComponentModel.DataAnnotations;

namespace DesignHelper.Infrastructure.Data
{
    public class ToolUsed
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ConstrainValidations.ToolsUsedNameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
