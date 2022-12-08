using DesignHelper.Infrastructure.Constrains;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DesignHelper.Infrastructure.Data
{
    public class User : IdentityUser<string>
    {
        [Required]
        [MinLength(ConstrainValidations.UserFirstNameMinLength)]
        [MaxLength(ConstrainValidations.UserFirstNameMaxLength)]
        public string? FirstName { get; set; }

        [Required]
        [MinLength(ConstrainValidations.UserLastNameMinLength)]
        [MaxLength(ConstrainValidations.UserLastNameMaxLength)]
        public string? LastName { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
