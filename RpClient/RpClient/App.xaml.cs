using RpClient.Services;
using RpClient.Views;
using RpClient.Views.Auth;

namespace RpClient
{
    public partial class App : Application
    {
        AuthService _authService;
        public App()
        {
            _authService = new AuthService();
            InitializeComponent();
            if (SecureStorage.GetAsync("jwt_token").Result == null)
            {
                MainPage = new NavigationPage(new SignInPage());
            }
            else if (_authService.GetUserRoleFromToken() == "Admin")
            {
                MainPage = new NavigationPage(new AdminPanel());
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
        }
    }
}
