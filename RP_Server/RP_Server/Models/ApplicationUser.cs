﻿using Microsoft.AspNetCore.Identity;
using RP_Server.Enums;

namespace RP_Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Role Role { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}
