using RP_Server.Enums;
using System.ComponentModel.DataAnnotations;

namespace RP_Server.Requests
{
    public class RegistrationRequest
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }

        public Role Role { get; set; }
    }
}
