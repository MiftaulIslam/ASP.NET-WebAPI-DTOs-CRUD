using dtos_practice.Models.Entity;

namespace dtos_practice.Models.DTOs.UserDTOs
{
    public class UserUpdateDTO:EntityBase
    {

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
    }
}
