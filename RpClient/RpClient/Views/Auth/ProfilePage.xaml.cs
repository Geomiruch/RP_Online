namespace RpClient.Views.Auth;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
	}

    private async void LogOut_Button_Clicked(object sender, EventArgs e)
    {
		SecureStorage.Remove("jwt_token");
        await Navigation.PushAsync(new SignInPage(), true);
    }
}