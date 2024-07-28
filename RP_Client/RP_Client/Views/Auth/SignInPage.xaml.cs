using RP_Client.Contracts.Auth;
using RP_Client.Services;

namespace RP_Client.Views.Auth;

public partial class SignInPage : ContentPage
{
    private readonly AuthService _authService;

    public SignInPage()
	{
		InitializeComponent();
        _authService = new AuthService();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(emailEntry.Text) ||
            string.IsNullOrWhiteSpace(passwordEntry.Text))
        {
            await DisplayAlert("Error", "All fields are required.", "OK");
            return;
        }

        try
        {
            string email = emailEntry.Text;
            string password = passwordEntry.Text;
            SignInResponse response = await _authService.SendSignInRequestAsync(email, password);

            await Navigation.PushAsync(new MainPage());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async void OnSignUpTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignUpPage());
    }
}