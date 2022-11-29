using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignHelper.Infrastructure.Data
{
    public class ProjectToolsUsed
    {
        [Required]
        public int ProjectsEntityId { get; set; }

        [ForeignKey(nameof(ProjectsEntityId))]
        public ProjectEntity ProjectTools { get; set; } = null!;

        [Required]
        public int ToolsUsedId { get; set; }

        [ForeignKey(nameof(ToolsUsedId))]
        public ToolUsed ToolsUsed { get; set; } = null!;

    }
}
