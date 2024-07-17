using System;
using System.Collections.Generic;
using System.Text;

namespace RP_App.Contracts.Login
{
    public class LoginResponse
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
