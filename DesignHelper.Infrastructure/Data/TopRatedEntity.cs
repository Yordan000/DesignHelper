using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignHelper.Infrastructure.Data
{
    public class TopRatedEntity
    {
        [Key]
        public int Id { get; set; }

        public List<ProjectEntity> Projects { get; set; } = new List<ProjectEntity>();
    }
}
