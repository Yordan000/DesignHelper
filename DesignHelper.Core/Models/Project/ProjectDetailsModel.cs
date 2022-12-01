using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignHelper.Core.Models.Project
{
    public class ProjectDetailsModel
    {
        public string Title { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}
