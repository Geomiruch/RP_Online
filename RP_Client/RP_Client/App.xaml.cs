using RP_Client.Views.Auth;

namespace RP_Client
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SignInPage());
        }
    }
}
