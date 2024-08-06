namespace RpClient.Tools
{
    public static class HttpClientHelper
    {
        public static HttpClient CreateHttpClient()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
                {
                    return true; // Довіряти будь-якому сертифікату
                }
            };

            var httpClient = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(30)
            };

            return httpClient;
        }
    }
}
