namespace RpClient
{
    public static class Constants
    {
        public const string ServerURL = "https://192.168.1.104:7128/api";

        public static class UserEndpoints
        {
            public const string LoginEndpoint = "/users/login";
            public const string RegisterEndpoint = "/users/register";
            public const string RefreshTokenEndpoint = "/users/refreshToken";
        }

        public static class CharacterEndpoints
        {
            public const string GetAllEndpoint = "/characters/all";
        }
    }
}
