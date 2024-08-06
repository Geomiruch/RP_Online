namespace RpClient.Views.Character;

public partial class CharactersListPage : ContentPage
{
	public CharactersListPage()
	{
		InitializeComponent();
        try
        {
            BindingContext = new CharactersViewModel();
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }
    }

    
}