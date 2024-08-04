using RpClient.Views.Auth;

namespace RpClient.Views;

public partial class AdminPanel : ContentPage
{
	public AdminPanel()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private async void Area_Button_Clicked(object sender, EventArgs e)
    {

    }
    private async void Entities_Button_Clicked(object sender, EventArgs e)
    {

    }
    private async void Lore_Button_Clicked(object sender, EventArgs e)
    {

    }
    private async void Rules_Button_Clicked(object sender, EventArgs e)
    {

    }
    private async void Profile_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProfilePage(), true);
    }
}