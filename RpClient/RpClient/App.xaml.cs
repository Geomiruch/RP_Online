using RpClient.Services;
using RpClient.Views;
using RpClient.Views.Auth;

namespace RpClient
{
    public partial class App : Application
    {
        private AuthService _authService;
        public App()
        {
            InitializeComponent();
            _authService = new AuthService();
            if (Task.Run(async () => await SecureStorage.Default.GetAsync("jwt_token")).Result == null)
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
