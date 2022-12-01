using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignHelper.Core.Models.Project
{
    public class AllProjectsQueryModel
    {
        public const int ProjectsPerPage = 3;

        public string? Category { get; set; }

        public string? Award { get; set; }

        [Display(Name = "Search by text")]
        public string? SearchTerm { get; set; }

        public ProjectSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalProjectsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<string> Awards { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<ProjectServiceModel> Projects { get; set; } = Enumerable.Empty<ProjectServiceModel>();
    }
}
