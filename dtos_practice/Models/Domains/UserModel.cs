using dtos_practice.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace dtos_practice.Models.Domains
{
    public class UserModel:EntityBase
    {
        [Required(ErrorMessage ="First name is required")]
        [MinLength(3, ErrorMessage = "First name must be atleast 3 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        [MinLength(3, ErrorMessage = "Last name must be atleast 3 characters")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email Address is required")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid Email Address")]

        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one number, one special character, and be at least 8 characters long")]

        public string Password { get; set; } = string.Empty;


        [StringLength(11, ErrorMessage = "Contact number cannot exceed 11 digits")]
        [MinLength(11, ErrorMessage = "Contact number must be at least 11 digits")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Contact number must be exactly 11 digits")]
        public string Contact { get; set; } = string.Empty;
    }
}
