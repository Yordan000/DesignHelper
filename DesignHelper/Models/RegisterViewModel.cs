using DesignHelper.ViewModelsConstrains;
using System.ComponentModel.DataAnnotations;

namespace DesignHelper.Models
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(ViewModelsValidations.UserNameMinLength)]
        [MaxLength(ViewModelsValidations.UserNameMaxLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [MinLength(ViewModelsValidations.EmailMinLength)]
        [MaxLength(ViewModelsValidations.EmailMaxLength)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(ViewModelsValidations.PasswordMinLength)]
        [MaxLength(ViewModelsValidations.PasswordMaxLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
