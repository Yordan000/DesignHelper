using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignHelper.Core.Models.Project
{
    public class ProjectDetailsViewModel : ProjectServiceModel
    {
        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string Award { get; set; } = null!;

        public List<string> ToolsUsed { get; set; } = null!;
    }
}
