using RpClient.Views.Auth;
using RpClient.Views.Character;

namespace RpClient.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private async void Resume_Button_Clicked(object sender, EventArgs e)
	{

	}
    private async void Characters_Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CharactersListPage(), true);
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