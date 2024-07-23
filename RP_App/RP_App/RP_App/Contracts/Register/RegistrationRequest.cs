using System;
using System.Collections.Generic;
using System.Text;

namespace RP_App.Contracts.Register
{
    public class RegistrationRequest
    {
        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
