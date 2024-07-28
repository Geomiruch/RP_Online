using RP_Client.Services;

namespace RP_Client.Views.Auth;

public partial class SignUpPage : ContentPage
{
    private readonly AuthService _authService;

    public SignUpPage()
	{
		InitializeComponent();
        _authService = new AuthService();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(emailEntry.Text) ||
            string.IsNullOrWhiteSpace(userName.Text) ||
            string.IsNullOrWhiteSpace(passwordEntry.Text) ||
            string.IsNullOrWhiteSpace(passwordRepeatEntry.Text))
        {
            await DisplayAlert("Error", "All fields are required.", "OK");
            return;
        }

        if (passwordEntry.Text != passwordRepeatEntry.Text)
        {
            await DisplayAlert("Error", "Passwords do not match.", "OK");
            return;
        }

        try
        {
            var response = await _authService.SendSignUpRequestAsync(
                emailEntry.Text,
                userName.Text,
                passwordEntry.Text
            );

            await DisplayAlert("Success", "Registration successful!", "OK");
            await Navigation.PushAsync(new SignInPage());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async void OnSignInTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignInPage());
    }
}