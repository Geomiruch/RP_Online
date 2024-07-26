using System;
using System.Collections.Generic;
using System.Text;

namespace RP_App
{
    public static class Constants
    {
        public const string ServerURL = "https://192.168.1.104:7128/api";

        public static class UserEndpoints
        {
            public const string LoginEndpoint = "/users/register";
            public const string RegisterEndpoint = "/users/login";
        }
    }
}
