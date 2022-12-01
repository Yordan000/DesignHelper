using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignHelper.Core.Models.Project
{
    public class ProjectQueryServiceModel
    {
        public int TotalProjectsCount { get; set; }

        public IEnumerable<ProjectServiceModel> Projects { get; set; } = new List<ProjectServiceModel>();
    }
}
