using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignHelper.Core.Models.CheckBoxValidation
{
    public class CheckBoxItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsChecked { get; set; } = false;
    }
}
