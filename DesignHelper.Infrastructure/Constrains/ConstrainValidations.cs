using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignHelper.Infrastructure.Constrains
{
    public class ConstrainValidations
    {
        //Title
        public const int TitleMinLength = 5;
        public const int TitleMaxLength = 50;
        
        //Desctription
        public const int DescriptionMinLength = 5;
        public const int DescriptionMaxLength = 1000;

        //Category
        public const int CategoryNameMinLength = 5;
        public const int CategoryNameMaxLength = 50;
    }
}
